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
        [SerializeField] private GameObject spellBookButton;

        private ToastBehaviour _toastBehaviour;
        
        private void Start()
        {
            StateManager stateManager = GameObject.Find("State").GetComponent<StateManager>();
            _toastBehaviour = toastComponent.GetComponent<ToastBehaviour>();
            _toastBehaviour.Init(stateManager);

            stateManager.SubscribeOnIsPlayersTurn(_ => spellBookButton.SetActive(IsSpellBookButtonActive(stateManager)));
            stateManager.CastsLeftForPlayer.Subscribe(_ => spellBookButton.SetActive(IsSpellBookButtonActive(stateManager)), true);
        }

        public void ShowGoals(Level level)
        {
            _toastBehaviour.ShowGoal();
            // StartCoroutine(_toastBehaviour.ShowWithFlyAway("Победите противника", 1));            
        }

        public void ShowFailure()
        {
            Prefs.CurrentSceneId = QuestSceneConstants.ThreeInArowFailureNodeId;
            // StartCoroutine(_toastBehaviour.ShowWithFlyAway("Поражение", ReturnToPreviousScene));
        }

        public void ShowVictory()
        {
            Prefs.CurrentSceneId = QuestSceneConstants.ThreeInARowVictoryNodeId;
            // StartCoroutine(_toastBehaviour.ShowWithFlyAway("Победа", ReturnToPreviousScene));
        }

        public void ReturnToPreviousScene()
        {
            if (CrossSceneStorage.IsMinigameInQuest)
            {
                SceneManager.LoadScene(CrossSceneStorage.BackSceneName);
            }
            
        }

        private bool IsSpellBookButtonActive(StateManager stateManager)
        {
            int castsLeft = stateManager.CastsLeftForPlayer.Value;
            bool IsPlayersTurn = stateManager.IsPlayersTurn;

            return IsPlayersTurn && castsLeft > 0;
        }
    }
}