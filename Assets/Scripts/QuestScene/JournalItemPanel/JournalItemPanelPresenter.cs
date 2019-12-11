using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.JournalItemPanel
{
    public class JournalItemPanelPresenter : MonoBehaviour
    {
        public Image backgroundImg;
        public Text titleText;
        public Text descriptionText;

        private AudioScript audioScript;

        public void init(AudioScript audioScript)
        {
            this.audioScript = audioScript;
        }

        public void setImage(string path)
        {
            Sprite sprite = Resources.Load<Sprite>(path);
            backgroundImg.sprite = sprite;
        }

        public void setTitle(string str)
        {
            titleText.text = str;
        }

        public void setDescription(string str)
        {
            descriptionText.text = str;
        }

        public void playOnButtonClickSound()
        {
            audioScript.playButtonClickSound();
        }
    }
}