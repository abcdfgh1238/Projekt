using ReShareBlazorApp.Web.Data;
using ReShareBlazorApp.Web.Models;

namespace ReShareBlazorApp.Web.Services
{
    // Magazyn ogłoszeń trzymany w pamięci (singleton). Startuje od danych przykładowych,
    // a nowe ogłoszenia z formularza lądują na początku listy.
    // Docelowo wymień na zapis w bazie przez API – reszta aplikacji zostanie bez zmian.
    public class ListingStore
    {
        private readonly object _lock = new();
        private readonly List<ListingItem> _items = SampleData.Products.Concat(SampleData.Services).ToList();

        // Same przedmioty (kopia listy – bezpieczna przy dodawaniu w tle)
        public List<ListingItem> Products
        {
            get { lock (_lock) { return _items.Where(x => !x.IsService).ToList(); } }
        }

        // Same usługi
        public List<ListingItem> Services
        {
            get { lock (_lock) { return _items.Where(x => x.IsService).ToList(); } }
        }

        // Dodaje ogłoszenie na początek listy i nadaje mu numer
        public ListingItem Add(ListingItem item)
        {
            lock (_lock)
            {
                item.Id = _items.Count == 0 ? 1 : _items.Max(x => x.Id) + 1;
                item.CreatedAt = DateTime.Now;
                _items.Insert(0, item);
            }
            return item;
        }

        // Jedno ogłoszenie po numerze (null, jeśli nie istnieje)
        public ListingItem? GetById(int id)
        {
            lock (_lock) { return _items.FirstOrDefault(x => x.Id == id); }
        }

        // Podobne ogłoszenia: najpierw z tej samej kategorii, potem tego samego rodzaju
        public List<ListingItem> Related(ListingItem item, int count)
        {
            lock (_lock)
            {
                return _items.Where(x => x.Id != item.Id)
                    .OrderByDescending(x => x.Category == item.Category)
                    .ThenByDescending(x => x.IsService == item.IsService)
                    .Take(count)
                    .ToList();
            }
        }

        // Wyszukiwarka z filtrami
        public List<ListingItem> Search(ListingFilter f)
        {
            List<ListingItem> snapshot;
            lock (_lock) { snapshot = _items.ToList(); }

            IEnumerable<ListingItem> result = snapshot;

            if (f.IsService is bool isService)
                result = result.Where(x => x.IsService == isService);

            if (!string.IsNullOrWhiteSpace(f.Category))
                result = result.Where(x => x.Category.Equals(f.Category.Trim(), StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(f.Query))
            {
                var q = f.Query.Trim();
                result = result.Where(x =>
                    x.Name.Contains(q, StringComparison.OrdinalIgnoreCase) ||
                    x.Category.Contains(q, StringComparison.OrdinalIgnoreCase) ||
                    x.Description.Contains(q, StringComparison.OrdinalIgnoreCase) ||
                    x.SellerName.Contains(q, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(f.City))
                result = result.Where(x => x.City.Contains(f.City.Trim(), StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(f.Condition))
                result = result.Where(x => x.Condition.Equals(f.Condition.Trim(), StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(f.Unit))
                result = result.Where(x => x.Unit.Equals(f.Unit.Trim(), StringComparison.OrdinalIgnoreCase));

            if (f.MinPrice is decimal min)
                result = result.Where(x => x.Price >= min);

            if (f.MaxPrice is decimal max)
                result = result.Where(x => x.Price <= max);

            var polish = StringComparer.Create(new System.Globalization.CultureInfo("pl-PL"), ignoreCase: true);

            return f.Sort switch
            {
                "price-asc"  => result.OrderBy(x => x.Price).ToList(),
                "price-desc" => result.OrderByDescending(x => x.Price).ToList(),
                "name"       => result.OrderBy(x => x.Name, polish).ToList(),
                _            => result.ToList()          // domyślnie: najnowsze na górze (kolejność w magazynie)
            };
        }
    }
}
