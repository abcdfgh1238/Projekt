namespace ReShareBlazorApp.Web.Models
{
    // Jedno ogłoszenie na stronie – może być przedmiotem na sprzedaż albo usługą / wynajmem
    public class ListingItem
    {
        public int Id { get; set; }                         // unikalny numer ogłoszenia
        public string Name { get; set; } = "";              // nazwa przedmiotu lub usługi
        public string Description { get; set; } = "";       // opis ogłoszenia
        public decimal Price { get; set; }                  // cena liczbowa
        public string PriceNote { get; set; } = "";         // dopisek do ceny, np. " / dzień" (dla przedmiotów puste)
        public string Category { get; set; } = "";          // nazwa kategorii, np. "Rowerowe"
        public bool IsService { get; set; }                 // false = produkt, true = usługa / wynajem
        public string ImageUrl { get; set; } = "";          // adres zdjęcia (puste = brak zdjęcia)
        public string City { get; set; } = "";              // miejscowość
        public string Condition { get; set; } = "";         // stan przedmiotu: Nowy / Używany... (dla usług puste)
        public string SellerName { get; set; } = "";        // nazwa użytkownika podana przy wystawianiu (konto nie jest wymagane)
        public string OwnerEmail { get; set; } = "";        // e-mail osoby, która wystawiła ogłoszenie
        public List<string> Images { get; set; } = new();   // dodatkowe zdjęcia do galerii na stronie ogłoszenia
        public DateTime CreatedAt { get; set; } = DateTime.Now;   // kiedy dodano

        // Gotowy tekst ceny do wyświetlenia na karcie, np. "650 zł" albo "40 zł / dzień"
        public string PriceLabel => $"{Price:0.##} zł{PriceNote}";

        // Większa wersja głównego zdjęcia (strona ogłoszenia, karuzela)
        public string BigImageUrl => ImageUrl.Replace("/600/450", "/1000/750");

        // Wszystkie zdjęcia do galerii: główne + dodatkowe
        public IEnumerable<string> AllImages =>
            (string.IsNullOrWhiteSpace(ImageUrl) ? Enumerable.Empty<string>() : new[] { BigImageUrl }).Concat(Images);

        // Samo rozliczenie usługi bez ukośnika, np. "dzień" (używane w filtrach)
        public string Unit => PriceNote.Trim().TrimStart('/').Trim();
    }
}
