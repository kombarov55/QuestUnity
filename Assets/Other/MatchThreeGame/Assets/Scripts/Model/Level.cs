using System.Collections.Generic;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class Level
    {
        public List<Goal> Goals;
        public int TurnsAmount;
        public int TurnsLeft;

        public Level() { }

        public Level(List<Goal> goals, int turnsAmount)
        {
            Goals = goals;
            TurnsAmount = turnsAmount;
            TurnsLeft = turnsAmount;
        }
    }
}