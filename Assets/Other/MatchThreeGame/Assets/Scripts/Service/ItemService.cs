using System.Collections.Generic;
using System.Linq;
using Other.MatchThreeGame.Assets.Scripts.Model;

namespace Other.MatchThreeGame.Assets.Scripts.Service
{
    public class ItemService
    {
        public List<ItemTemplate> GetAllItemTemplates()
        {
            return new List<ItemTemplate>()
            {
                new ItemTemplate(
                    "SmallHealingPotion",
                    "Малое зелье здоровья",
                    "Восстанавливает вам 2 хп",
                    "RpgPack/P_Orange02",
                    new List<SpellAction>()
                    {
                        new HealAction(2)
                    },
                    new List<SpellAction>(),
                    new List<StatusEffect>(),
                    new List<StatusEffect>(),
                    new List<StatusEffect>(),
                    new List<StatusEffect>()
                ),
                new ItemTemplate(
                    "SmallManaPotion",
                    "Малое зелье маны",
                    "Восстанавливает вам 2 маны",
                    "RpgPack/P_Blue02",
                    new List<SpellAction>()
                    {
                        new AddManaAction(2)
                    },
                    new List<SpellAction>(),
                    new List<StatusEffect>(),
                    new List<StatusEffect>(),
                    new List<StatusEffect>(),
                    new List<StatusEffect>()
                )
            };
        }

        public List<InventoryItem> GetInventoryItems()
        {
            return GetAllItemTemplates()
                .Select(v => new InventoryItem(v, 3))
                .ToList();
        }
    }
}