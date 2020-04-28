using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using werwolfonline.Models.Enums;
using werwolfonline.SignalR.Model;

namespace werwolfonline.Database.Model
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public bool IsHost { get; set; }
        public bool IsAlive { get; set; }
        public bool IsReady { get; set; }
        public int? VoteForId { get; set; }
        public virtual Player? VoteFor { get; set; }
        public Character Character { get; set; }
        public bool IsMayor { get; set; }
        public int HealingPotions { get; set; } = 1;
        public int DeathPotions { get; set; } = 1;
        public bool ParanormalUsed { get; set; }
        public int? LoverId { get; set; }
        public virtual Player? Lover { get; set; }
        public int? AssociateId { get; set; }

        /// <summary>Protected by Protector or sleeping with Slut.</summary>
        public virtual Player? Associate { get; set; }
        public int? LastAssociateId { get; set; }

        /// <summary>Associate from previous night.</summary>
        public virtual Player? LastAssociate { get; set; }
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
        [JsonIgnore]
        public virtual Game Game { get; set; } = null!;
        public virtual List<Player> Voters { get; set; } = new List<Player>();

        [NotMapped]
        public string? ConnectionId { get; set; }

        public Player() { }
        public Player(string name, string connectionId, Game game)
        {
            Name = name;
            ConnectionId = connectionId;
            Game = game;
            var rng = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[129];
            rng.GetBytes(bytes);
            Secret = System.Convert.ToBase64String(bytes);
        }

        public void MorningReset()
        {
            VoteFor = null;
        }

        public PublicPlayer GetPublicPlayer(){
            return new PublicPlayer(this);
        }

        public bool IsWerewolf => Character == Character.Werewolf || Character == Character.GreatWolf;
    }

}