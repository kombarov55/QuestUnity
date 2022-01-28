using System;
using System.Collections.Generic;
using DefaultNamespace.Common.UI;
using Other.MatchThreeGame.Assets.Scripts.Model;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class MagicEffectBehaviour : MonoBehaviour
    {
        public float animationDuration = 1f;
        public float fadeDuration = 2f;
        
        public bool isOnPlayer;

        private Animator _animator;
        private Image _image;

        public Dictionary<SpellType, List<int>> spellTypeToAnimationTypes = new Dictionary<SpellType, List<int>>()
        {
            {SpellType.Damage, new List<int>() { 1 }},
            {SpellType.Heal, new List<int>() { 10, 11, 12 }},
            {SpellType.Buff, new List<int>() { 20 }},
            {SpellType.Debuff, new List<int>() { 30 }}
        };

        public void Start()
        {
            _animator = GetComponent<Animator>();
            _image = GetComponent<Image>();
            
            var stateManager = StateManager.Get();
            
            (isOnPlayer ? 
                    stateManager.MagicEffectThrownOnPlayer : 
                    stateManager.MagicEffectThrownOnEnemy
                ).Subscribe(spellType =>
                {

                    gameObject.SetActive(true);
                    SetAlpha(1);
                
                    _animator.SetInteger("Type", GetRandomAnimationTypeForSpellType(spellType));

                    StartCoroutine(UICoroutines.InvokeAfterDelay(animationDuration, () => StartCoroutine(UICoroutines.FadeImageToZeroAlpha(_image, fadeDuration))));
                    StartCoroutine(UICoroutines.InvokeAfterDelay(animationDuration + fadeDuration, () => _animator.SetInteger("Type", 0)));
                });
        }

        private void SetAlpha(float a)
        {
            _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, a);
        }

        private int GetRandomAnimationTypeForSpellType(SpellType spellType)
        {
            var list = spellTypeToAnimationTypes[spellType];

            return list[Random.Range(0, list.Count - 1)];
        }
    }
}