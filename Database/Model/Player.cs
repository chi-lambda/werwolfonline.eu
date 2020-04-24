using System;

namespace werwolfonline.Database.Model
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsHost { get; set; }
        public bool IsAlive { get; set; }
        public int VoteForId { get; set; }
        public Player VoteFor { get; set; }
        public int AccuserId { get; set; }
        public Player Accuser { get; set; }
        public int Character { get; set; }
        public bool IsMayer { get; set; }
        public int HealingPotions { get; set; }
        public int DeathPotions { get; set; }
        public int WitchVictimId { get; set; }
        public Player WitchVictim { get; set; }
        public bool WitchHeals { get; set; }
        public int ProtectorLastProtegeeId { get; set; }
        public Player ProtectorLastProtegee { get; set; }
        public bool ParanormalUsed { get; set; }
        public int? InLoveWithPlayerId { get; set; }
        public Player InLoverWithPlayer { get; set; }
        public bool HunterCanShoot { get; set; }
        public int MayerPassesOn { get; set; }
        public bool GreatWolfUsed { get; set; }
        public bool DiedTonight { get; set; }
        public int CountdownTo { get; set; }
        public int CountdownFrom { get; set; }
        public string Log { get; set; }
        public string PopupText { get; set; }
        public bool Ready { get; set; }
        public bool Reload { get; set; }
        public Guid VerificationNumber { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}