using UnityEngine;
using UnityEngine.SceneManagement;

namespace Other.MatchThreeGame.Assets.Scripts
{
    public class SceneController : MonoBehaviour
    {
        public void OnBackClicked()
        {
            SceneManager.LoadScene("Scenes/MainMenu");
        }
    }
}