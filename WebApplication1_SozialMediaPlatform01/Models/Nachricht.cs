using System.ComponentModel.DataAnnotations;

namespace WebApplication1_SozialMediaPlatform01.Models
{
    public class Nachricht
    {
        public int Id { get; set; }
        //[MinLength(2, ErrorMessage = "Die Nachricht muß min. 2 Zeichen haben")]
        //[MaxLength(123, ErrorMessage = "Die Nachricht darf max. 123 Zeichen haben")]
        [StringLength(123, MinimumLength = 2, ErrorMessage = "Die Nachricht muß zwischen 2 und 123 Zeichen haben")]
        public string Post { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public DateTime PostZeitpunkt { get; set; }
        public List<Like>? Like { get; set; } = new List<Like>();
        public List<NachrichtPeep>? NachrichtpeepListe { get; set; } = new List<NachrichtPeep>();
        //public List<Peep>? PeepWortListe { get; set; } = new List<Peep>();
        //public Peep PeepKlasse { get; set; }

        //Hinweis: ist die Anzahl an alphanumerischen Zeichen zu klein (mind. 3 Zeichen) oder zu groß (max 16.Zeichen), dann zählt der ganze Begriff NICHT als Peep.
    }
}
