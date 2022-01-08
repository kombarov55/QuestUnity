using System.Collections.Generic;
using Other.MatchThreeGame.Assets.Scripts.Model;

namespace Other.MatchThreeGame.Assets.Scripts.Service
{
    public class GameplayService
    {
        public GameStatus CalculateCurrentGameStatus(Level level)
        {
            if (AreAllGoalsAcomplished(level.Goals))
            {
                return GameStatus.VICTORY;
            }

            if (level.TurnsLeft <= 0)
            {
                return GameStatus.FAILURE;
            }

            return GameStatus.CONTINUE;
        }

        private bool AreAllGoalsAcomplished(List<Goal> goals)
        {
            foreach (var goal in goals)
            {
                if (goal.CurrentAmount < goal.Amount)
                {
                    return false;
                } 
            }

            return true;
        }
    }
}