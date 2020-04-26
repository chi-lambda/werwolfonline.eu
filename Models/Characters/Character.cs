using System;
using werwolfonline.Models.Enums;

namespace werwolfonline.Models.Characters
{
    public abstract class Character
    {
        public abstract bool IsWerewolf { get; }
        public abstract bool LooksLikeWerewolf { get; }
        public abstract Enums.Character Identifier { get; }
        public abstract string Name { get; }
        public abstract string Description { get; }

        public static Character GetCharacterById(Enums.Character id)
        {
            switch (id)
            {
                case Enums.Character.None:
                    return new None();
                case Enums.Character.Villager:
                    return new Villager();
                case Enums.Character.Werewolf:
                    return new Werewolf();
                case Enums.Character.Seer:
                    return new Seer();
                case Enums.Character.Witch:
                    return new Witch();
                case Enums.Character.Hunter:
                    return new Hunter();
                case Enums.Character.Amor:
                    return new Amor();
                case Enums.Character.Protector:
                    return new Protector();
                case Enums.Character.Paranormal:
                    return new Paranormal();
                case Enums.Character.Lycanthrope:
                    return new Lycanthrope();
                case Enums.Character.Spy:
                    return new Spy();
                case Enums.Character.TriggerHappy:
                    return new TriggerHappy();
                case Enums.Character.Pacifist:
                    return new Pacifist();
                case Enums.Character.OldMan:
                    return new OldMan();
                case Enums.Character.GreatWolf:
                    return new GreatWolf();
                default:
                    throw new ArgumentException("Invalid Character id.", "id");
            }
        }
    }
}