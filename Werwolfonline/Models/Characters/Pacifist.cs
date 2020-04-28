using werwolfonline.Models.Enums;

namespace werwolfonline.Models.Characters
{
    public class Pacifist : Character
    {
        public override bool IsWerewolf => false;
        public override bool LooksLikeWerewolf => false;
        public override Enums.Character Identifier => Enums.Character.Pacifist;
        public override string Name => "Pazifist";
        public override string Description => "Sie wollen, dass alle möglichst friedlich zusammenleben und argumentieren daher immer gegen das Töten eines Spielers";
    }
}