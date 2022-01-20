﻿using System.Collections.Generic;

namespace Other.MatchThreeGame.Assets.Scripts.Model
{
    public class Level
    {
        public int TurnsAmount;
        public int TurnsLeft;

        public int PlayerHealth;
        public int EnemyHealth;

        public int PlayerMana;
        public int EnemyMana;

        public string EnemyAvatarImagePath;

        public Level() { }

        public Level(int turnsAmount, int playerHealth, int enemyHealth, int playerMana, int enemyMana, string enemyAvatarImagePath)
        {
            TurnsAmount = turnsAmount;
            TurnsLeft = turnsAmount;
            PlayerHealth = playerHealth;
            EnemyHealth = enemyHealth;
            PlayerMana = playerMana;
            EnemyMana = enemyMana;
            EnemyAvatarImagePath = enemyAvatarImagePath;
        }
    }
}