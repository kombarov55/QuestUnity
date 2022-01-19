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
                    1,
                    new List<SpellAction>(),
                    new List<SpellAction>()
                    {
                        new SpellDamageAction(8)
                    },
                    new List<StatusEffect>(),
                    new List<StatusEffect>(),
                    SpellType.Damage
                ),
                new Spell(
                    "heal",
                    "Лечение",
                    "Наложить заклинание, излечивающее вам 3 очка здоровья",
                    "heal.png",
                    5,
                    2,
                    new List<SpellAction>()
                    {
                        new SpellHealAction(3)
                    }, 
                    new List<SpellAction>(),
                    new List<StatusEffect>(),
                    new List<StatusEffect>(),
                    SpellType.Heal
                ),
                new Spell(
                    "ignite",
                    "Воспламенение",
                    "Поджечь врага, от чего он будет испытывать жуткую боль и 1 урона за ход. Длительность: 3 хода",
                    "ignition.png",
                    2,
                    0,
                    new List<SpellAction>(),
                    new List<SpellAction>(),
                    new List<StatusEffect>(),
                    new List<StatusEffect>()
                    {
                        new DamageOverTimeStatusEffect(3, "ignition.png", 1)
                    },
                    SpellType.Damage
                ),
                new Spell(
                    "NatureRestoration",
                    "Природное восстановление",
                    "Обратиться к силам природы за исцелением, получив 2хп в секунду на протяжении 3х ходов.",
                    "ignition.png",
                    2,
                    0,
                    new List<SpellAction>(),
                    new List<SpellAction>(),
                    new List<StatusEffect>()
                    {
                        new HealOverTimeStatusEffect(3, "Restoration.png", 3)
                    }, 
                    new List<StatusEffect>(),
                    SpellType.Heal
                ),
                new Spell(
                    "AddTurns",
                    "Воодушевление",
                    "Дать себе дополнительно 3 хода",
                    "AddTurns.png",
                    4,
                    0,
                    
                    new List<SpellAction>()
                    {
                        new AdditionalTurnAction(3)
                    },
                    new List<SpellAction>(),
                    new List<StatusEffect>(),
                    new List<StatusEffect>(),
                    SpellType.Buff
                ), 
                new Spell(
                    "DoubleTurn",
                    "Тройной удар",
                    "Ваша скорость возрастает, благодаря чему перед атакой врага вы можете атаковать трижды",
                    "DoubleTurn.png",
                    3,
                    0,
                    new List<SpellAction>()
                    {
                        new SequentialTurnsAction(3)
                    },
                    new List<SpellAction>(),
                    new List<StatusEffect>(),
                    new List<StatusEffect>(),
                    SpellType.Buff
                ),
                new Spell(
                    "MultipleDoubleTurn",
                    "Скорость ветра",
                    "Ваша скорость возрастает, благодаря чему в течение 3х ходов вы сможете атаковать дважды",
                    "DoubleTurn.png",
                    6,
                    0,
                    new List<SpellAction>()
                    {
                        new SequentialTurnsAction(2)
                    }, 
                    new List<SpellAction>(),
                    new List<StatusEffect>()
                    {
                        new SequentialTurnsStatusEffect(2, "doubleturn.png", 2)
                    },
                    new List<StatusEffect>(),
                    SpellType.Buff
                ),
                new Spell(
                    "Shield",
                    "Щит",
                    "Вы окружает себя энергетическим щитом, уменьшающий получаемый урон от следующей атаки на 4 на протяжении 3х ходов",
                    "DoubleTurn.png",
                    6,
                    0,
                    new List<SpellAction>(),
                    new List<SpellAction>(), 
                    new List<StatusEffect>()
                    {
                        new ShieldStatusEffect(3, "img", 4)
                    },
                    new List<StatusEffect>(),
                    SpellType.Buff
                ),
                new Spell(
                    "Shield",
                    "Щит",
                    "Вы окружает себя энергетическим щитом, уменьшающий получаемый урон от следующей атаки на 4 на протяжении 3х ходов",
                    "DoubleTurn.png",
                    6,
                    0,
                    new List<SpellAction>(),
                    new List<SpellAction>(), 
                    new List<StatusEffect>()
                    {
                        new ShieldStatusEffect(3, "img", 4)
                    },
                    new List<StatusEffect>(),
                    SpellType.Buff
                ),
                new Spell(
                    "ReflectDamage",
                    "Отражение урона",
                    "В течение 2х ходов вы будете отражать урон врага",
                    "reflect.png",
                    0,
                    0,
                    new List<SpellAction>()
                    {
                        new ReflectDamageAction()
                    },
                    new List<SpellAction>(),
                    new List<StatusEffect>()
                    {
                        new ReflectDamageStatusEffect(2, "")
                    },
                    new List<StatusEffect>(),
                    SpellType.Buff
                ),
                new Spell(
                    "BlockHealing",
                    "Блокировка лечения",
                    "В течение 3х ходов противник не сможет лечиться",
                    "reflect.png",
                    0,
                    0,
                    new List<SpellAction>(),
                    new List<SpellAction>(),
                    new List<StatusEffect>()
                    {
                        new BlockHealingStatusEffect(3, "")
                    },
                    new List<StatusEffect>()
                    {
                        new BlockHealingStatusEffect(3, "")
                    },
                    SpellType.Debuff
                ), 
                new Spell(
                    "AdditionalDamage",
                    "Доп. урон",
                    "В течение 3х ходов любая ваша атака наносит на 3 урона больше",
                    "reflect.png",
                    0,
                    0,
                    new List<SpellAction>()
                    {
                        new AdditionalDamageAction(3)
                    },
                    new List<SpellAction>(),
                    new List<StatusEffect>()
                    {
                        new AdditionalDamageStatusEffect(3, "", 3)
                    },
                    new List<StatusEffect>(),
                    SpellType.Buff
                ),
                new Spell(
                    "AdditionalHealing",
                    "Доп. лечение",
                    "В течение 3х ходов, восстанавлиая здоровье, вы восстанавливаете его на 3 больше",
                    "reflect.png",
                    0,
                    0,
                    new List<SpellAction>()
                    {
                        new AdditionalHealAction(3)
                    },
                    new List<SpellAction>(),
                    new List<StatusEffect>()
                    {
                        new AdditionalHealStatusEffect(3, "", 3)
                    },
                    new List<StatusEffect>(),
                    SpellType.Buff
                ),
                new Spell(
                    "AdditionalHealing",
                    "Доп. Восстановление маны",
                    "В течение 3х ходов, восстанавливая ману фишками, вы восстанавливете на +2 больше",
                    "reflect.png",
                    0,
                    0,
                    new List<SpellAction>()
                    {
                        new AdditionalManaRestoreAction(2)
                    },
                    new List<SpellAction>(),
                    new List<StatusEffect>()
                    {
                        new AdditionalManaRestoreStatusEffect(3, "", 2)
                    },
                    new List<StatusEffect>(),
                    SpellType.Buff
                ), 
                new Spell(
                    "Manaburn",
                    "Горение маны",
                    "Выжигает у врага 5 маны, далее в течение 3х ходов он будет терять по 3 маны",
                    "reflect.png",
                    0,
                    0,
                    new List<SpellAction>(),
                    new List<SpellAction>()
                    {
                        new ManaburnAction(5)
                    },
                    new List<StatusEffect>()
                    {
                        new ManaburnStatusEffect(3, "", 3)
                    },
                    new List<StatusEffect>()
                    {
                        new ManaburnStatusEffect(3, "", 3)
                    },
                    SpellType.Damage
                ),
                new Spell(
                    "Lifesteal",
                    "Вампиризм",
                    "Украсть 5 здорвья у врага",
                    "lifesteal.png",
                    0,
                    0,
                    new List<SpellAction>(),
                    new List<SpellAction>()
                    {
                        new LifestealAction(5)
                    },
                    new List<StatusEffect>(),
                    new List<StatusEffect>(),
                    SpellType.Damage
                ),
                new Spell(
                    "IncreaseSpellCasts",
                    "Сколдовать несвколько раз",
                    "Потратьте одну попытку сколдовать, чтобы в этом ходу сколдовать ещё 3 раза... да это бредово, этот эффект нужен для предметов и тут можно его протестировать",
                    "icnreasespellcasts.png",
                    0,
                    0,
                    new List<SpellAction>()
                    {
                        new AddSpellCastsLeftAction(3)
                    },
                    new List<SpellAction>(),
                    new List<StatusEffect>(),
                    new List<StatusEffect>(),
                    SpellType.Buff
                ),
                new Spell(
                    "ResetCooldownOnHealing",
                    "Восстановление",
                    "Обнулить перезарядку у лечащих заклинаний",
                    "icnreasespellcasts.png",
                    0,
                    3,
                    new List<SpellAction>()
                    {
                        new SetSpellCooldownAction(spell => spell.SpellType == SpellType.Heal, 0)
                    },
                    new List<SpellAction>(),
                    new List<StatusEffect>(),
                    new List<StatusEffect>(),
                    SpellType.Buff
                ),
                new Spell(
                    "SilenceHealingSpells",
                    "Блокирвка лечащей магии",
                    "Блокирует лечащую магию у врага на 2 хода",
                    "icnreasespellcasts.png",
                    0,
                    1,
                    new List<SpellAction>(),
                new List<SpellAction>(),
                    new List<StatusEffect>()
                    {
                        new SilenceStatusEffect(2, "", spell => spell.SpellType == SpellType.Heal)
                    },
                    new List<StatusEffect>(),
                    SpellType.Debuff
                )
            };
        }
    }
}