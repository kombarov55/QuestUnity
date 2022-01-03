using UnityEngine;

namespace DefaultNamespace.Controller
{
    public class MainMenuController : MonoBehaviour
    {

        private SceneController _sceneController;
        
        private AudioButton _audioButton;
        private AudioButton _minigamesButton;
        private void Start()
        {
            _sceneController = Context.SceneController(); 
            
            _audioButton = GameObject.Find("StartGameButton").GetComponent<AudioButton>();
            _audioButton.OnClick = () => _sceneController.ToQuest();

                _audioButton = GameObject.Find("ToMinigamesButton").GetComponent<AudioButton>();
            _audioButton.OnClick = () => _sceneController.ShowMinigames();
        }
    }
}