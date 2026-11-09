using ReShareBlazorApp.Web.Models;

namespace ReShareBlazorApp.Web.Data
{
    // Przykładowe dane do strony głównej i wyszukiwarki (docelowo zastąpisz je danymi z API / bazy)
    public static class SampleData
    {
        // Pomocnicza metoda – zwraca adres zdjęcia zastępczego (zamień na własne zdjęcia w wwwroot/img)
        private static string Img(string seed, int w = 600, int h = 450) =>
            $"https://picsum.photos/seed/{seed}/{w}/{h}";

        // Zdjęcia do dużej karuzeli 3D na górze strony
        public static readonly List<string> HeroImages = Enumerable.Range(1, 7)
            .Select(i => Img($"reshare-hero-{i}", 1000, 640))
            .ToList();

        // Kategorie z ikonkami (ikonka = wnętrze SVG 24x24, rysowane linią; używane w sekcji "Kupuj według kategorii")
        public static readonly List<CategoryInfo> Categories = new()
        {
            new("Książki", "<path d='M2 3h6a4 4 0 0 1 4 4v14a3 3 0 0 0-3-3H2z'/><path d='M22 3h-6a4 4 0 0 0-4 4v14a3 3 0 0 1 3-3h7z'/>"),
            new("Rowerowe", "<circle cx='18.5' cy='17.5' r='3.5'/><circle cx='5.5' cy='17.5' r='3.5'/><circle cx='15' cy='5' r='1'/><path d='M12 17.5V14l-3-3 4-3 2 3h2'/>"),
            new("Samochodowe", "<path d='M19 17h2c.6 0 1-.4 1-1v-3c0-.9-.7-1.7-1.5-1.9C18.7 10.6 16 10 16 10s-1.3-1.4-2.2-2.3c-.5-.4-1.1-.7-1.8-.7H5c-.6 0-1.1.4-1.4.9l-1.4 2.9A3.7 3.7 0 0 0 2 12v4c0 .6.4 1 1 1h2'/><circle cx='7' cy='17' r='2'/><path d='M9 17h6'/><circle cx='17' cy='17' r='2'/>"),
            new("Elektronika", "<rect x='3' y='4' width='18' height='12' rx='2'/><path d='M2 20h20'/>"),
            new("Telefony", "<rect x='6' y='2' width='12' height='20' rx='2'/><path d='M11 18h2'/>"),
            new("Moda", "<path d='M20.4 5.2 16 3a4 4 0 0 1-8 0L3.6 5.2a1 1 0 0 0-.6 1.1l.7 4.1c.1.5.5.8 1 .7L7 10.5V20a1 1 0 0 0 1 1h8a1 1 0 0 0 1-1v-9.5l1.3.6c.5.1.9-.2 1-.7l.7-4.1a1 1 0 0 0-.6-1.1z'/>"),
            new("Dom i ogród", "<path d='m3 10 9-7 9 7'/><path d='M5 9v11h14V9'/><path d='M10 20v-6h4v6'/>"),
            new("Meble", "<path d='M4 11V8a3 3 0 0 1 3-3h10a3 3 0 0 1 3 3v3'/><path d='M2 14a2 2 0 0 1 4 0v2h12v-2a2 2 0 0 1 4 0v4H2z'/><path d='M5 18v2M19 18v2'/>"),
            new("Sport", "<path d='M6 6v12M18 6v12M3 9v6M21 9v6M6 12h12'/>"),
            new("Dla dzieci", "<rect x='3' y='12' width='8' height='8' rx='1'/><rect x='13' y='12' width='8' height='8' rx='1'/><rect x='8' y='4' width='8' height='8' rx='1'/>"),
            new("Muzyka", "<path d='M9 18V5l12-2v13'/><circle cx='6' cy='18' r='3'/><circle cx='18' cy='16' r='3'/>"),
            new("Gry", "<path d='M6 12h4M8 10v4'/><circle cx='15' cy='13' r='1'/><circle cx='18' cy='11' r='1'/><path d='M17.3 5H6.7a4 4 0 0 0-3.9 3.2l-1.4 7A3 3 0 0 0 4.3 19c.8 0 1.5-.4 2-1l1.7-2h8l1.7 2c.5.6 1.2 1 2 1a3 3 0 0 0 2.9-3.8l-1.4-7A4 4 0 0 0 17.3 5z'/>"),
            new("Narzędzia", "<path d='M14.7 6.3a4 4 0 0 0-5.4 5.4L3 18l3 3 6.3-6.3a4 4 0 0 0 5.4-5.4l-2.5 2.5-2.4-.6-.6-2.4z'/>"),
            new("Zwierzęta", "<circle cx='6' cy='10' r='2'/><circle cx='10' cy='5.5' r='2'/><circle cx='15' cy='5.5' r='2'/><circle cx='19' cy='10' r='2'/><path d='M8 17c0-3 2-5 4-5s4 2 4 5c0 2-2 3-4 2-2 1-4 0-4-2z'/>"),
            new("Fotografia", "<path d='M14.5 4h-5L7 7H4a2 2 0 0 0-2 2v9a2 2 0 0 0 2 2h16a2 2 0 0 0 2-2V9a2 2 0 0 0-2-2h-3z'/><circle cx='12' cy='13' r='3'/>"),
            new("Antyki", "<circle cx='12' cy='12' r='9'/><path d='M12 7v5l3 2'/>"),
            new("Uroda", "<path d='M12 3l1.9 5.1L19 10l-5.1 1.9L12 17l-1.9-5.1L5 10l5.1-1.9z'/><path d='M19 17v4M17 19h4'/>"),
            new("Podróże", "<path d='M17.8 19.2 16 11l3.5-3.5C21 6 21.5 4 21 3c-1-.5-3 0-4.5 1.5L13 8 4.8 6.2c-.5-.1-.9.1-1.1.5l-.3.5c-.2.5-.1 1 .3 1.3L9 12l-2 3H4l-1 1 3 2 2 3 1-1v-3l3-2 3.5 5.3c.3.4.8.5 1.3.3l.5-.2c.4-.3.6-.7.5-1.2z'/>"),
        };

