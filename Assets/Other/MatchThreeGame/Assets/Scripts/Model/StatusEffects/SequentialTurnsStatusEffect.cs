using System;

namespace Other.MatchThreeGame.Assets.Scripts.Model.StatusEffects
{
    [Serializable]
    public class SequentialTurnsStatusEffect : StatusEffect
    {
        public int Amount;

        public SequentialTurnsStatusEffect(int duration, int amount) : base(duration, "RpgPack/S_Wind02", SpellActionType.Buff)
        {
            Amount = amount;
        }

        public override void Tick(StateManager stateManager, bool isOnPlayer)
        {
            if (isOnPlayer)
            {
                stateManager.SequentialTurnsForPlayer.Value = Amount;
            }
            else
            {
                stateManager.SequentialTurnsForEnemy.Value = Amount;
            }
        }
    }
}