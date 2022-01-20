using System.Collections.Generic;
using Other.MatchThreeGame.Assets.Scripts.UI;
using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts
{
    public class SpellBookController : MonoBehaviour
    {
        public GameObject scrollViewContent;
       public GameObject spellPrefab;

       private List<GameObject> _instantiatedSpells = new List<GameObject>();

       public void Start()
        { 
            StateManager stateManager = GameObject.Find("State").GetComponent<StateManager>();

            Clear();

            foreach (var spell in stateManager.PlayerSpellsToCooldownObservable.Keys)
            {
                var go = Instantiate(spellPrefab, scrollViewContent.transform);
                go.GetComponent<SpellBehaviour>().Display(spell, stateManager, gameObject);
                _instantiatedSpells.Add(go);
            }
        }

        

        private void Clear()
        {
            scrollViewContent.transform.DetachChildren();
            foreach (var go in _instantiatedSpells)
            {
                Destroy(go);
            }
        }
    }
}