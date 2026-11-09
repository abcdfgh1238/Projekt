namespace ReShareBlazorApp.Web.Services
{
    // Jedna pozycja w koszyku: numer ogłoszenia + ilość
    public record CartLine(int ListingId, int Quantity);

    // Koszyki trzymane w pamięci serwera. Klucz = identyfikator z ciasteczka przeglądarki,
    // więc koszyk działa też bez logowania. Docelowo można zapisać go w bazie.
    public class CartStore
    {
        private readonly object _lock = new();
        private readonly Dictionary<string, List<CartLine>> _carts = new();

        public void Add(string cartId, int listingId, int quantity)
        {
            lock (_lock)
            {
                var lines = GetOrCreate(cartId);
                var index = lines.FindIndex(x => x.ListingId == listingId);
                if (index >= 0)
                    lines[index] = lines[index] with { Quantity = Math.Min(99, lines[index].Quantity + quantity) };
                else
                    lines.Add(new CartLine(listingId, Math.Min(99, quantity)));
            }
        }

        // Ustawia ilość; 0 lub mniej usuwa pozycję
        public void SetQuantity(string cartId, int listingId, int quantity)
        {
            lock (_lock)
            {
                var lines = GetOrCreate(cartId);
                var index = lines.FindIndex(x => x.ListingId == listingId);
                if (index < 0) return;
                if (quantity <= 0) lines.RemoveAt(index);
                else lines[index] = lines[index] with { Quantity = Math.Min(99, quantity) };
            }
        }

        public void Clear(string cartId)
        {
            lock (_lock) { _carts.Remove(cartId); }
        }

        public List<CartLine> GetLines(string cartId)
        {
            lock (_lock) { return _carts.TryGetValue(cartId, out var lines) ? lines.ToList() : new(); }
        }

        // Łączna liczba sztuk (plakietka przy ikonie koszyka)
        public int Count(string cartId)
        {
            lock (_lock) { return _carts.TryGetValue(cartId, out var lines) ? lines.Sum(x => x.Quantity) : 0; }
        }

        private List<CartLine> GetOrCreate(string cartId)
        {
            if (!_carts.TryGetValue(cartId, out var lines))
                _carts[cartId] = lines = new List<CartLine>();
            return lines;
        }
    }
}
