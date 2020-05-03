using werwolfonline.Utils;
using Xunit;

namespace werwolfonline.Database.Utils.Test
{
    public class CorrectHorseBatteryStaple_Test
    {
        [Fact]
        public void FromGermanToGerman_Test(){
            var chbs = new CorrectHorseBatteryStaple();
            var testWords = "kohl-freund-segen";
            Assert.Equal(testWords, chbs.ToGermanWords(chbs.FromGermanWords(testWords)));
        }

        [Fact]
        public void FromNumberToNumber_Test()
        {
            var chbs = new CorrectHorseBatteryStaple();
            var testNumber = 10000000000UL;
            Assert.Equal(testNumber,chbs.FromGermanWords(chbs.ToGermanWords(testNumber)));
        }
    }
}