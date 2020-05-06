namespace werwolfonline.Characters
{
    public class Witch : Character
    {
        public override bool IsWerewolf => false;
        public override bool LooksLikeWerewolf => false;
        public override Database.Model.Enums.Character Identifier => Database.Model.Enums.Character.Witch;
        public override string Name => "Hexe";
        public override string Description => "Sie können ein Mal im Spiel jemanden mit Ihrem Todestrank töten, ein Mal im Spiel das Opfer der Werwölfe retten. Entscheiden Sie weise, viel hängt davon ab.";
    }
}