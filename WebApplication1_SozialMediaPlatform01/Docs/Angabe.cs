namespace WebApplication1_SozialMediaPlatform01.Docs
{

    /*
    
teil1:
Ausgangslage: Sie wurden beautragt eine sozial-media plattform zu entwickeln, die benutzer die registrierung und interaktion durch das verfassen von kurzen Nachrichten (Chirps) ermöglicht. Diesse applikation solll auf unterschiedlichen engeräten wie zb tabletets, mobilgeräten zum einsatz kommen.
 
Die plattform soll folgende Funktionalitäten umfassen:  Funktionsbeschreibung
1. Pflichtfelder:
- E-Mail-adresse,
- Benutzername (max. 16 alphanumerischen Zeichen, nur Buchstaben und Ziffern)
- Passwort
Optional: - Kurzbeschreibung (max. 300 Zeiichen)
Hinweis: Benutzer sollen sich sowohl mit email-adresse als auch miti Buenuutzernamen einloggen können.  Dabei sind aktuelle gängige Sicherheitsmaßnahmen und Passwortrihtlinien einzuhalten.
2. Anzeigen von Chirps für anonyme Benutzer: 
Anzeige der letzten 5 geposteten CHhirps absteigend nahc dme Posting-Datum --> OK
3. Verfassen und Anzeigen von Chirps für angemeldete Benutzer:
- Verfassen von Nahcrichten mit max. 123 Zeichen --> OK!
- Anzeigen der letzten 10 Chirps absteigend nach dme Posting-Datum --> OK!
- Möglichkei, Chirps zu liken bzw zu entliken    --> Liken --> OK!  Entliken --> TODO
- Filterfunktion für Chirps mit einem bestimmten Peep --> TodDo
4. Peeps:
- Hervorhebungvon Themen/Begriffen mit dem Schnabel-SZeichen(<>     --> OK!
- Extrakosten und gesonderte Speicherung beim Erstellen eines CHirps    --> Todo
- Anzeige der 5 häufigsten Peeps der letzten24 Stundne     *PeepController/haeufigstePeeps()*   -->Todo   --> Ich denke model gehört dafür geändert (in den Peeps die Zeit eintragen)
Hinweis: ist die Anzahl an alphanumerischen Zeichen zu klein (mind. 3 Zeichen) oder zu groß (max 16.Zeichen), dann zählt der ganze Begriff NICHT als Peep. --> OK!
 
Beispiel:  
Wish me <good<luck! <Softwarentwicklung <webdev <LAP
- Good (Peep endet nach dem „d“ das nächste Zeichen ist < kein alphanumerisches Zeichen)
- Luck >(„!“, ist kein alphanumerisches Zeichen)
- Webdev
- LAP
- Softwareentwicklung kein Peep, da merh als 16 Zeichen  
 
5. Benutzerprofile:
- Anzeige der fünf zuletzt verfassten Chirps --> ok 
- Details zum Benutzer (wie Benutzername, Selbstbeschreibung und Registrierungsdatum) --> ok!
- Anzahl  der gepsoteten Chirps     --> ok
- Anzahl der vergebenen und enthaltenen Likes  --> ok
 
teil 2:
Arbeitsanweisung:
1. Planung und Dokumentation
1.1 Anforderungsanalyse und Plannung
Verschaffen sie sich einen Überblick über die Anforderungen und erzeugen sie folgende Plannungsdokumente: -        skizze des Datenmodells (z:B der Er-diagramm ) --> OK!
- Skizze der geplanten Ansichten („fireframes“) --> OK!
1.2 Dokumentation
Erstellen sie eine Dokumentation ihres Projekts mit folgenden inhalten:
- Datenbankdiagramm -->OK!
- Kurzbeschreibung der wichtigsten Anwendungsbestandteile (zb über Controller, Services; max. 2 Sätze pro Teil --> TODO!!!!!!!!!!
2. Umsetzung
Implementieren Sie die Anwendung nach der Fukntionsbeschreibung.
2.1 Basisfeatures
- Implementieren sie öffentlich erreichbare login- und registrieren-ansichten.   --> OK!
- Erlauben sie neuen benutzern, sich mit einer Kurzbeshcreibung zu registrieren. --> OK!
- Ermöglichen sie dne login per email-adresse oder benutzername   -->OK!
2.2 Kernfeatures
- Ermöglichen sie angemeldeten Benutzern das verfassen neuer chirps.  -->OK!
- Stellen sie sicher, dass jeden chirps der benutzername des verfassers, den inhalt und die zeitliche Reichenfolge der Posts angezeigt werden. -->OK!
- Implementieren sie einen intiutiven Userflow und klare Validierungrückmeldungen.   -->????????????
- Achten soe auf die einhaltung und sicherheitsstandards.  --> OK!
- Speichern und ermöglichen sie die filterung von Peeps.   -->????????????????
2.3 erweiterte Features
- implementieren sie die funktion zum liken und ent-liken von chirps.   --------> TEILWEISE
- Implementieren sie die anzeige der verwendeten Peeps.  --> TODO
- Erlauben sie die erreichbarkeit von benutzrprofilen durch anklicken eines Benutzernamens in einem Chirps    --> TODO
 








     */
    public class Angabe
    {
    }
}
