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