namespace werwolfonline.Models.Characters
{
    public class TriggerHappy : Character
    {
        public override bool IsWerewolf => false;
        public override bool LooksLikeWerewolf => false;
        public override Database.Model.Enums.Character Identifier => Database.Model.Enums.Character.TriggerHappy;
        public override string Name => "Mordlustiger";
        public override string Description => "Sie wollen Blut sehen und argumentieren daher immer für das Töten eines Spielers";
    }
}