namespace werwolfonline.Models.Characters
{
    public class Seer : Character
    {
        public override bool IsWerewolf => false;
        public override bool LooksLikeWerewolf => false;
        public override Database.Model.Enums.Character Identifier => Database.Model.Enums.Character.Seer;
        public override string Name => "Seherin";
        public override string Description => "Sie können jede Nacht die Nachtidentität eines Spielers sehen. Alternative: Sie sehen, welcher Gruppe derjenige angehört";
    }
}