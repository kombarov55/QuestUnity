using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ChangeImgAlpha : MonoBehaviour
    {

        public float alpha;
        
        public void Start()
        {
            var img = GetComponent<Image>();
            img.color = new Color(img.color.r, img.color.g, img.color.b, alpha);
        }
    }
}