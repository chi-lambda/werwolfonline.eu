using Xunit;

namespace werwolfonline.Database.Model.Test
{
    public class Game_Test
    {
        [Fact]
        public void GameIdString_Test(){
            var game = new Game();
            game.GameNumber = 100000000;
            Assert.Equal("presse-kurbel-abfall", game.GameNumberWords);
        }
    }
}