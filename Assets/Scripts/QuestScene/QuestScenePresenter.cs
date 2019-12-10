using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class
        QuestScenePresenter : MonoBehaviour
    {
        private Action<int> choiceHandler;

        public Text title;
        public Image img;
        public Text description;
        public GameObject buttonsPanel;

        public GameObject buttonPrefab;

        private List<GameObject> buttons = new List<GameObject>();

        public void setTitle(string str)
        {
            title.text = str;
        }

        public void setImg(string path)
        {
//            img.sprite = Resources.Load<Sprite>(path);
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
                gameObject.AddComponent<OnClickComponent>();
                var valueToInvoke = i;
                gameObject.GetComponent<OnClickComponent>().action = () => choiceHandler.Invoke(valueToInvoke);

                buttons.Add(gameObject);
            }    
        }
    }
}