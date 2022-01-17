using UnityEngine;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class AvatarBehaviour : MonoBehaviour
    {

        public bool isPlayer;
        public float scaleDuration = 0.2f;
        public float scaleAmount = 2f;
        
        private void Start()
        {
            StateManager stateManager = GameObject.Find("State").GetComponent<StateManager>();
            Image image = GetComponent<Image>();
            
            stateManager.SubscribeOnIsPlayersTurn(isPlayersTurn =>
            {
                if (isPlayer)
                {
                    if (isPlayersTurn)
                    {
                        image.transform.scaleTo(scaleDuration, scaleAmount);
                    }
                    else
                    {
                        image.transform.scaleTo(scaleDuration,  1);
                    }
                }
                else
                {
                    if (!isPlayersTurn)
                    {
                        image.transform.scaleTo(scaleDuration, scaleAmount);
                    }
                    else
                    {
                        image.transform.scaleTo(scaleDuration, 1);
                    }
                }
            });
        }
    }
}