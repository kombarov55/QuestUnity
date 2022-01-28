using System;
using System.Collections.Generic;
using DefaultNamespace.Common;
using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts
{
    public class GameLifecycleObservables
    {
        public SignalObservable BeforeSuccessfulShapeSwapByPlayer = new SignalObservable();
        
        public SignalObservable BeforePlayerTurn = new SignalObservable();
        public SignalObservable AfterPlayerTurn = new SignalObservable();
        public SignalObservable BeforeEnemyTurn = new SignalObservable();
        public SignalObservable AfterEnemyTurn = new SignalObservable();

        // IsPlayersTurn -> Match
        public Observable<Tuple<bool, List<GameObject>>> OnCollapse = new Observable<Tuple<bool, List<GameObject>>>(null);
    }
}