namespace werwolfonline.Characters
{
    public class Lycanthrope : Character
    {
        public override bool IsWerewolf => false;
        public override bool LooksLikeWerewolf => true;
        public override Database.Model.Enums.Character Identifier => Database.Model.Enums.Character.Lycanthrope;
        public override string Name => "Lykanthrop";
        public override string Description => "Sie sehen aus wie ein Werwolf, sind aber keiner. Sie spielen also für die Dorfbewohner";
    }
}