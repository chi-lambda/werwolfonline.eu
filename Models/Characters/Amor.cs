using werwolfonline.Models.Enums;

namespace werwolfonline.Models.Characters
{
    public class Amor : Character
    {
        public override bool IsWerewolf => false;
        public override bool LooksLikeWerewolf => false;
        public override Enums.Character Identifier => Enums.Character.Amor;
        public override string Name => "Amor";
        public override string Description => "Zu Beginn des Spieles dürfen Sie zwei Personen bestimmen, die sich verlieben. Stirbt die eine Person, begeht die andere aus Kummer Selbstmord.";
    }
}