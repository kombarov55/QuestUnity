using DefaultNamespace.Common;
using UnityEngine;

namespace DefaultNamespace.Controller
{
    public class MainMenuController : MonoBehaviour
    {

        private SceneController _sceneController;
        
        private AudioButton _audioButton;
        private AudioButton _minigamesButton;
        private AudioButton _continueButton;

        private GlobalSerializedState _globalSerializedState;
        private void Start()
        {
            _globalSerializedState  = GlobalSerializedState.Get();
            _sceneController = Context.SceneController(); 
            
            _audioButton = GameObject.Find("StartGameButton").GetComponent<AudioButton>();
            _audioButton.OnClick = () =>
            {
                _globalSerializedState.Reset();
                _sceneController.ToQuest();
            };

            _minigamesButton = GameObject.Find("ToMinigamesButton").GetComponent<AudioButton>();
            _minigamesButton.OnClick = () => _sceneController.ShowMinigames();

            _continueButton = GameObject.Find("ContinueButton").GetComponent<AudioButton>();
            
            if (_globalSerializedState.IsGameStarted.Value)
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