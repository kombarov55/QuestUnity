using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class StatusEffectsPanelBehaviour : MonoBehaviour
    {
        public GameObject statusEffectPrefab;

        private List<GameObject> _statusEffectGos = new List<GameObject>();

        private void Start()
        {
            StateManager stateManager = GameObject.Find("State").GetComponent<StateManager>();
            
            stateManager.OnPlayerStatusEffectAddedSubscribers.Add(runningStatusEffect =>
            {
                var go = Instantiate(statusEffectPrefab, gameObject.transform);
                var statusEffectBehaviour = go.GetComponent<StatusEffectBehaviour>();
                statusEffectBehaviour.Display(runningStatusEffect.StatusEffect);
                _statusEffectGos.Add(go);
            });
            
            stateManager.OnPlayerStatusEffectTickSubscribers.Add(runningStatusEffect =>
            {
                foreach (var statusEffectGo in _statusEffectGos)
                {
                    var statusEffectBehaviour = statusEffectGo.GetComponent<StatusEffectBehaviour>();
                    if (statusEffectBehaviour.StatusEffect == runningStatusEffect.StatusEffect)
                    {
                        statusEffectBehaviour.UpdateTurnsLeft(runningStatusEffect.TurnsLeft);
                        break;
                    }
                }
            });
            
            stateManager.OnPlayerStatusEffectRemovedSubscribers.Add(runningStatusEffect =>
            {
                var go = _statusEffectGos.Find(v =>
                    v.GetComponent<StatusEffectBehaviour>().StatusEffect == runningStatusEffect.StatusEffect);
                
                Destroy(go);
                
                _statusEffectGos = _statusEffectGos.Where(v => v != go).ToList();
            });
        }

    }
}