namespace ReShareBlazorApp.Web.Models
{
    // Wszystkie filtry wyszukiwarki w jednym miejscu (wartości z adresu strony)
    public class ListingFilter
    {
        public bool? IsService { get; set; }      // null = wszystko, false = przedmioty, true = usługi
        public string? Query { get; set; }        // fraza z pola wyszukiwania
        public string? Category { get; set; }     // wybrana kategoria
        public string? City { get; set; }         // miejscowość (fragment nazwy)
        public string? Condition { get; set; }    // stan przedmiotu
        public string? Unit { get; set; }         // rozliczenie usługi (dzień / godz. ...)
        public decimal? MinPrice { get; set; }    // cena od
        public decimal? MaxPrice { get; set; }    // cena do
        public string? Sort { get; set; }         // newest | price-asc | price-desc | name
    }
}
