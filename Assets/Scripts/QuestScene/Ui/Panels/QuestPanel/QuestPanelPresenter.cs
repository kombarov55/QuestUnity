using System;
using System.Collections.Generic;
using DefaultNamespace.model;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class QuestPanelPresenter : MonoBehaviour
    {
        private Action<QuestNodeChoice> choiceHandler;

        public Text title;
        public Image img;
        public Text description;
        public GameObject buttonsPanel;
        public GameObject buttonPrefab;

        public AudioScript audioScript;

        private List<GameObject> buttons = new List<GameObject>();

        private string prevBackground = "";

        public void init(AudioScript audioScript, Image background)
        {
            this.audioScript = audioScript;
            img = background;
        }

        public void setTitle(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                title.gameObject.SetActive(false);
            }
            else
            {
                title.gameObject.SetActive(true);
                title.text = str;                
            }
        }

        public void setImg(string path)
        {
            if (path != null && path != "" && prevBackground != path)
            {
                img.sprite = Resources.Load<Sprite>(path);
                prevBackground = path;
            }
        }

        public void setDescription(string str)
        {
            description.text = str;
        }

        public void setChoices(List<QuestNodeChoice> choices)
        {
            clearChoices();
            instantiateChoiceButtons(choices);
        }

        public void setChoiceHandler(Action<QuestNodeChoice> choiceHandler)
        {
            this.choiceHandler = choiceHandler;
        }

        public void playClickingSound()
        { 
            audioScript.PlayButtonClickSound();
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

        private void instantiateChoiceButtons(List<QuestNodeChoice> choices)
        {
            for (var i = 0; i < choices.Count; i++)
            {
                var choice = choices[i];
                var gameObject = Instantiate(buttonPrefab, buttonsPanel.transform);
                gameObject.GetComponent<Button>().gameObject.GetComponentInChildren<Text>().text = choice.text;
                gameObject.AddComponent<OnClickComponent>().audioScript = audioScript;
                var choiceToInvoke = choice;
                gameObject.GetComponent<OnClickComponent>().action = () => choiceHandler.Invoke(choiceToInvoke);

                buttons.Add(gameObject);
            }    
        }
    }
}