using System;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    [Serializable]
    public abstract class StatusEffect
    {
        public int Duration;
        public string ImagePath;
        public SpellActionType ActionType;
        public bool IsPassive;

        protected StatusEffect(int duration, string imagePath, SpellActionType actionType, bool isPassive = false)
        {
            Duration = duration;
            ImagePath = imagePath;
            ActionType = actionType;
            IsPassive = isPassive;
        }

        public abstract void Tick(StateManager stateManager, bool isOnPlayer);

        public virtual void Rollback()
        {
            
        }
        
    }
}