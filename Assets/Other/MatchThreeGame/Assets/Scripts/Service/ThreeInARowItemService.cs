using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Common;
using Other.MatchThreeGame.Assets.Scripts.Model;
using Other.MatchThreeGame.Assets.Scripts.Model.StatusEffects;

namespace Other.MatchThreeGame.Assets.Scripts.Service
{
    public class ThreeInARowItemService
    {
        public List<InventoryItem> GetInventoryItems()
        {
            var itemIdToAmount = GlobalSerializedState.Get().AddedInventoryItems.GetCopy();

            // return itemIdToAmount
            //     .Select(pair => new InventoryItem(ThreeInARowItems.ItemIdToItemTemplate[pair.Key], pair.Value))
            //     .ToList();

            return new List<InventoryItem>()
            {
                new InventoryItem(
                    new ThreeInARowItemTemplate(
                        "fury-blade",
                        "Клинок ярости",
                        "Пассивный эффект: ваши атаки фишками наносят на 2 урона больше",
                        "RpgPack/S_Sword16",
                        "Sounds/Sword",
                        new List<SpellAction>(),
                        new List<SpellAction>(),
                        new List<StatusEffect>(),
                        new List<StatusEffect>(),
                        new List<StatusEffect>()
                        {
                            new AdditionalDamageStatusEffect(666, 2, true)
                        },
                        new List<StatusEffect>()
                    ), 1)
            };
        }
    }
}