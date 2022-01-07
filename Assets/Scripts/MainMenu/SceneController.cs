using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class SceneController : MonoBehaviour
    {
        public GameObject mainMenuComponentPrefab;
        public GameObject miniGamesComponentPrefab;
        
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
            SceneManager.LoadScene("Scenes/QuestScene");
        }
        
        public void ToThreeInARow()
        {
            SceneManager.LoadScene("Other/MatchThreeGame/Assets/Scenes/mainGame");
            CrossSceneStorage.BackSceneName = "Scenes/MainMenu";
        }
    }
}