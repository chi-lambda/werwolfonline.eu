using System;
using werwolfonline.Models.Enums

namespace werwolfonline.Database.Model
{
    public class Game
    {
        public Phase Phase { get; set; }
        public bool RevealCharacters { get; set; }
        public bool PassOnMayor { get; set; }
        public bool SeerSeesIdentity { get; set; }
        public CharacterCount[] CharacterCounts{get;set;}
        public bool RandomSelection { get; set; }
        public int RandomSelectionBonus { get; set; }
        public bool UnanimousWerewolves { get; set; }
        public int WerewolfVictimId {get;set}
        public Player WerewolfVictim { get; set; }
        public int WerewolfTimer1 { get; set; }
        public int WerwolfTimer1BonusPerPlayer { get; set; }
        public int WerewolfTimer2 { get; set; }
        public int WerwolfTimer2BonusPerPlayer { get; set; }
        public int VillageTimer { get; set; }
        public int VillageTimerBonusPerPlayer { get; set; }
        public int RunOffVoteTimer { get; set; }
        public int RunOffVoteTimerBonusPerPlayer { get; set; }
        public string MessageOfTheDay { get; set; }
        public int Night { get; set; }
        public string Log { get; set; }
        public DateTime LastAccess { get; set; }
    }
}