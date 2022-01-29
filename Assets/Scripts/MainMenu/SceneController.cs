using DefaultNamespace.Common;
using DefaultNamespace.Common.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class SceneController : MonoBehaviour
    {
        public GameObject mainMenuComponentPrefab;
        public GameObject miniGamesComponentPrefab;
        public GameObject dialogComponentPrefab;

        public LoadingPanelBehaviour loadingPanelBehaviour;

        private GlobalSerializedState _globalSerializedState;

        private void Start()
        {
            _globalSerializedState = GlobalSerializedState.Get();
        }
        
        public void ShowMinigames()
        {
            mainMenuComponentPrefab.SetActive(false);
            miniGamesComponentPrefab.SetActive(true);
        }

        public void ShowMainMenu()
        {
            mainMenuComponentPrefab.SetActive(true);
            miniGamesComponentPrefab.SetActive(false);
        }

        public void ToQuest()
        {
            _globalSerializedState.IsGameStarted.Value = true;
            loadingPanelBehaviour.LoadScene("Scenes/QuestScene");
        }
        
        public void ToThreeInARow()
        {
            loadingPanelBehaviour.LoadScene("Other/MatchThreeGame/Assets/Scenes/mainGame");
            CrossSceneStorage.BackSceneName = "Scenes/MainMenu";
        }

        public void ShowDialog()
        {
            dialogComponentPrefab.SetActive(true);
        }
    }
}