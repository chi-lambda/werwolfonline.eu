namespace werwolfonline.Models.Characters
{
    public class OldMan : Character
    {
        public override bool IsWerewolf => false;
        public override bool LooksLikeWerewolf => false;
        public override Database.Model.Enums.Character Identifier => Database.Model.Enums.Character.OldMan;
        public override string Name => "Die/Der Alte";
        public override string Description => "Sie sterben in der x. Nacht, wobei x die Anzahl der lebenden Werwölfe + 1 ist. Es kann also sein, dass sie früher sterben als gedacht.";
    }
}