        // Lista przedmiotów na sprzedaż
        public static readonly List<ListingItem> Products = new()
        {
            new() { Id = 1,  Name = "Rower górski 26\"",            Price = 650,  Category = "Rowerowe",      ImageUrl = Img("rs-p1") },
            new() { Id = 2,  Name = "Kask rowerowy",                Price = 80,   Category = "Rowerowe",      ImageUrl = Img("rs-p2") },
            new() { Id = 3,  Name = "Harry Potter – komplet",       Price = 120,  Category = "Książki",       ImageUrl = Img("rs-p3") },
            new() { Id = 4,  Name = "Kryminały – zestaw 10 sztuk",  Price = 45,   Category = "Książki",       ImageUrl = Img("rs-p4") },
            new() { Id = 5,  Name = "Opony zimowe 205/55 R16",      Price = 400,  Category = "Samochodowe",   ImageUrl = Img("rs-p5") },
            new() { Id = 6,  Name = "Fotelik samochodowy",          Price = 150,  Category = "Dla dzieci",    ImageUrl = Img("rs-p6") },
            new() { Id = 7,  Name = "Laptop Lenovo ThinkPad",       Price = 1400, Category = "Elektronika",   ImageUrl = Img("rs-p7") },
            new() { Id = 8,  Name = "Słuchawki bezprzewodowe",      Price = 180,  Category = "Elektronika",   ImageUrl = Img("rs-p8") },
            new() { Id = 9,  Name = "Smartfon 128 GB",              Price = 1600, Category = "Telefony",      ImageUrl = Img("rs-p9") },
            new() { Id = 10, Name = "Kurtka zimowa",                Price = 130,  Category = "Moda",          ImageUrl = Img("rs-p10") },
            new() { Id = 11, Name = "Sofa 3-osobowa",               Price = 500,  Category = "Meble",         ImageUrl = Img("rs-p11") },
            new() { Id = 12, Name = "Kosiarka elektryczna",         Price = 220,  Category = "Dom i ogród",   ImageUrl = Img("rs-p12") },
            new() { Id = 13, Name = "Hulajnoga elektryczna",        Price = 900,  Category = "Sport",         ImageUrl = Img("rs-p13") },
            new() { Id = 14, Name = "Wózek dziecięcy 3w1",          Price = 350,  Category = "Dla dzieci",    ImageUrl = Img("rs-p14") },
            new() { Id = 15, Name = "Gitara akustyczna",            Price = 300,  Category = "Muzyka",        ImageUrl = Img("rs-p15") },
            new() { Id = 16, Name = "Konsola do gier",              Price = 750,  Category = "Gry",           ImageUrl = Img("rs-p16") },
            new() { Id = 17, Name = "Wiertarka udarowa",            Price = 110,  Category = "Narzędzia",     ImageUrl = Img("rs-p17") },
            new() { Id = 18, Name = "Aparat lustrzanka",            Price = 1200, Category = "Fotografia",    ImageUrl = Img("rs-p18") },
            new() { Id = 19, Name = "Zegar z lat 60.",              Price = 260,  Category = "Antyki",        ImageUrl = Img("rs-p19") },
            new() { Id = 20, Name = "Klatka dla papugi",            Price = 90,   Category = "Zwierzęta",     ImageUrl = Img("rs-p20") },
        };

