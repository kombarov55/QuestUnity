using System;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public abstract class StatusEffect
    {
        public int Duration;
        public string ImagePath;
        public SpellActionType ActionType;

        protected StatusEffect(int duration, string imagePath, SpellActionType actionType)
        {
            Duration = duration;
            ImagePath = imagePath;
            ActionType = actionType;
        }

        public abstract void Tick(StateManager stateManager, bool isOnPlayer);

        public virtual void Rollback()
        {
            
        }
        
    }
}