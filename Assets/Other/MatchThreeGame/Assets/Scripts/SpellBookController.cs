using System.Collections.Generic;
using Other.MatchThreeGame.Assets.Scripts.Model;
using Other.MatchThreeGame.Assets.Scripts.Service;
using Other.MatchThreeGame.Assets.Scripts.UI;
using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts
{
    public class SpellBookController : MonoBehaviour
    {
       public AudioButton closeButton;
       public GameObject scrollViewContent;
       public GameObject spellPrefab;

       private List<GameObject> _instantiatedSpells = new List<GameObject>();
       
        public void Start()
        { 
            var stateManager = GameObject.Find("State").GetComponent<StateManager>();
            
            closeButton.OnClick = () => gameObject.SetActive(false);
            
            Clear();

            foreach (var spell in stateManager.SpellToCooldownObservable.Keys)
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