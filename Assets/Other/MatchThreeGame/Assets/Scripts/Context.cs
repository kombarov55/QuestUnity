using Other.MatchThreeGame.Assets.Scripts.Service;
using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts
{
    public class Context : MonoBehaviour
    {
        public SpellService SpellService;

        private void Start()
        {
            SpellService = new SpellService();
        }
        
        public static Context Get()
        { 
            return GameObject.Find("Context").GetComponent<Context>();
        }
    }
}