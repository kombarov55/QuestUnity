using System.Collections.Generic;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class ItemTemplate
    {
        public string Id;
        public string Name;
        public string Description;
        public string Image;
        public List<SpellAction> ActionsOfSelfWhenUsed;
        public List<SpellAction> ActionsOfEnemyWhenUsed;
        public List<StatusEffect> StatusEffectsOnSelfWhenUsed;
        public List<StatusEffect> StatusEffectsOnEnemyWhenUsed;
        public List<StatusEffect> PassiveStatusEffectsOnSelf;
        public List<StatusEffect> PassiveStatusEffectsOnEnemy;
        
        public ItemTemplate(
            string id, 
            string name, 
            string description, 
            string image, 
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
            Image = image;
            ActionsOfSelfWhenUsed = actionsOfSelfWhenUsed;
            ActionsOfEnemyWhenUsed = actionsOfEnemyWhenUsed;
            StatusEffectsOnSelfWhenUsed = statusEffectsOnSelfWhenUsed;
            StatusEffectsOnEnemyWhenUsed = statusEffectsOnEnemyWhenUsed;
            PassiveStatusEffectsOnSelf = passiveStatusEffectsOnSelf;
            PassiveStatusEffectsOnEnemy = passiveStatusEffectsOnEnemy;
        }
    }
}