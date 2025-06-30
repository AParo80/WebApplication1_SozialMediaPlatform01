namespace WebApplication1_SozialMediaPlatform01.Models
{
    public class NachrichtPeep
    {
        public int Id { get; set; }
        public int? NachrichtId { get; set; }
        public Nachricht? Nachricht { get; set; }
        public int? PeepId { get; set; }
        public Peep? Peep { get; set; }
    }
}
