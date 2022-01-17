using System.Collections.Generic;
using Other.MatchThreeGame.Assets.Scripts.Model;

namespace Other.MatchThreeGame.Assets.Scripts.Service
{
    public class LevelService
    {
        public Level GetCurrentLevel()
        {
            return new Level(300, 30, 10);
        }
    }
}