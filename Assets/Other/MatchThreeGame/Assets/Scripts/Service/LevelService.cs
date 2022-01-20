using System.Collections.Generic;
using Other.MatchThreeGame.Assets.Scripts.Model;
using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts.Service
{
    public class LevelService
    {
        public Level GetCurrentLevel()
        {
            return new Level(30, 30, 30, 10, 10, "");
        }
    }
}