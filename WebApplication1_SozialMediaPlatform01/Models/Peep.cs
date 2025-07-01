namespace WebApplication1_SozialMediaPlatform01.Models
{
    public class Peep
    {
        public int Id { get; set; }
        public string PeepWort { get; set; }
        public List<Nachricht>? NachrichtListe { get; set; } = new List<Nachricht>();
    }
}
