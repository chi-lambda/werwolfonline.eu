namespace werwolfonline.Characters
{
    public class GreatWolf : Character
    {
        public override bool IsWerewolf => true;
        public override bool LooksLikeWerewolf => true;
        public override Database.Model.Enums.Character Identifier => Database.Model.Enums.Character.GreatWolf;
        public override string Name => "Urwolf";
        public override string Description => "Sie gehören zu den Werwölfen und gewinnen bzw. verlieren mit ihnen. Einmal pro Spiel können Sie einen Spieler zum Werwolf machen, der dann alle bisherigen Fähigkeiten verliert.";
    }
}