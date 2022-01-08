namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class Goal
    {
        public GoalType GoalType;
        public int Amount;
        public int CurrentAmount = 0;

        public Goal(GoalType goalType, int amount)
        {
            GoalType = goalType;
            Amount = amount;
        }
    }
}