        // Lista usług i wynajmu
        public static readonly List<ListingItem> Services = new()
        {
            new() { Id = 101, Name = "Wynajem wiertarki",          Price = 30,  PriceNote = " / dzień",  Category = "Narzędzia",    IsService = true, ImageUrl = Img("rs-s1") },
            new() { Id = 102, Name = "Wynajem roweru miejskiego",  Price = 40,  PriceNote = " / dzień",  Category = "Rowerowe",     IsService = true, ImageUrl = Img("rs-s2") },
            new() { Id = 103, Name = "Wynajem busa 9-osobowego",   Price = 250, PriceNote = " / dzień",  Category = "Samochodowe",  IsService = true, ImageUrl = Img("rs-s3") },
            new() { Id = 104, Name = "Wynajem aparatu i obiektywów", Price = 90, PriceNote = " / dzień", Category = "Fotografia",   IsService = true, ImageUrl = Img("rs-s4") },
            new() { Id = 105, Name = "Korepetycje z matematyki",   Price = 60,  PriceNote = " / godz.",  Category = "Książki",      IsService = true, ImageUrl = Img("rs-s5") },
            new() { Id = 106, Name = "Wynajem przyczepki",         Price = 80,  PriceNote = " / dzień",  Category = "Samochodowe",  IsService = true, ImageUrl = Img("rs-s6") },
            new() { Id = 107, Name = "Wynajem namiotu 4-osobowego", Price = 35, PriceNote = " / dzień",  Category = "Podróże",      IsService = true, ImageUrl = Img("rs-s7") },
            new() { Id = 108, Name = "Sesja zdjęciowa",            Price = 300, PriceNote = " / sesja",  Category = "Fotografia",   IsService = true, ImageUrl = Img("rs-s8") },
            new() { Id = 109, Name = "Wynajem nagłośnienia",       Price = 150, PriceNote = " / dzień",  Category = "Muzyka",       IsService = true, ImageUrl = Img("rs-s9") },
            new() { Id = 110, Name = "Wynajem myjki ciśnieniowej", Price = 55,  PriceNote = " / dzień",  Category = "Dom i ogród",  IsService = true, ImageUrl = Img("rs-s10") },
        };

        // Miejscowości do podpowiedzi w formularzach
        public static readonly string[] Cities = { "Warszawa", "Kraków", "Wrocław", "Gdańsk", "Poznań", "Łódź" };

        // Stany przedmiotów (filtr i formularz)
        public static readonly string[] Conditions = { "Nowy", "Jak nowy", "Używany", "Do naprawy" };

        // Rozliczenia usług (filtr i formularz): wynik to np. " / dzień"
        public static readonly string[] Units = { "godz.", "dzień", "tydzień", "sesja", "usługa" };

        // Zdjęcie kafelka kategorii (na stronie głównej)
        public static string CategoryImage(int index) => Img($"rs-cat-{index}", 500, 380);

        // Uzupełnia dane przykładowe: miejscowość, stan, opis, galerię i datę dodania
        static SampleData()
        {
            foreach (var item in Products.Concat(Services))
            {
                item.City = Cities[item.Id % Cities.Length];
                item.OwnerEmail = "demo@reshare.pl";
                item.CreatedAt = DateTime.Today.AddDays(-(item.Id % 20));

                if (!item.IsService)
                    item.Condition = Conditions[item.Id % 3];          // Nowy / Jak nowy / Używany

                item.Description = item.IsService
                    ? $"{item.Name} – oferta dostępna od ręki. Wszystko sprawne, czyste i przygotowane specjalnie dla Ciebie.\n\n" +
                      $"Stawka: {item.Price:0.##} zł {item.PriceNote.Trim()}. Przy dłuższym okresie możliwy rabat. Odbiór i zwrot: {item.City}.\n\n" +
                      "Chętnie odpowiem na pytania i dopasuję termin. Napisz, kiedy jesteś zainteresowany."
                    : $"{item.Name} na sprzedaż. Stan: {item.Condition.ToLower()} – sprawdzony i w pełni sprawny, bez ukrytych wad.\n\n" +
                      "Sprzedaję, bo już z niego nie korzystam i szkoda, żeby leżał. Cena do rozmowy przy szybkim odbiorze.\n\n" +
                      $"Odbiór osobisty: {item.City}. Możliwa wysyłka kurierem po wcześniejszym ustaleniu. Zapraszam do kontaktu.";

                // Dodatkowe zdjęcia do galerii (przykładowe – losowe z picsum)
                if (item.ImageUrl.StartsWith("https://picsum.photos/seed/"))
                {
                    var seed = item.ImageUrl.Split('/')[4];
                    item.Images.Add(Img(seed + "-b", 1000, 750));
                    item.Images.Add(Img(seed + "-c", 1000, 750));
                    item.Images.Add(Img(seed + "-d", 1000, 750));
                }
            }
        }

        // Wszystkie ogłoszenia razem (produkty + usługi) – po tym działa wyszukiwarka
        public static IEnumerable<ListingItem> All => Products.Concat(Services);
    }

    // Kategoria: nazwa + ikonka (wnętrze SVG)
    public record CategoryInfo(string Name, string Icon);
}
