using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using werwolfonline.Models.Enums;

namespace werwolfonline.Database.Model
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public bool IsHost { get; set; }
        public bool IsAlive { get; set; }
        public bool IsWerewolfVictim { get; set; }
        public bool IsReady { get; set; }
        public int? VoteForId { get; set; }
        public Player? VoteFor { get; set; }
        public Character Character { get; set; }
        public bool IsMayor { get; set; }
        public int HealingPotions { get; set; } = 1;
        public int DeathPotions { get; set; } = 1;
        public int? ProtectorLastProtegeeId { get; set; }
        public Player? ProtectorLastProtegee { get; set; }
        public bool ParanormalUsed { get; set; }
        public int? LoverId { get; set; }
        public Player? Lover { get; set; }
        public int? AssociateId{ get; set; }

        /// <summary>Protected by Protector or sleeping with Slut.</summary>
        public Player? Associate { get; set; }
        public int? LastAssociateId { get; set; }

        /// <summary>Associate from previous night.</summary>
        public Player? LastAssociate { get; set; }
        public bool HunterCanShoot { get; set; }
        public int MayorPassesOn { get; set; }
        public bool GreatWolfUsed { get; set; }
        public bool DiedTonight { get; set; }
        public int CountdownTo { get; set; }
        public int CountdownFrom { get; set; }
        public string Log { get; set; } = "";
        public string PopupText { get; set; } = "";
        public bool Ready { get; set; }
        public bool Reload { get; set; }
        public string Secret { get; set; } = "";
        public int GameId { get; set; }
        public Game Game { get; set; } = null!;

        public List<Player> Accusers { get; set; } = new List<Player>();
        public List<Player> Voters { get; set; } = new List<Player>();

        [NotMapped]
        public string? Connectionid { get; set; }

        public Player() { }
        public Player(string name, string connectionId)
        {
            Name = name;
            Connectionid = connectionId;
            var rng = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[129];
            rng.GetBytes(bytes);
            Secret = System.Convert.ToBase64String(bytes);
        }

        public void MorningReset()
        {
            VoteFor = null;
        }

        public bool IsWerewolf => Character == Character.Werewolf || Character == Character.GreatWolf;
    }

}