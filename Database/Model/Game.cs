namespace werwolfonline.Database.Model
{
    public class Game
    {
        public int spielphase { get; set; }
        public int charaktereAufdecken { get; set; }
        public int buergermeisterWeitergeben { get; set; }
        public int seherSiehtIdentitaet { get; set; }
        public int werwolfzahl { get; set; }
        public int hexenzahl { get; set; }
        public int seherzahl { get; set; }
        public int jaegerzahl { get; set; }
        public int amorzahl { get; set; }
        public int beschuetzerzahl { get; set; }
        public int parErmZahl { get; set; }
        public int lykantrophenzahl { get; set; }
        public int spionezahl { get; set; }
        public int idiotenzahl { get; set; }
        public int pazifistenzahl { get; set; }
        public int altenzahl { get; set; }
        public int urwolfzahl { get; set; }
        public int zufaelligeAuswahl { get; set; }
        public int zufaelligeAuswahlBonus { get; set; }
        public int werwolfeinstimmig { get; set; }
        public int werwolfopfer { get; set; }
        public int werwolftimer1 { get; set; }
        public int werwolfzusatz1 { get; set; }
        public int werwolftimer2 { get; set; }
        public int werwolfzusatz2 { get; set; }
        public int dorftimer { get; set; }
        public int dorfzusatz { get; set; }
        public int dorfstichwahltimer { get; set; }
        public int dorfstichwahlzusatz { get; set; }
        public string tagestext { get; set; }
        public int nacht { get; set; }
        public string log { get; set; }
        public string list_lebe { get; set; }
        public int list_lebe_aktualisiert { get; set; }
        public string list_tot { get; set; }
        public int list_tot_aktualisiert { get; set; }
        public int letzterAufruf { get; set; }
    }
}