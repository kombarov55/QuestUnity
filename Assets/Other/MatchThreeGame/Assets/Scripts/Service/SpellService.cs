using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.Common;
using Other.MatchThreeGame.Assets.Scripts.Model;
using Other.MatchThreeGame.Assets.Scripts.Repository;

namespace Other.MatchThreeGame.Assets.Scripts.Service
{
    public class SpellService
    {
        public List<StoredSpell> GetAddedSpells()
        {
            var itemIdToAmount = GlobalSerializedState.Get().AddedInventoryItems.GetCopy();
        
            return itemIdToAmount
                .Where(pair => SpellRepository.IdToSpell.ContainsKey(pair.Key))
                .Select(pair => new StoredSpell(SpellRepository.IdToSpell[pair.Key], pair.Value))
                .ToList();
        }

        public bool IsOnCooldown(StoredSpell storedSpell, StateManager stateManager)
        {
            return storedSpell.TurnWhenUsed - stateManager.TurnsLeft > 0;
        }
    }
}