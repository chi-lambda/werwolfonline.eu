namespace werwolfonline
{
    public class MainViewModel
    {
        public const int _LISTMAXRELOADTIME = 3000;

        public enum Phases
        {
            PHASESETUP = 0,
            PHASESPIELSETUP = 1,
            PHASENACHTBEGINN = 2,
            PHASENACHT1 = 3,
            PHASENACHT2 = 4,
            PHASENACHT3 = 5,
            PHASENACHT4 = 6,
            PHASENACHT5 = 7,
            PHASENACHTENDE = 8,
            PHASETOTEBEKANNTGEBEN = 9,
            PHASEBUERGERMEISTERWAHL = 10,
            PHASEDISKUSSION = 11,
            PHASEANKLAGEN = 12,
            PHASEABSTIMMUNG = 13,
            PHASESTICHWAHL = 14,
            PHASENACHABSTIMMUNG = 15,
            PHASESIEGEREHRUNG = 16,
        }
    }
}