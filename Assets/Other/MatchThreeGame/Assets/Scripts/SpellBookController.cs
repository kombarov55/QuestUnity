using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts
{
    public class SpellBookController : MonoBehaviour
    {
       public AudioButton closeButton;
       
        public void Start() 
        {
               closeButton.OnClick = () => gameObject.SetActive(false);
        }
    }
}