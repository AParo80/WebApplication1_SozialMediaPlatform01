namespace WebApplication1_SozialMediaPlatform01.Models
{
    public class Like
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public bool LikeBool { get; set; }
        public Nachricht? Nachricht { get; set; }
    }
}
