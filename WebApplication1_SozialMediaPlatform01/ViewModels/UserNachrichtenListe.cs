using WebApplication1_SozialMediaPlatform01.Models;

namespace WebApplication1_SozialMediaPlatform01.ViewModels
{
    public class UserNachrichtenListe
    {
        public User User { get; set; }
        public List<Nachricht> NachrichtenListe { get; set; } = new List<Nachricht>();
    }
}
