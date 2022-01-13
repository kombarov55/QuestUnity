using UnityEngine;
using UnityEngine.UI;

namespace QuestScene.Ui
{
    public class DialogBehaviour : MonoBehaviour
    {

        private Text _text;
        
        private void Start()
        {
            _text = gameObject.GetComponentsInChildren<Text>()[0];
            var okButton = gameObject.GetComponentInChildren<AudioButton>();
            okButton.OnClick = () => gameObject.SetActive(false);
        }

        public void Show(string text)
        {
            _text.text = text;
            gameObject.SetActive(true);
        }
    }
}