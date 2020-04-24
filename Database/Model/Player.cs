namespace werwolfonline.Database.Model
{
    public class Player
    {
        public int id { get; set; }
        public string name { get; set; }
        public int spielleiter { get; set; }
        public int lebt { get; set; }
        public int wahlAuf { get; set; }
        public int angeklagtVon { get; set; }
        public int nachtIdentitaet { get; set; }
        public int buergermeister { get; set; }
        public int hexeHeiltraenke { get; set; }
        public int hexeTodestraenke { get; set; }
        public int hexenOpfer { get; set; }
        public int hexeHeilt { get; set; }
        public int beschuetzerLetzteRundeBeschuetzt { get; set; }
        public int parErmEingesetzt { get; set; }
        public int verliebtMit { get; set; }
        public int jaegerDarfSchiessen { get; set; }
        public int buergermeisterDarfWeitergeben { get; set; }
        public int urwolf_anzahl_faehigkeiten { get; set; }
        public int dieseNachtGestorben { get; set; }
        public int countdownBis { get; set; }
        public int countdownAb { get; set; }
        public string playerlog { get; set; }
        public string popup_text { get; set; }
        public int bereit { get; set; }
        public int reload { get; set; }
        public int verifizierungsnr { get; set; }
    }
}