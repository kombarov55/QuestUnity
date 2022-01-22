using Other.MatchThreeGame.Assets.Scripts.Model;

namespace Other.MatchThreeGame.Assets.Scripts.Service
{
    public class LevelService
    {
        public Level GetCurrentLevel()
        {
            return new Level("Разбойник", 30, 30, 50, 40, 3, "");
        }
    }
}