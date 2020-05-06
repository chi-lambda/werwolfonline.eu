namespace werwolfonline.Characters
{
    public class Pacifist : Character
    {
        public override bool IsWerewolf => false;
        public override bool LooksLikeWerewolf => false;
        public override Database.Model.Enums.Character Identifier => Database.Model.Enums.Character.Pacifist;
        public override string Name => "Pazifist";
        public override string Description => "Sie wollen, dass alle möglichst friedlich zusammenleben und argumentieren daher immer gegen das Töten eines Spielers";
    }
}