using UnityEngine;

namespace DefaultNamespace.Controller
{
    public class MainMenuController : MonoBehaviour
    {

        private SceneController _sceneController;
        
        private AudioButton _audioButton;
        private AudioButton _minigamesButton;
        private AudioButton _continueButton;
        private void Start()
        {
            _sceneController = Context.SceneController(); 
            
            _audioButton = GameObject.Find("StartGameButton").GetComponent<AudioButton>();
            _audioButton.OnClick = () =>
            {
                CachedPrefs.Reset();
                _sceneController.ToQuest();
            };

            _minigamesButton = GameObject.Find("ToMinigamesButton").GetComponent<AudioButton>();
            _minigamesButton.OnClick = () => _sceneController.ShowMinigames();

            _continueButton = GameObject.Find("ContinueButton").GetComponent<AudioButton>();
            
            if (CachedPrefs.IsGameStarted())
            {
                _continueButton.OnClick = () => _sceneController.ToQuest();
            }
            else
            {
                _continueButton.gameObject.SetActive(false);
            }
        }
    }
}