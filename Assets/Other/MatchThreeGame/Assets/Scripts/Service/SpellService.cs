using System.Collections.Generic;
using Other.MatchThreeGame.Assets.Scripts.Model;
using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts.Service
{
    public class SpellService
    {
        private GameObject SpellPrefsab;
        
        public List<Spell> GetAll()
        {
            return new List<Spell>()
            {
                new Spell(
                    "fireball",
                    "Огненный шар",
                    "Бросить в противника огненный шар, наносящий 8 урона",
                    "fireball.png",
                    3,
                    new List<SpellAction>()
                    {
                        new SpellDamageAction(8)
                    }
                ),
                new Spell(
                    "heal",
                    "Лечение",
                    "Наложить заклинание, излечивающее вам 3 очка здоровья",
                    "heal.png",
                    5,
                    new List<SpellAction>()
                    {
                        new SpellHealAction(3)
                    }
                ),
            };
        }
    }
}