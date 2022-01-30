using System;
using System.Collections.Generic;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    [Serializable]
    public class ThreeInARowItemTemplate
    {
        public string Id;
        public string Name;
        public string Description;
        public string ImagePath;
        public string SoundOnUsePath;
        public List<SpellAction> ActionsOfSelfWhenUsed;
        public List<SpellAction> ActionsOfEnemyWhenUsed;
        public List<StatusEffect> StatusEffectsOnSelfWhenUsed;
        public List<StatusEffect> StatusEffectsOnEnemyWhenUsed;
        public List<StatusEffect> PassiveStatusEffectsOnSelf;
        public List<StatusEffect> PassiveStatusEffectsOnEnemy;
        
        public ThreeInARowItemTemplate(
            string id, 
            string name, 
            string description, 
            string imagePath, 
            string soundOnUsePath,
            List<SpellAction> actionsOfSelfWhenUsed,
            List<SpellAction> actionsOfEnemyWhenUsed,
            List<StatusEffect> statusEffectsOnSelfWhenUsed,
            List<StatusEffect> statusEffectsOnEnemyWhenUsed,
            List<StatusEffect> passiveStatusEffectsOnSelf,
            List<StatusEffect> passiveStatusEffectsOnEnemy
        )
        {
            Id = id;
            Name = name;
            Description = description;
            ImagePath = imagePath;
            SoundOnUsePath = soundOnUsePath;
            ActionsOfSelfWhenUsed = actionsOfSelfWhenUsed;
            ActionsOfEnemyWhenUsed = actionsOfEnemyWhenUsed;
            StatusEffectsOnSelfWhenUsed = statusEffectsOnSelfWhenUsed;
            StatusEffectsOnEnemyWhenUsed = statusEffectsOnEnemyWhenUsed;
            PassiveStatusEffectsOnSelf = passiveStatusEffectsOnSelf;
            PassiveStatusEffectsOnEnemy = passiveStatusEffectsOnEnemy;
        }
    }
}