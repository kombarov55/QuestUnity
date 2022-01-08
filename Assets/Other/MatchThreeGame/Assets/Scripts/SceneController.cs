using DefaultNamespace;
using Other.MatchThreeGame.Assets.Scripts.Model;
using Other.MatchThreeGame.Assets.Scripts.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Other.MatchThreeGame.Assets.Scripts
{
    public class SceneController : MonoBehaviour
    {

        [SerializeField] private GameObject toastComponent;

        private ToastBehaviour _toastBehaviour;
        
        private void Start()
        {
            _toastBehaviour = toastComponent.GetComponent<ToastBehaviour>();
        }

        public void ShowGoals(Level level)
        {
            StartCoroutine(_toastBehaviour.ShowGoals(level.Goals[0]));            
        }

        public void ShowFailure()
        {
            StartCoroutine(_toastBehaviour.ShowWithFlyAway("Поражение", OnBackClicked));
        }

        public void ShowVictory()
        {
            StartCoroutine(_toastBehaviour.ShowWithFlyAway("Победа", OnBackClicked));
        }

        public void OnBackClicked()
        {
            SceneManager.LoadScene(CrossSceneStorage.BackSceneName);
        }
    }
}