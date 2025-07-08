namespace WebApplication1_SozialMediaPlatform01.Docs
{
    public class WichtigeErkentnisse
    {
        /*
        zwischen Nachricht und Peep ist eine n - n Beziehung!
        n-n Beziehungen müssen immer aufgebrochen werden
        daher Nachricht - NachrichtPeep - Peep

        Client-Seitige validierung bedarf get statt POST. Mit Get funktioniert es nicht, zumindest bei mir!!!


        wenn man 2 _context.Add() hat AUFPASSEN! Meist genügt nur 1 weil es mit INCLUDE drinnen ist
         _context.Add(like);
         _context.Add(nachricht);

        in einer View: wenn man Inline HTML code braucht in einem text: @:<b>Text</b> --> @: bewirkt das html direkt ausgegeben wird

        Peep braucht ein DateTime das immer beim letzten mal überschreieben wird, wenn ein neuer Peep erstellt wird

        Die Peeps könnte man auch mit Linq-Lösen! (lt. Ingram)

        Liken auf einfach --> Eine Liste an User (mit Namen LikedList) in der Nachricht, da werden alle Nutzer gespeichert die die Nachricht geliket haben


         */
    }
}
