using DefaultNamespace.Common;

namespace Other.MatchThreeGame.Assets.Scripts
{
    public class GameLifecycleObservables
    {
        public static SignalObservable BeforeSuccessfulShapeSwapByPlayer = new SignalObservable();
        
        public static SignalObservable BeforePlayerTurn = new SignalObservable();
        public static SignalObservable AfterPlayerTurn = new SignalObservable();
        public static SignalObservable BeforeEnemyTurn = new SignalObservable();
        public static SignalObservable AfterEnemyTurn = new SignalObservable();
    }
}