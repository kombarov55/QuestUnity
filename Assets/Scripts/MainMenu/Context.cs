using DefaultNamespace.Controller;
using UnityEngine;

namespace DefaultNamespace
{
    public class Context
    {

        private static AudioScript _audioScript;
        
        public static AudioScript AudioScript()
        {
            if (_audioScript == null)
            {
                var go = GameObject.Find("Audio");
                if (go != null)
                {
                    _audioScript = go.GetComponent<AudioScript>();
                }
            }

            return _audioScript;
        }

        public static AudioButton FindButton(string name)
        {
            return GameObject.Find("StartGameButton").GetComponent<AudioButton>();
        }

        public static SceneController SceneController()
        {
            return GameObject.Find("SceneController").GetComponent<SceneController>();
        }
        
        public static MainMenuController MainMenuController()
        {
            return GameObject.Find("MainMenuComponent").GetComponent<MainMenuController>();
        }
        
        public static MinigamesController minigamesController()
        {
            return GameObject.Find("MinigamesComponent").GetComponent<MinigamesController>();
        }
    }
}