namespace WebApplication1_SozialMediaPlatform01.Models
{
    public class Peep
    {
        public int Id { get; set; }
        public string PeepWort { get; set; }
        public List<NachrichtPeep>? NachrichtpeepListe { get; set; } = new List<NachrichtPeep>();
    }
}
