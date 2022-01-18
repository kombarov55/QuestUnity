namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public abstract class StatusEffect
    {
        public int Duration;
        public string ImagePath;

        protected StatusEffect(int duration, string imagePath)
        {
            Duration = duration;
            ImagePath = imagePath;
        }

        public abstract void Invoke(StateManager stateManager, bool isOnPlayer);
    }
}