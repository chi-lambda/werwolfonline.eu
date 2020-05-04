using System;

namespace werwolfonline.Utils
{
    public class RNGesus : IRNGesus
    {
        private Random random = new Random();

        public int Next()
        {
            return random.Next();
        }
        public int Next(int maximum)
        {
            return random.Next(maximum);
        }
    }
}