using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1_SozialMediaPlatform01.Models
{
    public class User
    {
        public int Id { get; set; }
        //ANmelden mit Email + Usernamen
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "Nur Buchstaben und Zahlen erlaubt.")]
        [MinLength(1, ErrorMessage = "Es muß mindestems 1 Zeichen haben"), MaxLength(16, ErrorMessage = "Es darf max. 16 Zeichen haben")]
        public string Username { get; set; }

        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = " keine gültige E-Mail!")]
        public string EMail { get; set; }

        [MaxLength(300, ErrorMessage = "Es darf max. 300 Zeichen haben")]
        public string? Selbstbeschreibung { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        [NotMapped] // Wird NICHT in die Datenbank geschrieben
        public string ConfirmPassword { get; set; }
        // ACHTUNG: ConfirmPassword muß im Create-View erstellt werden!
        // ACHTUNG: ConfirmPassword muß im PersonController --> Create als übergabe eingetragen werden!!! 

        public string? Guid { get; set; }
        public bool IsActive { get; set; } = true;

        public string? PasswordHash { get; set; }
        public string? PasswordSalt { get; set; }

        public DateTime RegistriertAm { get; set; }

        // --------> Anzahl der vergebenen und enthaltenen Likes



    }
}
