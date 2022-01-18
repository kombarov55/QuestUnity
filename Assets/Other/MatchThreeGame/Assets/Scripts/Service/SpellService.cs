using System.Collections.Generic;
using Other.MatchThreeGame.Assets.Scripts.Model;
using Other.MatchThreeGame.Assets.Scripts.Model.StatusEffects;
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
                    },
                    new List<StatusEffect>(),
                    new List<StatusEffect>()
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
                    }, 
                    new List<StatusEffect>(),
                    new List<StatusEffect>()
                ),
                new Spell(
                    "ignite",
                    "Воспламенение",
                    "Поджечь врага, от чего он будет испытывать жуткую боль и 1 урона за ход. Длительность: 3 хода",
                    "ignition.png",
                    2,
                    new List<SpellAction>(),
                    new List<StatusEffect>(),
                    new List<StatusEffect>()
                    {
                        new DamageOverTimeStatusEffect(3, "ignition.png", 1)
                    }
                ),
                new Spell(
                    "NatureRestoration",
                    "Природное восстановление",
                    "Обратиться к силам природы за исцелением, получив 2хп в секунду на протяжении 3х ходов.",
                    "ignition.png",
                    2,
                    new List<SpellAction>(),
                    new List<StatusEffect>()
                    {
                        new HealOverTimeStatusEffect(3, "Restoration.png", 3)
                    }, 
                    new List<StatusEffect>()
                ),
                new Spell(
                    "AddTurns",
                    "Воодушевление",
                    "Дать себе дополнительно 3 хода",
                    "AddTurns.png",
                    4,
                    new List<SpellAction>()
                    {
                        new AdditionalTurnAction(3)
                    },
                    new List<StatusEffect>(),
                    new List<StatusEffect>()
                ), 
                new Spell(
                    "DoubleTurn",
                    "Тройной удар",
                    "Ваша скорость возрастает, благодаря чему перед атакой врага вы можете атаковать трижды",
                    "DoubleTurn.png",
                    3,
                    new List<SpellAction>()
                    {
                        new SequentialTurnsAction(3, true)
                    },
                    new List<StatusEffect>(),
                    new List<StatusEffect>()
                ),
                new Spell(
                    "MultipleDoubleTurn",
                    "Скорость ветра",
                    "Ваша скорость возрастает, благодаря чему в течение 3х ходов вы сможете атаковать дважды",
                    "DoubleTurn.png",
                    6,
                    new List<SpellAction>()
                    {
                        new SequentialTurnsAction(2, true)
                    }, 
                    new List<StatusEffect>()
                    {
                        new SequentialTurnsStatusEffect(2, "doubleturn.png", 2)
                    },
                    new List<StatusEffect>()
                ),
                new Spell(
                    "Shield",
                    "Щит",
                    "Вы окружает себя энергетическим щитом, уменьшающий получаемый урон от следующей атаки на 4 на протяжении 3х ходов",
                    "DoubleTurn.png",
                    6,
                    new List<SpellAction>(), 
                    new List<StatusEffect>()
                    {
                        new ShieldStatusEffect(3, "img", 4)
                    },
                    new List<StatusEffect>()
                )
            };
        }
    }
}