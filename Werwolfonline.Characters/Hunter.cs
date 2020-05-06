namespace werwolfonline.Characters
{
    public class Hunter : Character
    {
        public override bool IsWerewolf => false;
        public override bool LooksLikeWerewolf => false;
        public override Database.Model.Enums.Character Identifier => Database.Model.Enums.Character.Hunter;
        public override string Name => "Jäger";
        public override string Description => "Wenn Sie getötet werden, können Sie nach einem letzten Griff zu Ihrer Flinte einen anderen Spieler mit in den Tod reißen";
    }
}