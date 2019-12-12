using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.AnimationPanel
{
    public class AnimationPanelPresenter : MonoBehaviour
    {
        public Image image;
        
        public void showImage(string path)
        {
            Sprite sprite = Resources.Load<Sprite>(path);
            image.sprite = sprite;
        }
    }
}