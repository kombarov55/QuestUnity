using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class QuestPanelPresenter : MonoBehaviour
    {
        private Action<int> choiceHandler;

        public Text title;
        public Image img;
        public Text description;
        public GameObject buttonsPanel;
        public GameObject buttonPrefab;

        public AudioScript audioScript;

        private List<GameObject> buttons = new List<GameObject>();

        public void init(AudioScript audioScript, Image background)
        {
            this.audioScript = audioScript;
            img = background;
        }

        public void setTitle(string str)
        {
            title.text = str;
        }

        public void setImg(string path)
        {
            if (path != null && path != "")
            {
                img.sprite = Resources.Load<Sprite>(path);
            }
        }

        public void setDescription(string str)
        {
            description.text = str;
        }

        public void setChoices(List<string> choices)
        {
            clearChoices();
            instantiateChoiceButtons(choices);
        }

        public void setChoiceHandler(Action<int> choiceHandler)
        {
            this.choiceHandler = choiceHandler;
        }

        public void playClickingSound()
        { 
            audioScript.playButtonClickSound();
        }

        private void clearChoices()
        {
            buttonsPanel.transform.DetachChildren();
            foreach (var button in buttons)
            {
                Destroy(button);
            }

            buttons.Clear();
        }

        private void instantiateChoiceButtons(List<string> choices)
        {
            for (var i = 0; i < choices.Count; i++)
            {
                string choiceText = choices[i];
                var gameObject = Instantiate(buttonPrefab, buttonsPanel.transform);
                gameObject.GetComponent<Button>().gameObject.GetComponentInChildren<Text>().text = choiceText;
                gameObject.AddComponent<OnClickComponent>().audioScript = audioScript;
                var valueToInvoke = i;
                gameObject.GetComponent<OnClickComponent>().action = () => choiceHandler.Invoke(valueToInvoke);

                buttons.Add(gameObject);
            }    
        }
    }
}