namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class StoredSpell
    {
        public Spell Spell;
        public int AmountLeft;
        public int TurnWhenUsed = int.MaxValue;
        
        public StoredSpell(Spell spell, int amountLeft)
        {
            Spell = spell;
            AmountLeft = amountLeft;
        }

        public bool IsOnCooldown(int turnsLeft)
        {
            return GetCurrentCooldown(turnsLeft) > 0;
        }

        public int GetCurrentCooldown(int turnsLeft)
        {
            int cd = Spell.Cooldown - (TurnWhenUsed - turnsLeft);

            if (cd < 0)
            {
                cd = 0;
            }

            return cd;
        }
        
        
    }
}