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

         */
    }
}
