﻿using System;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    [Serializable]
    public class AdditionalTurnAction : SpellAction
    {
        public int TurnsToAdd;

        public AdditionalTurnAction(int turnsToAdd) : base(SpellActionType.Buff)
        {
            TurnsToAdd = turnsToAdd;
        }

        public override void Cast(StateManager stateManager, bool isAffectedOnPlayer)
        {
            stateManager.TurnsLeft += TurnsToAdd;
        }
    }
}