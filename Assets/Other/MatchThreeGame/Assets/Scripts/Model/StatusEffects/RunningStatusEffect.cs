namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class RunningStatusEffect
    {
        public StatusEffect StatusEffect;
        public int TurnsLeft;

        public RunningStatusEffect(StatusEffect statusEffect)
        {
            StatusEffect = statusEffect;
            TurnsLeft = statusEffect.Duration;
        }
    }
}