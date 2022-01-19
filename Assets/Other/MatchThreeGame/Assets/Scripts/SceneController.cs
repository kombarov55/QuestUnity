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
        [SerializeField] private AudioButton spellBookButton;
        [SerializeField] private GameObject spellBookPanel;

        private ToastBehaviour _toastBehaviour;
        
        private void Start()
        {
            _toastBehaviour = toastComponent.GetComponent<ToastBehaviour>();
            StateManager stateManager = GameObject.Find("State").GetComponent<StateManager>();

            stateManager.CastsLeftForPlayer.Subscribe(castsLeft =>
            {
                if (castsLeft > 0)
                {
                    spellBookButton.gameObject.SetActive(true);
                }
                else
                {
                    spellBookButton.gameObject.SetActive(false);
                }
            }, true);

            spellBookButton.OnClick = () => spellBookPanel.SetActive(true);
        }

        public void ShowGoals(Level level)
        {
            StartCoroutine(_toastBehaviour.ShowWithFlyAway("Победите противника", 1));            
        }

        public void ShowFailure()
        {
            Prefs.CurrentSceneId = QuestSceneConstants.ThreeInArowFailureNodeId;
            StartCoroutine(_toastBehaviour.ShowWithFlyAway("Поражение", ReturnToPreviousScene));
        }

        public void ShowVictory()
        {
            Prefs.CurrentSceneId = QuestSceneConstants.ThreeInARowVictoryNodeId;
            StartCoroutine(_toastBehaviour.ShowWithFlyAway("Победа", ReturnToPreviousScene));
        }

        public void ReturnToPreviousScene()
        {
            if (CrossSceneStorage.IsMinigameInQuest)
            {
                SceneManager.LoadScene(CrossSceneStorage.BackSceneName);
            }
            
        }
    }
}