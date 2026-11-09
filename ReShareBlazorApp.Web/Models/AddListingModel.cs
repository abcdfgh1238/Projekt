using System.ComponentModel.DataAnnotations;

namespace ReShareBlazorApp.Web.Models
{
    // Dane z formularza „Wystaw ogłoszenie” (zdjęcie obsługiwane osobno w komponencie)
    public class AddListingModel
    {
        [Required(ErrorMessage = "Podaj nazwę użytkownika.")]
        [StringLength(24, MinimumLength = 3, ErrorMessage = "Nazwa użytkownika musi mieć od 3 do 24 znaków.")]
        public string Username { get; set; } = "";

        [Required(ErrorMessage = "Podaj tytuł ogłoszenia.")]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Tytuł musi mieć od 3 do 80 znaków.")]
        public string Title { get; set; } = "";

        [Required(ErrorMessage = "Wybierz kategorię.")]
        public string Category { get; set; } = "";

        [Required(ErrorMessage = "Podaj cenę.")]
        [Range(0, 1000000, ErrorMessage = "Cena musi mieścić się w zakresie 0 – 1 000 000 zł.")]
        public decimal? Price { get; set; }

        public string Unit { get; set; } = "dzień";            // tylko dla usług
        public string Condition { get; set; } = "Używany";     // tylko dla przedmiotów

        [Required(ErrorMessage = "Podaj miejscowość.")]
        [StringLength(60, ErrorMessage = "Nazwa miejscowości jest za długa.")]
        public string City { get; set; } = "";

        [Required(ErrorMessage = "Dodaj opis ogłoszenia.")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Opis musi mieć od 10 do 1000 znaków.")]
        public string Description { get; set; } = "";
    }
}
