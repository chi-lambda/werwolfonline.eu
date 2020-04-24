using werwolfonline.Models.Enums;

namespace werwolfonline.Models.Characters
{
    public abstract class Character
    {
        public abstract bool IsWerewolf { get; }
        public abstract bool LooksLikeWerewolf{get;}
        public abstract Enums.Character Identifier { get; }
        public abstract string Name { get; }
        public abstract string Description { get; }
    }
}