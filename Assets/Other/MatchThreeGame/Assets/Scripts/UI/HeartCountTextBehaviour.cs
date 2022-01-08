using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class HeartCountTextBehaviour : MonoBehaviour
    {
        private void Start()
        {
            Text text = GetComponent<Text>();
            CachedUserData cachedUserData = CachedUserData.Get();
            text.text = cachedUserData.ThreeInARowLifes.ToString();
        }
    }
}