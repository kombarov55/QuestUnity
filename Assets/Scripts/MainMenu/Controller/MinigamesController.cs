using UnityEngine;

namespace DefaultNamespace.Controller
{
    public class MinigamesController : MonoBehaviour
    {
        private SceneController _sceneController;
        
        private AudioButton _threeInARowButton;
        private AudioButton _backButton;
        
        private void Start()
        {
            _sceneController = Context.SceneController();
            
            _threeInARowButton = GameObject.Find("ThreeInARowButton").GetComponent<AudioButton>();
            _threeInARowButton.OnClick = () => _sceneController.ToThreeInARow();

            _backButton = GameObject.Find("BackButton").GetComponent<AudioButton>();
            _backButton.OnClick = () => _sceneController.ShowMainMenu();
        } 
    }
}