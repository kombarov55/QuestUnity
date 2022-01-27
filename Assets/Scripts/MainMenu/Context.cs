using DefaultNamespace.Controller;
using UnityEngine;

namespace DefaultNamespace
{
    public class Context
    {

        public static AudioScript AudioScript()
        {
            var go = GameObject.FindWithTag("Audio");
            if (go != null)
            {
                return go.GetComponent<AudioScript>();
            }
            else
            {
                return null;
            }
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