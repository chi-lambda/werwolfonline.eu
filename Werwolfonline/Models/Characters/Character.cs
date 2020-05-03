using System;

namespace werwolfonline.Models.Characters
{
    public abstract class Character
    {
        public abstract bool IsWerewolf { get; }
        public abstract bool LooksLikeWerewolf { get; }
        public abstract Database.Model.Enums.Character Identifier { get; }
        public abstract string Name { get; }
        public abstract string Description { get; }

        public static Character GetCharacterById(Database.Model.Enums.Character id)
        {
            switch (id)
            {
                case Database.Model.Enums.Character.None:
                    return new None();
                case Database.Model.Enums.Character.Villager:
                    return new Villager();
                case Database.Model.Enums.Character.Werewolf:
                    return new Werewolf();
                case Database.Model.Enums.Character.Seer:
                    return new Seer();
                case Database.Model.Enums.Character.Witch:
                    return new Witch();
                case Database.Model.Enums.Character.Hunter:
                    return new Hunter();
                case Database.Model.Enums.Character.Amor:
                    return new Amor();
                case Database.Model.Enums.Character.Protector:
                    return new Protector();
                case Database.Model.Enums.Character.Paranormal:
                    return new Paranormal();
                case Database.Model.Enums.Character.Lycanthrope:
                    return new Lycanthrope();
                case Database.Model.Enums.Character.Spy:
                    return new Spy();
                case Database.Model.Enums.Character.TriggerHappy:
                    return new TriggerHappy();
                case Database.Model.Enums.Character.Pacifist:
                    return new Pacifist();
                case Database.Model.Enums.Character.OldMan:
                    return new OldMan();
                case Database.Model.Enums.Character.GreatWolf:
                    return new GreatWolf();
                default:
                    throw new ArgumentException("Invalid Character id.", "id");
            }
        }
    }
}