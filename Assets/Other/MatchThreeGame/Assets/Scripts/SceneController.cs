using DefaultNamespace;
using DefaultNamespace.Common;
using DefaultNamespace.Common.UI;
using Other.MatchThreeGame.Assets.Scripts.Model;
using Other.MatchThreeGame.Assets.Scripts.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts
{
    public class SceneController : MonoBehaviour
    {

        public LoadingPanelBehaviour loadingPanelBehaviour;
        
        [SerializeField] private GameObject toastComponent;
        [SerializeField] private Button spellBookButton;
        [SerializeField] private Button inventoryBookButton;

        private ToastBehaviour _toastBehaviour;

        private GlobalSerializedState _globalSerializedState;

        private void Start()
        {
            StateManager stateManager = StateManager.Get();
            _toastBehaviour = toastComponent.GetComponent<ToastBehaviour>();
            _toastBehaviour.Init(stateManager);
            _globalSerializedState = GlobalSerializedState.Get();

            stateManager.SubscribeOnIsPlayersTurn(_ =>
            {
                spellBookButton.interactable = IsSpellBookButtonActive(stateManager);
                inventoryBookButton.interactable = stateManager.IsPlayersTurn;
            });

            stateManager.CastsLeftForPlayer.Subscribe(_ => spellBookButton.interactable = IsSpellBookButtonActive(stateManager), true);
        }

        public void ShowGoals(Level level)
        {
            _toastBehaviour.ShowGoal(level);
            // StartCoroutine(_toastBehaviour.ShowWithFlyAway("Победите противника", 1));            
        }

        public void ShowFailure()
        {
            _globalSerializedState.CurrentSceneId.Value = QuestSceneConstants.ThreeInArowFailureNodeId; 
                
            _toastBehaviour.ShowFailure(then: () =>
            {
                loadingPanelBehaviour.LoadScene(CrossSceneStorage.BackSceneName);
            });
        }

        public void ShowVictory()
        {
            _globalSerializedState.CurrentSceneId.Value = QuestSceneConstants.ThreeInARowVictoryNodeId;
            _toastBehaviour.ShowVictory(then: () =>
            {
                loadingPanelBehaviour.LoadScene(CrossSceneStorage.BackSceneName);
            });
        }

        private bool IsSpellBookButtonActive(StateManager stateManager)
        {
            int castsLeft = stateManager.CastsLeftForPlayer.Value;
            bool IsPlayersTurn = stateManager.IsPlayersTurn;

            return IsPlayersTurn && castsLeft > 0;
        }
    }
}