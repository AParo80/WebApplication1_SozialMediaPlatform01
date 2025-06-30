namespace WebApplication1_SozialMediaPlatform01.Models
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
Anzeige der letzten 5 geposteten CHhirps absteigend nahc dme Posting-Datum
3. Verfassen und Anzeigen von Chirps für angemeldete Benutzer:
- Verfassen von Nahcrichten mit max. 123 Zeichen
- Anzeigen der letzten 10 Chirps absteigend nach dme Posting-Datum
- Möglichkei, Chirps zu liken bzw zu entliken
- Filterfunktion für Chirps mit einem bestimmten Peep
4. Peeps:
- Hervorhebungvon Themen/Begriffen mit dem Schnabel-SZeichen(<>
- Extrakosten und gesonderte Speicherung beim Erstellen eines CHirps
- Anzeige der 5 häufigsten Peeps der letzten24 Stundne
Hinweis: ist die Anzahl an alphanumerischen Zeichen zu klein (mind. 3 Zeichen) oder zu groß (max 16.Zeichen), dann zählt der ganze Begriff NICHT als Peep.
 
Beispiel:  
Wish me <good<luck! <Softwarentwicklung <webdev <LAP
- Good (Peep endet nach dem „d“ das nächste Zeichen ist < kein alphanumerisches Zeichen)
- Luck >(„!“, ist kein alphanumerisches Zeichen)
- Webdev
- LAP
- Softwareentwicklung kein Peep, da merh als 16 Zeichen  
 
5. Benutzerprofile:
- Anzeige der fünf zuletzt verfassten Chirps
- Details zum Benutzer (wie Benutzername, Selbstbeschreibung und Registrierungsdatum)
- Anzahl  der gepsoteten Chirps
- Anzahl der vergebenen und enthaltenen Likes
 
teil 2:
Arbeitsanweisung:
1. Planung und Dokumentation
1.1 Anforderungsanalyse und Plannung
Verschaffen sie sich einen Überblick über die Anforderungen und erzeugen sie folgende Plannungsdokumente: -        skizze des Datenmodells (z:B der Er-diagramm )
- Skizze der geplanten Ansichten („fireframes“)
1.2 Dokumentation
Erstellen sie eine Dokumentation ihres Projekts mit folgenden inhalten:
- Datenbankdiagramm
- Kurzbeschreibung der wichtigsten Anwendungsbestandteile (zb über Controller, Services; max. 2 Sätze pro Teil
2. Umsetzung
Implementieren Sie die Anwendung nach der Fukntionsbeschreibung.
2.1 Basisfeatures
- Implementieren sie öffentlich erreichbare login- und registrieren-ansichten.
- Erlauben sie neuen benutzern, sich mit einer Kurzbeshcreibung zu registrieren.
- Ermöglichen sie dne login per email-adresse oder benutzername
2.2 Kernfeatures
- Ermöglichen sie angemeldeten Benutzern das verfassen neuer chirps.
- Stellen sie sicher, dass jeden chirps der benutzername des verfassers, den inhalt und die zeitliche Reichenfolge der Posts angezeigt werden.
- Implementieren sie einen intiutiven Userflow und klare Validierungrückmeldungen.
- Achten soe auf die einhaltung und sicherheitsstandards.
- Speichern und ermöglichen sie die filterung von Peeps.
2.3 erweiterte Features
- implementieren sie die funktion zum liken und ent-liken von chirps.
- Implementieren sie die anzeige der verwendeten Peeps.
- Erlauben sie die erreichbarkeit von benutzrprofilen durch anklicken eines Benutzernamens in einem Chirps
 








     */
    public class Angabe
    {
    }
}
