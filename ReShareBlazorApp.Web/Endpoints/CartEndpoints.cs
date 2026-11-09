using Microsoft.AspNetCore.Mvc;
using ReShareBlazorApp.Web.Services;

namespace ReShareBlazorApp.Web.Endpoints
{
    // Akcje koszyka (zwykłe formularze POST – działają bez JavaScriptu)
    public static class CartEndpoints
    {
        public const string CookieName = "ReShare.Cart";

        public static void MapCartEndpoints(this WebApplication app)
        {
            // Dodanie ogłoszenia do koszyka
            app.MapPost("/cart/add", (
                [FromForm] int id,
                [FromForm] int? qty,
                [FromForm] string? returnUrl,
                HttpContext context,
                CartStore cart,
                ListingStore listings) =>
            {
                if (listings.GetById(id) is null) return Results.LocalRedirect("/koszyk");

                var cartId = GetOrCreateCartId(context);
                cart.Add(cartId, id, Math.Clamp(qty ?? 1, 1, 99));
                return Results.LocalRedirect(SafeLocal(returnUrl, "/koszyk"));
            });

            // Zmiana ilości (0 = usunięcie pozycji)
            app.MapPost("/cart/update", (
                [FromForm] int id,
                [FromForm] int qty,
                [FromForm] string? returnUrl,
                HttpContext context,
                CartStore cart) =>
            {
                var cartId = ReadCartId(context);
                if (cartId is not null) cart.SetQuantity(cartId, id, qty);
                return Results.LocalRedirect(SafeLocal(returnUrl, "/koszyk"));
            });

            // Opróżnienie koszyka
            app.MapPost("/cart/clear", (HttpContext context, CartStore cart) =>
            {
                var cartId = ReadCartId(context);
                if (cartId is not null) cart.Clear(cartId);
                return Results.LocalRedirect("/koszyk");
            });
        }

        // Identyfikator koszyka z ciasteczka (null, jeśli przeglądarka jeszcze go nie ma)
        public static string? ReadCartId(HttpContext? context)
        {
            if (context is null) return null;
            return context.Request.Cookies.TryGetValue(CookieName, out var value) && Guid.TryParse(value, out _)
                ? value
                : null;
        }

        private static string GetOrCreateCartId(HttpContext context)
        {
            var existing = ReadCartId(context);
            if (existing is not null) return existing;

            var id = Guid.NewGuid().ToString("N");
            context.Response.Cookies.Append(CookieName, id, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Lax,
                IsEssential = true,
                Expires = DateTimeOffset.UtcNow.AddDays(30)
            });
            return id;
        }

        // Przekierowujemy tylko na adresy z tej samej strony
        private static string SafeLocal(string? url, string fallback) =>
            !string.IsNullOrWhiteSpace(url) && url.StartsWith('/') && !url.StartsWith("//") && !url.StartsWith("/\\")
                ? url
                : fallback;
    }
}
