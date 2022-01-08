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
            _threeInARowButton.OnClick = () =>
            {
                if (0 > 0)
                {
                    _sceneController.ToThreeInARow();                    
                }
                else
                {
                    _sceneController.ShowDialog();
                }
                
            };

            _backButton = GameObject.Find("BackButton").GetComponent<AudioButton>();
            _backButton.OnClick = () => _sceneController.ShowMainMenu();
        } 
    }
}