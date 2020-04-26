using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace werwolfonline.Database.Utils
{
    public class CorrectHorseBatteryStaple
    {
        private readonly Dictionary<string, ulong> germanReverseLookup;

        public CorrectHorseBatteryStaple()
        {
            germanReverseLookup = germanWords.Select((word, i) => (word, i)).ToDictionary(k => k.word, v => (ulong)v.i);
        }

        public string ToGermanWords(ulong number)
        {
            var mod = (ulong)germanWords.Length;
            var words = new List<string>();
            while (number > 0)
            {
                var pos = number % mod;
                words.Add(germanWords[pos]);
                number = number / mod;
            }
            return string.Join("-", words);
        }

        public ulong FromGermanWords(string s)
        {
            var mod = (ulong)germanWords.Length;
            var words = s.Split('-');
            ulong result = 0;
            foreach (var word in words.Reverse())
            {
                ulong val;
                if (!germanReverseLookup.TryGetValue(word.ToLower(), out val))
                {
                    throw new ArgumentException($"Unknown word '{word}'.", "s");
                }
                result = result * mod + val;
            }
            return result;
        }

        // Source http://www.svenbuechler.de
        private string[] germanWords = new[]
        {
            "aachen", "abart", "abbau", "abbild", "abdomen", "abend", "abfall", "abflug", "abfuhr", "abgabe", "abgang", "abgas", "abgott", "abhang", "abitur", "abkehr", "abladen", "ablage", "ablass", "ablauf", "ablaut", "abluft", "abnorm", "abraum", "abrede", "abrieb", "abriss", "abruf", "abrupt", "absage", "absatz", "absurd", "abtei", "abteil", "abtun", "abweg", "abwehr", "abwurf", "abzug", "aceton", "achse", "achsel", "acht", "achten", "acker", "acryl", "adagio", "adel", "adeln", "ader", "adler", "adlig", "adrett", "adria", "advent", "adverb", "aegide", "aeon", "aerger", "aerob", "aesche", "aether", "aetzen", "affe", "affig", "affin", "afrika", "agent", "agieren", "agio", "agrar", "ahnen", "ahnung", "ahorn", "aids", "airbus", "akazie", "akkord", "akne", "akte", "akteur", "aktie", "aktion", "aktiv", "akut", "akzent", "alarm", "alaska", "albern", "albert", "albino", "album", "alge", "alias", "alibi", "allee", "allein", "alltag", "aloe", "alpen", "alpin", "altar", "altbau", "alter", "altern", "altoel", "amateur", "amboss", "ameise", "amme", "amoebe", "amok", "amor", "amorph", "ampel", "amsel", "analog", "ananas", "anatomie", "anbau", "andora", "anemone", "anfall", "anfang", "anflug", "angabe", "angel", "angeln", "angina", "angler", "angola", "angst", "anhang", "anis", "ankara", "ankauf", "anker", "ankern", "ankunft", "anlage", "anlass", "anlauf", "anlaut", "anmut", "anomalie", "anonym", "anorak", "anrede", "anreiz", "anruf", "ansage", "ansatz", "anteil", "anti", "antik", "antrag", "anwalt", "anzahl", "anzug", "aorta", "apart", "apfel", "apnoe", "appell", "april", "araber", "arbeit", "archiv", "arena", "arglos", "argon", "arie", "arktis", "armada", "armee", "armut", "aroma", "arrest", "arsch", "arsen", "artig", "artist", "arznei", "arzt", "asbest", "asche", "asien", "askese", "aspekt", "aspik", "asthma", "astral", "asyl", "atem", "athlet", "atlas", "atmen", "atmung", "atoll", "atom", "atomar", "attest", "aufbau", "aufruf", "aufzug", "auge", "augen", "august", "aula", "aura", "ausbau", "aushub", "ausruf", "aussen", "auster", "ausweg", "auszug", "autark", "auto", "autogen", "autor", "autsch", "azoren", "baby", "bach", "backen", "baden", "baer", "baff", "bagel", "bagger", "bahn", "bahre", "baku", "bald", "baldig", "balg", "balkan", "balken", "balkon", "ball", "ballade", "ballen", "ballon", "balsam", "bambus", "banal", "banane", "band", "bande", "bandit", "bange", "bangen", "bank", "banner", "barbar", "barde", "barock", "baron", "barren", "barsch", "bart", "basalt", "basar", "basic", "basis", "baske", "bass", "bast", "bastei", "batik", "bauamt", "bauart", "bauch", "baude", "bauen", "bauer", "baum", "bausch", "bauxit", "bauzaun", "bayer", "bayern", "beamter", "bebaut", "beben", "bebend", "becher", "becken", "bedarf", "bedenken", "beehren", "beeilen", "beere", "beet", "befehl", "befugt", "befund", "begabt", "begeben", "begehen", "beginn", "begraben", "beide", "beige", "beil", "beinah", "beirat", "beirrt", "beirut", "beiwort", "bejahen", "beladen", "belag", "beleben", "belegen", "bellen", "bemessen", "benehmen", "benennen", "bengel", "benzin", "benzol", "bequem", "bereit", "berg", "bergab", "bergan", "bergen", "berlin", "bern", "beruf", "besen", "besitz", "besser", "besuch", "beten", "beton", "betont", "betrag", "betrug", "bett", "beugen", "beule", "beulen", "beute", "beutel", "bevor", "beweis", "bezirk", "bezug", "bibel", "biber", "bieder", "biegen", "biene", "bier", "biest", "bieten", "bieter", "bigott", "bikini", "bilanz", "bilbao", "bild", "bilden", "billig", "binaer", "binde", "binden", "bingo", "binom", "binse", "biogas", "bionik", "biopsie", "bios", "birke", "birne", "bisher", "biss", "bistum", "bitmap", "bitte", "bitten", "bitter", "biwak", "bizarr", "bizeps", "blank", "blase", "blasen", "blass", "blatt", "blau", "blazer", "blech", "blei", "bleich", "blende", "blick", "blind", "blinde", "blitz", "block", "bloed", "blond", "bluete", "bluff", "blume", "bluse", "blut", "bluten", "blutig", "bochum", "bocken", "boden", "boerse", "boese", "bogen", "bogota", "bohle", "bohne", "bohnen", "bohren", "bohrer", "boje", "bolero", "bolzen", "bombe", "bomber", "bonbon", "bongo", "bonn", "bonus", "boom", "boot", "bord", "bordell", "boskop", "boss", "boston", "bote", "bowle", "boxen", "boxer", "bozen", "brand", "braten", "brauch", "braun", "bravo", "brei", "breiig", "breite", "bremen", "bremse", "brett", "brezel", "brie", "brief", "brille", "brise", "brokat", "brom", "bronze", "brot", "bruch", "bruder", "bruehe", "bruesk", "brunei", "brust", "brut", "brutal", "brutto", "buch", "buche", "buchen", "buchse", "buckel", "bude", "buegel", "buehne", "buerge", "buero", "bueste", "buett", "buhlen", "bukett", "bulle", "bund", "bunker", "bunny", "bunt", "busch", "busen", "butler", "butter", "bypass", "byte", "cabrio", "cache", "cafe", "cdrom", "chance", "chaos", "chef", "chemie", "chile", "chili", "china", "chinin", "chip", "chlor", "chor", "choral", "christ", "chrom", "chuzpe", "clever", "clique", "clogs", "cobalt", "code", "codec", "comic", "cookie", "coup", "coupon", "cousin", "cursor", "dabei", "dach", "dachs", "dackel", "dada", "daemmen", "daemon", "daene", "dafuer", "daheim", "daher", "dahlie", "dakar", "dallas", "damals", "damast", "dame", "damit", "damm", "dampf", "danach", "dank", "danke", "danken", "dann", "daran", "darauf", "daraus", "darf", "darin", "darm", "darum", "dasein", "dass", "datei", "daten", "dativ", "dato", "dattel", "datum", "dauer", "dauern", "daumen", "daune", "davon", "davor", "dazu", "debuet", "deck", "decke", "deckel", "decken", "defekt", "defizit", "degen", "dehnen", "deich", "dein", "deine", "dekade", "dekan", "dekor", "dekret", "delfin", "delikt", "delle", "demut", "denise", "denk", "denken", "denn", "dental", "denver", "depot", "depp", "derart", "derb", "deren", "despot", "dessen", "dessert", "desto", "detail", "deuten", "devot", "dezent", "diadem", "diaet", "diakon", "dialog", "dich", "dicht", "dichte", "dick", "dicker", "dieb", "diele", "dienen", "diener", "dienst", "dies", "diese", "diesel", "dieser", "dieses", "diffus", "diktat", "dill", "dimmer", "ding", "dingen", "dinkel", "diode", "dioxyd", "diplom", "direkt", "dirndl", "dirne", "diskus", "distel", "dito", "diva", "divers", "doch", "docht", "dock", "doesen", "dogge", "dohle", "doktor", "dolch", "dollar", "domino", "donau", "donner", "doof", "dopen", "doping", "doppel", "dorf", "dorn", "dornig", "dorsch", "dort", "dose", "dosis", "dotter", "draht", "drall", "drama", "drang", "dreck", "drehen", "drei", "dreist", "drift", "drill", "dritte", "droben", "droge", "drohen", "drops", "druck", "druese", "dublin", "ducken", "duebel", "duell", "duene", "duenn", "duerr", "duerre", "duese", "duester", "duett", "duft", "duften", "dulden", "dumm", "dumpf", "dung", "dunkel", "dunst", "duplex", "durch", "durst", "dusche", "dutt", "ebbe", "eben", "ebene", "ebenso", "eber", "ebnen", "echo", "echt", "echter", "echtes", "ecke", "eckig", "edamer", "edel", "editor", "egoist", "ehedem", "eher", "ehrbar", "ehre", "ehren", "ehrlos", "ehrung", "eibe", "eiche", "eichel", "eichen", "eier", "eifer", "eifern", "eifrig", "eigelb", "eigen", "eile", "eilen", "eilig", "eilzug", "eimer", "einbau", "einfach", "einheit", "einher", "einige", "einmal", "einoede", "einrad", "eins", "einsam", "einst", "einweg", "einzeln", "einzig", "einzug", "eisen", "eisern", "eisig", "eistee", "eitel", "eiter", "eitern", "eitrig", "ekel", "eklig", "elan", "elbe", "elch", "elend", "elfe", "elite", "elster", "eltern", "email", "emblem", "emirat", "empor", "empore", "emsig", "ende", "enden", "endlos", "endung", "engel", "enkel", "enorm", "ente", "entzug", "enzian", "enzym", "epilog", "episch", "epoche", "epos", "erbe", "erbin", "erbse", "erde", "erden", "erdgas", "erdig", "erdoel", "ereilen", "erfolg", "erfurt", "ergeben", "erguss", "erholen", "erker", "erlass", "erle", "erloes", "erneut", "ernst", "ernte", "ernten", "erregt", "ersatz", "erst", "erster", "erwerb", "esche", "esel", "espe", "essay", "essbar", "essen", "essenz", "essig", "etage", "etappe", "etat", "ethanol", "ethik", "etuede", "etui", "etwa", "etwaig", "etwas", "euer", "eule", "eunuch", "euro", "europa", "euter", "ewig", "ewige", "exakt", "examen", "exil", "exkurs", "export", "extern", "extra", "extrem", "exzess", "fabel", "fabrik", "fach", "fackel", "fade", "faden", "faehig", "faehre", "fagott", "fahl", "fahne", "fahren", "fahrer", "fahrt", "faible", "fair", "fakir", "fakt", "fakten", "faktor", "falke", "fall", "falle", "fallen", "falls", "falten", "falter", "faltig", "falz", "falzen", "famos", "fanal", "fand", "fang", "fangen", "farbe", "farbig", "farm", "farmer", "farn", "fasan", "faseln", "faser", "fass", "fassen", "fast", "fasten", "fatal", "faul", "faulen", "faulig", "faun", "fauna", "faust", "fazit", "feder", "fegen", "fehde", "fehl", "fehlen", "fehler", "fehlt", "feier", "feiern", "feige", "feile", "feilen", "fein", "feind", "feld", "felge", "fell", "fels", "felsig", "ferien", "ferkel", "fern", "ferne", "ferse", "fertig", "fesch", "fessel", "fest", "festtag", "fete", "fett", "fettig", "fetzen", "feucht", "feudal", "feuer", "feuern", "feurig", "fiasko", "fibel", "fichte", "fieber", "fiedeln", "fies", "figur", "fiktiv", "filet", "film", "filmen", "filter", "filz", "filzen", "fimmel", "finale", "finden", "findig", "finger", "fink", "finne", "finte", "firma", "firmen", "fisch", "fische", "fischt", "fiskus", "fjord", "flach", "flachs", "flagge", "flakon", "flamme", "flanke", "flansch", "flau", "flaum", "flaute", "fleck", "flegel", "flehen", "fleht", "flehte", "fleiss", "flieder", "fliege", "flink", "flinte", "flirt", "flocke", "floete", "floez", "floh", "flora", "flosse", "flott", "flotte", "fluch", "flucht", "fluege", "flug", "flugs", "flur", "fluss", "flut", "foehn", "foetus", "fohlen", "fokus", "folgen", "folie", "folter", "fondue", "foppen", "form", "formal", "format", "formel", "formen", "forsch", "fort", "fortan", "forum", "fossil", "fracht", "frack", "fraese", "fraest", "frage", "fragen", "frager", "fragt", "fragte", "franko", "franse", "frass", "fratze", "frau", "frauen", "freak", "frech", "frei", "fremd", "fresko", "freu", "freund", "frevel", "fries", "friede", "frisch", "frist", "frisur", "frivol", "froh", "fromm", "front", "frosch", "frost", "frucht", "frueh", "fuchs", "fuelle", "fuenf", "fuer", "fuge", "fugen", "fuhr", "fuhre", "fund", "fundus", "funke", "furche", "furcht", "furie", "fuss", "fussel", "futsch", "futter", "fuzzy", "gabel", "gabeln", "gabun", "gaele", "gaemse", "gaeren", "gaffen", "gaffer", "gage", "gala", "galant", "galgen", "galle", "gallen", "gallig", "galopp", "gambia", "gambit", "gamma", "gammler", "gang", "ganove", "gans", "ganz", "garage", "garant", "garbe", "garde", "garn", "garten", "gasse", "gast", "gatte", "gatter", "gattin", "gaudi", "gaul", "gaumen", "gauner", "geben", "gebiet", "gebiss", "geburt", "geck", "gecko", "geduld", "gefahr", "gefiel", "gegen", "gegend", "gegner", "gehalt", "gehege", "geheim", "gehen", "geheul", "gehirn", "gehoer", "geholt", "gehren", "gehweg", "geier", "geige", "geiger", "geisel", "geiz", "geizen", "geizig", "gelage", "gelb", "geld", "gelder", "gelee", "gelege", "geleit", "gelenk", "gelten", "gemalt", "gemein", "gemuet", "genau", "genese", "genial", "genick", "genie", "genius", "genre", "genua", "genug", "genus", "genuss", "george", "gepard", "gerade", "geraet", "gerben", "gerber", "gerede", "gering", "gern", "gerne", "gerste", "gerte", "geruch", "gesamt", "gesang", "gesetz", "geste", "gesuch", "gesund", "getto", "getue", "gewahr", "gewalt", "gewand", "gewebe", "gewehr", "geweih", "gewinn", "gewirr", "gewiss", "ghana", "gibbon", "gicht", "giebel", "gier", "gieren", "gierig", "gift", "giftig", "gigant", "gigolo", "gilde", "gipfel", "gips", "gischt", "gitter", "glanz", "glas", "glaser", "glasig", "glasur", "glatt", "glatte", "glatze", "glaube", "glauben", "gleich", "gleis", "gleit", "gleite", "gleiten", "glied", "global", "globus", "glocke", "glossar", "glosse", "glotze", "glucke", "glueck", "glukose", "glut", "gnade", "gneis", "gnom", "goetze", "gold", "golden", "golf", "gondel", "gong", "gospel", "gosse", "gotik", "gott", "grab", "graben", "grad", "graf", "grafik", "gram", "gramm", "granat", "granit", "gras", "grasen", "grat", "gratis", "grau", "gravur", "greis", "grell", "grenze", "grill", "grille", "grippe", "grips", "grob", "grog", "groll", "grotte", "grube", "gruen", "grufti", "grund", "gruppe", "gruss", "gucken", "gummi", "gunst", "gurke", "gurren", "gurt", "guru", "gute", "guten", "guter", "guyana", "haar", "haarig", "haben", "hacke", "hacken", "hacker", "haerte", "haeufig", "haeuser", "hafen", "hafer", "haft", "haften", "hagel", "hageln", "hagen", "hager", "hahn", "hain", "haiti", "haken", "halb", "halbgar", "halde", "halle", "hallo", "halm", "halme", "hals", "halse", "halsen", "halt", "halten", "hammel", "hammer", "hand", "handel", "hanf", "hang", "hanoi", "hans", "hanse", "hantel", "harem", "harfe", "harke", "harken", "hart", "harz", "harzig", "hase", "hass", "hassen", "hasten", "hastet", "hastig", "haube", "hauch", "hauen", "haufen", "haupt", "haus", "hawaii", "hebel", "hebeln", "heben", "hecht", "heck", "hecke", "heer", "hefe", "hefig", "hefte", "heftig", "heide", "heikel", "heil", "heilen", "heiler", "heilig", "heilige", "heilung", "heim", "heimat", "heirat", "heiser", "heiter", "heizen", "heizer", "hektar", "hektik", "held", "heldin", "helfen", "helfer", "helium", "hell", "helm", "hemd", "hemmen", "hengst", "henkel", "henker", "henne", "herauf", "heraus", "herb", "herbst", "herd", "herde", "herein", "hering", "herold", "herpes", "herr", "herrin", "herum", "hervor", "herz", "herzig", "herzog", "hesse", "hessen", "hetze", "hetzen", "hetzte", "heuer", "heulen", "heute", "hexe", "hieb", "hier", "hierzu", "hiesig", "hilfe", "hilflos", "himmel", "hinab", "hinauf", "hinaus", "hinken", "hinkt", "hinten", "hinter", "hippie", "hirsch", "hirse", "hirt", "hitze", "hitzig", "hobby", "hobel", "hobeln", "hoch", "hocken", "hocker", "hockey", "hoehe", "hoehle", "hoelle", "hoerbar", "hoeren", "hoerer", "hoffen", "hoheit", "hoher", "hohes", "hohl", "hohn", "hold", "holen", "holm", "holz", "hong", "honig", "hopfen", "hoppla", "horde", "hormon", "horn", "horst", "hort", "horten", "hose", "hotel", "huefte", "huegel", "huelle", "huelse", "huerde", "hueten", "hueter", "huette", "huhn", "human", "humbug", "hummel", "hummer", "humor", "humus", "hund", "hunger", "hupe", "hupen", "hurra", "hurtig", "husar", "husten", "hybrid", "hymne", "ideal", "idee", "ideell", "idiot", "idol", "idylle", "igel", "iglu", "ikone", "ileus", "illegal", "iltis", "image", "imbiss", "imker", "immer", "immun", "impfen", "import", "impuls", "indem", "inder", "index", "indien", "indigo", "info", "ingwer", "inhalt", "inka", "innen", "innung", "insekt", "insel", "insult", "intakt", "intern", "invers", "irak", "iraker", "iran", "iraner", "irisch", "irland", "ironie", "irre", "irreal", "irren", "irrig", "irrtum", "irrweg", "island", "isotop", "israel", "jacke", "jade", "jaeger", "jaeten", "jagd", "jagen", "jaguar", "jahr", "jammer", "januar", "japan", "jargon", "jasmin", "jauche", "jaulen", "jawohl", "jawort", "jazz", "jeans", "jemals", "jemand", "jemen", "jetlag", "jetset", "jetzt", "jodeln", "jodler", "joga", "joggen", "johlen", "joint", "jolle", "jordan", "jota", "joule", "jubel", "jubeln", "jucken", "jude", "juedin", "jugend", "juli", "julius", "jung", "junge", "juni", "junker", "junkie", "junta", "jura", "jurist", "jury", "justiz", "jute", "juwel", "kabel", "kabine", "kabul", "kachel", "kadaver", "kadenz", "kader", "kadett", "kaefer", "kaefig", "kaelte", "kaese", "kaff", "kaffee", "kahl", "kahn", "kaiser", "kajak", "kakadu", "kakao", "kaktee", "kalb", "kalben", "kalif", "kalium", "kalk", "kalt", "kamel", "kamera", "kamin", "kamm", "kammer", "kampf", "kanada", "kanal", "kandis", "kanne", "kanone", "kansas", "kante", "kanton", "kantor", "kanu", "kanzel", "kappe", "kapsel", "kaputt", "karat", "karate", "karbon", "karo", "karre", "karte", "kartei", "karton", "kasino", "kasse", "kassel", "kaste", "katar", "kater", "katode", "katze", "kauen", "kauern", "kauf", "kaufen", "kaum", "kausal", "kauz", "kaviar", "kebab", "keck", "kegel", "kegeln", "kegler", "kehle", "kehrer", "keifen", "keil", "keim", "keimen", "kein", "keine", "keinen", "keiner", "keks", "kelch", "kelle", "keller", "kelte", "kenia", "kennen", "kenner", "kerbe", "kerbel", "kerker", "kerl", "kern", "kernig", "kerze", "kessel", "kette", "ketzer", "keule", "keusch", "kiefer", "kiel", "kieme", "kies", "kiesel", "kilo", "kimme", "kind", "kinn", "kino", "kippe", "kippen", "kirche", "kirmes", "kissen", "kiste", "kitsch", "kitt", "kittel", "kitten", "kitz", "kladde", "klage", "klagen", "klamm", "klampe", "klan", "klang", "klappe", "klaps", "klar", "klasse", "klaue", "klauen", "klause", "kleben", "kleber", "klecks", "klee", "kleid", "kleie", "klein", "klemme", "klette", "klick", "klient", "kliff", "klima", "klinge", "klinik", "klinke", "klippe", "kloake", "klon", "klonen", "klotz", "klub", "kluft", "klug", "knabe", "knall", "knapp", "knappe", "knarre", "knast", "knebel", "knecht", "kneipe", "knete", "kneten", "knick", "knie", "kniff", "knilch", "knirps", "knolle", "knopf", "knospe", "knoten", "knut", "knute", "kobalt", "kobold", "koch", "kochen", "kodex", "koeder", "koeln", "koenig", "koeter", "koffer", "kognak", "kohl", "kohle", "kohorte", "koitus", "koje", "kojote", "kokain", "kokett", "kokon", "koks", "kolben", "kolik", "kollege", "koller", "koloss", "komet", "komm", "komma", "kommen", "kondor", "konsul", "konsum", "konter", "konto", "kontor", "kontra", "kopf", "kopie", "koppel", "koran", "korb", "kord", "kordel", "korea", "korfu", "kork", "korken", "korn", "kosmos", "kosovo", "kost", "kosten", "kostuem", "krabbe", "krach", "kraehe", "kraft", "kragen", "krake", "kralle", "krampf", "kran", "krank", "kranke", "kranz", "krass", "krater", "kratze", "kraus", "kraut", "krebs", "kredit", "kreide", "kreis", "kreml", "krempe", "krepp", "kresse", "kreta", "kreuz", "krieg", "krim", "krimi", "kripo", "krippe", "krise", "kritik", "kroete", "krokus", "krone", "kropf", "krug", "krumm", "kruste", "krypta", "kuala", "kuba", "kubist", "kuchen", "kuebel", "kueche", "kuehn", "kueken", "kuer", "kueren", "kuerze", "kufe", "kugel", "kulanz", "kuli", "kult", "kultur", "kummer", "kumpan", "kumpel", "kunde", "kundig", "kunst", "kupfer", "kuppel", "kurbel", "kurie", "kurier", "kurort", "kurs", "kursiv", "kurve", "kurz", "kurzum", "kuss", "kutte", "kuweit", "labern", "labil", "labor", "lache", "lachen", "lachs", "lacht", "lack", "lade", "laden", "lader", "ladung", "laenge", "laengs", "laerm", "lage", "lager", "lagern", "lagos", "lagune", "lahm", "laib", "laich", "laie", "lakai", "lake", "laken", "lamm", "lampe", "land", "landen", "lang", "lange", "lanze", "laos", "laote", "lappen", "laptop", "larve", "larven", "lasch", "lasche", "laser", "lassen", "lasso", "last", "laster", "lasur", "latein", "latent", "laub", "laube", "lauern", "lauf", "laufen", "lauge", "laune", "launig", "laus", "lausig", "laut", "lava", "lawine", "layout", "lebe", "leben", "lebend", "leber", "leblos", "lebst", "lebt", "leck", "lecken", "lecker", "leder", "ledern", "ledig", "leer", "leere", "leeren", "legal", "legen", "leger", "legion", "leguan", "lehen", "lehm", "lehmig", "lehne", "lehnen", "lehr", "lehre", "lehren", "lehrer", "leib", "leiche", "leicht", "leid", "leiden", "leider", "leier", "leihe", "leihen", "leim", "leimen", "leine", "leinen", "leise", "leiten", "leiter", "lektor", "lemma", "lena", "lende", "lenken", "lepra", "lerche", "lernen", "lesart", "lesbar", "lese", "lesen", "leser", "lesung", "lette", "leute", "level", "lewis", "libero", "libido", "libyen", "libyer", "licht", "lieb", "liebe", "lieben", "lied", "liege", "liegen", "lieh", "lies", "lift", "liga", "likoer", "lila", "lilie", "lima", "limbo", "limes", "linde", "lineal", "linear", "linie", "linke", "links", "linse", "linux", "lippe", "liste", "listig", "litauer", "liter", "lizenz", "loben", "loch", "lochen", "locke", "locken", "locker", "loesen", "loeten", "logik", "logo", "lohn", "loipe", "lokal", "london", "lore", "lose", "losung", "lotion", "lotse", "loyal", "luanda", "luchs", "luecke", "luege", "luegen", "luft", "luftig", "luftweg", "luftzug", "luke", "lunch", "lunge", "lupe", "lurch", "lust", "lustig", "lustlos", "luxus", "lyrik", "maat", "machen", "macho", "macht", "macke", "made", "madig", "madrid", "maedel", "maehen", "maehne", "maerz", "mafia", "magd", "mager", "magie", "magnat", "magnet", "mahl", "mahlen", "mahnen", "maid", "mainz", "mais", "major", "makel", "makler", "makro", "malawi", "malen", "maler", "malta", "malve", "malz", "malzig", "mammon", "mammut", "mampf", "mandat", "mandel", "manege", "mangan", "mangel", "mango", "manie", "manila", "manko", "mann", "mantel", "manual", "mappe", "marder", "marine", "mark", "marke", "markt", "marmor", "marone", "mars", "marsch", "marter", "masche", "masern", "maske", "masse", "massig", "massiv", "mast", "matrix", "matsch", "matt", "matte", "mauer", "mauern", "maul", "maurer", "maus", "medley", "meer", "mega", "mehl", "mehr", "meiden", "meile", "meiler", "meise", "meist", "mekka", "mekong", "melden", "meldung", "melken", "melone", "menge", "mensa", "mensch", "mensur", "mental", "mentor", "menue", "merken", "merkur", "messbar", "messe", "messen", "metall", "meteor", "meter", "methan", "metier", "metro", "meute", "mexiko", "miami", "miauen", "mieder", "mief", "miene", "mies", "miete", "mieten", "mieter", "mietze", "mikron", "milano", "milbe", "milch", "mild", "milieu", "miliz", "milz", "mimik", "mimisch", "mimose", "minder", "mine", "minsk", "minus", "minute", "minze", "misch", "mist", "mistel", "mittag", "mitte", "mittel", "mittig", "mixer", "mobil", "mobile", "modal", "mode", "modell", "modem", "moder", "modern", "modrig", "modul", "modus", "moebel", "moegen", "moehre", "moench", "moewe", "mofa", "mogeln", "mogul", "moldau", "mole", "molke", "moll", "mollig", "moment", "monaco", "monat", "mond", "monsun", "montag", "moor", "moos", "moped", "mops", "moral", "morast", "morbid", "mord", "morden", "morgen", "mosaik", "moskva", "moslem", "most", "motel", "motiv", "motor", "motte", "motto", "mousse", "muecke", "muede", "muehe", "muehle", "muell", "mueller", "muendig", "muenze", "muerbe", "muetze", "muff", "mulch", "mulde", "mull", "mumbai", "mumie", "mund", "munter", "murmel", "murren", "muse", "museum", "musik", "musiker", "muskat", "muskel", "muster", "mutig", "mutlos", "mutter", "mutti", "mythos", "nabe", "nabel", "nach", "nacht", "nachts", "nacken", "nackt", "nadel", "naehe", "naehen", "naesse", "nagel", "nageln", "nahe", "nahen", "nahend", "nahezu", "nahost", "naiv", "name", "nanu", "napalm", "napf", "napoli", "nasal", "nase", "nass", "nassau", "nation", "nato", "natter", "natur", "nebel", "neben", "neblig", "necken", "neffe", "nehmen", "neid", "neigen", "nein", "nektar", "nelke", "nennen", "nenner", "neon", "nepal", "neptun", "nerv", "nerven", "nerz", "nessel", "nest", "nett", "netto", "netz", "neubau", "neun", "neural", "neuron", "nicht", "nichte", "nichts", "nickel", "nicken", "nieder", "niere", "nieren", "niesen", "niete", "nippel", "nippen", "nippt", "nische", "nisten", "nistet", "nixe", "nizza", "nobel", "noch", "noetig", "nomade", "noppe", "norden", "norm", "normal", "notar", "note", "notiz", "notruf", "nougat", "nudel", "null", "nummer", "nuss", "nussig", "nutzen", "nutzer", "nylon", "oase", "obdach", "oben", "obenab", "ober", "objekt", "oblate", "oboe", "obst", "obwohl", "ochse", "ocker", "oder", "odessa", "oedem", "oeffne", "oelbad", "oelen", "oese", "ofen", "offen", "ohio", "ohne", "oktave", "okular", "olive", "omen", "omsk", "onkel", "opal", "oper", "opfer", "opfern", "opium", "optik", "option", "opus", "orakel", "oral", "orange", "orden", "ordnen", "ordner", "oregon", "organ", "orgel", "orient", "orion", "orkan", "orten", "ortung", "osaka", "oslo", "osmose", "ossi", "osten", "ostern", "ostsee", "ottawa", "otter", "oval", "oxid", "ozean", "ozelot", "ozon", "paar", "paaren", "pacht", "pack", "packen", "paddel", "paella", "paffen", "pagode", "paket", "pakt", "palast", "palau", "palme", "pampa", "pampe", "panama", "panda", "panik", "panne", "pansen", "panter", "panzer", "papa", "papaya", "papel", "papier", "pappe", "pappel", "papst", "papua", "parade", "park", "parka", "parken", "parole", "partei", "partie", "pass", "passen", "passiv", "paste", "pastor", "patch", "pate", "patent", "pater", "patin", "patna", "patt", "patzer", "patzig", "pauke", "pauken", "pause", "pausen", "pavian", "pech", "pedant", "pegel", "pein", "pelz", "pendel", "penne", "pensum", "perle", "perser", "person", "perth", "peru", "pest", "peter", "petrus", "petzen", "pfad", "pfahl", "pfand", "pfanne", "pfau", "pfeife", "pfeil", "pferd", "pfiff", "pflege", "pflug", "pfote", "pfropf", "pfuhl", "pfui", "pfund", "pfusch", "phase", "phobie", "phrase", "physik", "pickel", "picken", "piepen", "pikant", "pilger", "pille", "pilz", "pinie", "pinne", "pinsel", "pipi", "pirat", "pirsch", "piste", "pizza", "plage", "plagiat", "plakat", "plan", "plane", "planen", "planet", "planke", "plasma", "platin", "platt", "platte", "platz", "pleite", "plenum", "plombe", "plugin", "plump", "plus", "pluto", "pocke", "pocken", "podest", "podium", "poebel", "poesie", "poet", "pogrom", "pokal", "pole", "polen", "polka", "pollen", "poller", "polo", "polung", "pomade", "pomp", "poncho", "pony", "popo", "pore", "port", "portal", "porto", "pose", "posen", "posse", "possen", "post", "posten", "poster", "postum", "potent", "potenz", "pracht", "prall", "praxis", "preis", "preise", "presse", "prima", "prinz", "prise", "prisma", "privat", "probe", "proben", "profan", "profi", "profil", "profit", "prolog", "prompt", "propan", "prosa", "pruede", "prunk", "psalm", "pseudo", "psyche", "pudel", "puder", "pudern", "pulk", "puls", "pult", "pulver", "puma", "pumpe", "pumpen", "pumps", "punkt", "puppe", "purist", "purpur", "pustel", "putz", "putze", "putzen", "puzzle", "python", "quader", "quaken", "qual", "qualle", "qualm", "quark", "quarz", "quelle", "quer", "queren", "quiz", "quoll", "quote", "rabatt", "rabatz", "rabe", "rabiat", "rache", "rachen", "racker", "radar", "radau", "radial", "radio", "radium", "radius", "radler", "radon", "radweg", "rage", "ragen", "ragout", "rahm", "rahmen", "raichu", "rakel", "rakete", "rallye", "ramme", "rammen", "rammler", "rampe", "ranch", "rand", "rang", "range", "rank", "ranke", "ranzen", "ranzig", "raps", "rasant", "rasch", "rasen", "raser", "raserei", "raspel", "rasse", "rassel", "rassig", "rast", "raste", "rasten", "rasur", "rate", "raten", "ration", "ratlos", "ratsam", "ratte", "raub", "rauben", "rauch", "raufe", "raufen", "rauhe", "rauher", "raum", "raupe", "rausch", "razzia", "rebe", "rebell", "rechen", "recht", "rechts", "rede", "reden", "redner", "reeder", "reell", "reflex", "reform", "regal", "rege", "regel", "regeln", "regen", "regent", "reggae", "regie", "regime", "region", "regler", "regnen", "regung", "reiben", "reich", "reif", "reife", "reifen", "reihe", "reiher", "reihum", "reim", "reimt", "reis", "reise", "reisen", "reiten", "reiter", "reiz", "reizen", "rekeln", "rekord", "rekrut", "rektor", "relais", "relief", "relikt", "reling", "remis", "renin", "renn", "rennen", "rente", "replik", "reptil", "rest", "reste", "retour", "retten", "reue", "reuig", "reuse", "revier", "revue", "rezept", "rhein", "rheuma", "riege", "riegel", "riemen", "ries", "riese", "riff", "riga", "rille", "rind", "rinde", "ring", "ringen", "rinne", "rinnen", "rippe", "risiko", "rispe", "riss", "ritt", "ritter", "ritual", "ritus", "ritz", "ritzen", "rivale", "robbe", "robe", "robust", "rocker", "rocky", "rodeln", "roden", "rodeo", "rodung", "roehre", "roggen", "rohbau", "rohoel", "rohr", "rolle", "rollen", "romeo", "rosa", "rose", "rosig", "rosine", "ross", "rost", "rosten", "rotte", "rottet", "route", "router", "ruanda", "rubel", "rubin", "rubrik", "ruck", "rucken", "rudel", "ruder", "rudern", "ruebe", "rueck", "ruede", "ruegen", "ruesten", "rufen", "ruhe", "ruhen", "ruhig", "ruhm", "ruhr", "ruin", "ruine", "rummel", "rumpf", "rund", "runde", "runden", "rune", "rupfen", "rupie", "russ", "russe", "russig", "rute", "rutsch", "saal", "sabbat", "sacha", "sache", "sachen", "sachse", "sachte", "sack", "sacken", "sadist", "saebel", "saege", "saegen", "saeule", "saeure", "safari", "safran", "saft", "saftig", "sage", "sagen", "sahnig", "sahnt", "saite", "salami", "salat", "salbe", "salbei", "saldo", "saline", "salm", "salon", "salopp", "salto", "salut", "salve", "salz", "salzen", "salzig", "samen", "samoa", "samt", "sand", "sandig", "sanft", "sarg", "satin", "satire", "satt", "sattel", "saturn", "satz", "satzbau", "sauber", "saudi", "sauer", "saufen", "saugen", "saum", "sauna", "sausen", "scampi", "schabe", "schach", "schade", "schaf", "schah", "schal", "schale", "schall", "scham", "schar", "scharf", "schatz", "schaum", "scheck", "schein", "scheit", "schelm", "schema", "schere", "scherz", "scheu", "schick", "schieb", "schief", "schien", "schiff", "schild", "schilf", "schirm", "schlaf", "schlag", "schlau", "schmal", "schmerz", "schnee", "schnur", "schock", "schoen", "schon", "schopf", "schorf", "schott", "schrei", "schrot", "schuft", "schuh", "schuld", "schule", "schund", "schuss", "schutt", "schutz", "schwan", "schwer", "schwur", "sechs", "seebad", "seele", "seenot", "seeweg", "segel", "segeln", "segen", "segler", "segnen", "sehen", "sehne", "sehr", "seicht", "seide", "seiden", "seidig", "seife", "seil", "seiler", "seit", "seite", "sekret", "sekt", "sekte", "selten", "semit", "senat", "senden", "sender", "senf", "sengen", "senior", "senke", "sense", "serbe", "sermon", "serum", "sesam", "sessel", "setzen", "setzer", "seuche", "sichel", "sicher", "sicht", "sieb", "sieben", "sieden", "sieg", "siegel", "siegen", "sieger", "sierra", "signal", "silbe", "silber", "singen", "sinken", "sinn", "sippe", "sirene", "sirup", "sitte", "sitz", "sitzen", "skala", "skalp", "skat", "sketch", "skizze", "sklave", "slalom", "slang", "slum", "smog", "snob", "socke", "sockel", "soda", "sofa", "sofia", "sofort", "sogar", "sohle", "sohn", "soja", "sold", "soldat", "solide", "solist", "sollen", "solo", "sommer", "sonate", "sonde", "sonett", "sonne", "sonnen", "sonnig", "sonst", "sopran", "sorbet", "sorge", "sorgen", "sorte", "soul", "south", "sowjet", "sowohl", "sozial", "spaet", "spalt", "spange", "spanne", "sparen", "sparer", "spaten", "spatz", "specht", "speck", "speer", "speise", "spende", "sperre", "sphinx", "spiegel", "spiel", "spiess", "spike", "spinal", "spinat", "spinne", "spion", "spital", "spitz", "spitze", "spleen", "splint", "splitt", "sport", "spott", "spray", "spreu", "sprit", "sproed", "spruch", "sprung", "spuele", "spuk", "spuken", "spule", "spur", "staat", "stab", "stabil", "stadt", "stahl", "stall", "stamm", "stand", "stange", "stanze", "stapel", "stark", "starr", "start", "statik", "statur", "status", "statut", "stau", "staub", "stauen", "stauer", "steak", "steg", "stehen", "steif", "steig", "stein", "stele", "stelle", "stelze", "steppe", "steppen", "steril", "stern", "steuer", "stich", "stiel", "stier", "stift", "stigma", "stil", "still", "stille", "stimme", "stirn", "stock", "stoer", "stoff", "stola", "stolz", "stopp", "storch", "strafe", "straff", "strahl", "stramm", "strand", "strang", "straps", "strebe", "streik", "streit", "streng", "stress", "streut", "strich", "strick", "strikt", "stroh", "strom", "student", "studie", "stueck", "stufe", "stuhl", "stumm", "stumpf", "stunde", "stur", "sturm", "sturz", "stute", "subtil", "suche", "suchen", "sudan", "sudeln", "sueden", "suehne", "suelze", "suende", "suhlen", "suite", "sulfat", "sultan", "summe", "summen", "sumo", "sumpf", "sund", "super", "suppe", "surren", "sydney", "symbol", "synode", "syntax", "syrien", "system", "szene", "tabak", "tadel", "tadeln", "taeter", "taetig", "tafel", "taft", "tagen", "tagung", "taifun", "taille", "taiwan", "takt", "taktik", "talent", "talg", "tandem", "tango", "tank", "tanken", "tanker", "tanne", "tante", "tanz", "tanzen", "tapete", "tapfer", "tapsen", "tara", "tarif", "tarnen", "tarock", "tartan", "tasche", "tasse", "taste", "tasten", "tatort", "taub", "taube", "taufe", "taufen", "taugen", "tausch", "taxi", "teer", "teeren", "teflon", "teich", "teig", "teil", "teilen", "teller", "tempel", "tempo", "tender", "tennis", "tenor", "termin", "terror", "test", "testen", "teuer", "teufel", "texas", "text", "texter", "textil", "theist", "theke", "thema", "themse", "therme", "these", "thron", "tibet", "ticken", "tief", "tiefe", "tiegel", "tier", "tiger", "tilgen", "tinte", "tipp", "tippen", "tirade", "tirana", "tirol", "tisch", "titan", "titel", "toben", "tobend", "toenen", "tofu", "togo", "tokyo", "toll", "tollen", "tomate", "tonart", "tonlos", "tonne", "tonsur", "topf", "torf", "torlos", "torte", "total", "toupet", "tour", "toxin", "trab", "tracht", "traege", "traene", "trage", "tragen", "tragik", "trakt", "trance", "trank", "trapez", "traube", "trauen", "trauer", "traufe", "traum", "trauma", "trend", "trennt", "treppe", "tresor", "treten", "treu", "treue", "trick", "trieb", "trikot", "trimm", "trinkt", "trist", "trog", "troja", "tropf", "trost", "trott", "trotz", "truebe", "trug", "trumpf", "truppe", "tschad", "tuba", "tube", "tuch", "tuell", "tuelle", "tuer", "tuerke", "tugend", "tulpe", "tumor", "tundra", "tunika", "tunis", "tunnel", "tupel", "turban", "turbo", "turm", "turnen", "tusche", "ubahn", "uboot", "uebel", "ueben", "ueber", "uebung", "uganda", "ulkig", "ulme", "umbau", "umfang", "umfeld", "umhang", "umkehr", "umlage", "umlauf", "umlaut", "umluft", "umriss", "umsatz", "umweg", "umwelt", "umzu", "umzug", "unart", "undank", "uneben", "unecht", "unfair", "unfall", "unfein", "unfug", "ungarn", "ungern", "ungute", "unheil", "union", "unklar", "unklug", "unlieb", "unmut", "unreif", "unrein", "unruh", "unruhe", "unsinn", "unstet", "untat", "unten", "untier", "untreu", "unweit", "unwohl", "unzahl", "unzart", "unze", "uralt", "uran", "uranus", "urban", "urform", "urlaub", "urne", "urteil", "urwald", "urzeit", "utopie", "vage", "vakuum", "valenz", "vampir", "vasall", "vase", "vater", "vektor", "vene", "ventil", "venus", "verb", "verein", "verlag", "verrat", "verruf", "vers", "versatz", "verzug", "video", "vieh", "vier", "villa", "vinyl", "viper", "virus", "visage", "vision", "visum", "vogel", "vogt", "volk", "voll", "volt", "voodoo", "vorbau", "vorfall", "vorhof", "vorhut", "vorlaut", "vorort", "vorrat", "vorzug", "vulkan", "waage", "wabe", "wach", "wache", "wachen", "wachs", "wacht", "wacker", "wade", "waegen", "waerme", "waffe", "waffel", "wagen", "waggon", "wagnis", "wahl", "wahn", "wald", "wall", "wallis", "walze", "walzen", "walzer", "wand", "wandel", "wange", "wanken", "wanze", "wappen", "ware", "waren", "warm", "warnen", "warze", "wasser", "waten", "watt", "watte", "weben", "weber", "wecken", "wecker", "wedeln", "wehmut", "weich", "weiche", "weide", "weiden", "weidend", "weihe", "wein", "weinen", "weise", "weiss", "weit", "weizen", "welk", "welken", "welle", "welpe", "welt", "wende", "wenden", "werben", "werber", "werde", "werden", "werfen", "werk", "wert", "wesen", "wesir", "wespe", "wessen", "weste", "westen", "wette", "wetten", "wetter", "wetzen", "whisky", "wicht", "widder", "widmen", "widrig", "wiege", "wiegen", "wien", "wiese", "wiesel", "wigwam", "wild", "wille", "wimmern", "wimper", "wind", "winde", "windel", "winden", "windig", "wink", "winkel", "winken", "winter", "winzig", "wipfel", "wippen", "wirbel", "wirken", "wirr", "wirt", "wirtin", "wisent", "wissen", "witwe", "witwer", "witz", "witzig", "woche", "wodka", "woge", "wogen", "wohnen", "wolf", "wolga", "wolke", "wolkig", "wolle", "wollen", "wonne", "wort", "wucher", "wucht", "wuerde", "wuerzen", "wueste", "wund", "wunde", "wunder", "wunsch", "wurf", "wurm", "wurst", "wurzel", "yeti", "yoga", "zackig", "zaeh", "zaehne", "zaeunt", "zagreb", "zahl", "zahm", "zahn", "zange", "zank", "zanken", "zapfen", "zarge", "zart", "zaster", "zauber", "zaum", "zaun", "zebra", "zechen", "zecke", "zeder", "zehe", "zehn", "zehren", "zeigen", "zeile", "zeit", "zelle", "zelt", "zelten", "zement", "zensur", "zepter", "zerren", "zettel", "zeug", "zeuge", "zicke", "zickig", "ziege", "ziegel", "zieh", "ziehe", "ziehen", "ziel", "zielen", "zierde", "ziffer", "zimmer", "zimt", "zink", "zinn", "zins", "zirkus", "zirpen", "zischen", "zitat", "zitrus", "zivil", "zobel", "zofe", "zoll", "zombie", "zonal", "zone", "zorn", "zucht", "zucken", "zucker", "zuegel", "zufall", "zugabe", "zugang", "zugig", "zulage", "zulauf", "zuluft", "zumal", "zuname", "zunder", "zunft", "zunge", "zupfen", "zurren", "zuruf", "zusage", "zusatz", "zutat", "zuzug", "zwang", "zweck", "zwei", "zweig", "zwerg", "zwirn", "zwist", "zwoelf", "zyklus", "zypern"};
    }
}