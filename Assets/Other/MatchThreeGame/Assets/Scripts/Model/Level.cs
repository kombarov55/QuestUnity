using System.Collections.Generic;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class Level
    {
        public int TurnsAmount;
        public int TurnsLeft;

        public int PlayerHealth;
        public int EnemyHealth;

        public Level() { }

        public Level(int turnsAmount, int playerHealth, int enemyHealth)
        {
            TurnsAmount = turnsAmount;
            TurnsLeft = turnsAmount;
            PlayerHealth = playerHealth;
            EnemyHealth = enemyHealth;
        }
    }
}