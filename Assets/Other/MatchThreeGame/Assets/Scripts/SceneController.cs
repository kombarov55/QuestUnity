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
            
            ShowGoal();
        }

        public void ShowGoal()
        {
            StartCoroutine(_toastBehaviour.ShowWithFlyAway("Наберите " + Constants.GoalScore + " очков!", 2));            
        }

        public void EndGame()
        {
            _toastBehaviour.ShowUntilClicked("Победа!", "Нажмите на экран для выхода", () => OnBackClicked());
        }

        public void OnBackClicked()
        {
            SceneManager.LoadScene("Scenes/MainMenu");
        }
    }
}