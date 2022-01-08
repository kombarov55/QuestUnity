using System.Collections.Generic;
using Other.MatchThreeGame.Assets.Scripts.Model;

namespace Other.MatchThreeGame.Assets.Scripts.Service
{
    public class GoalService
    {
        public Level GetCurrentGoal()
        {
            var goals = new List<Goal>();
            goals.Add(new Goal(GoalType.COLLECT_SCORE, 10000));
            
            return new Level(goals, 15);
        }
    }
}