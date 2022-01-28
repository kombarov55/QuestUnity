using System.Collections;
using UnityEngine;

namespace Other.MatchThreeGame.Assets.Scripts.UI
{
    public class BounceBehaviour : MonoBehaviour
    {
        public void Run()
        {
            StartCoroutine(Bounce());
        }

        private IEnumerator Bounce()
        {
            gameObject.transform.scaleTo(0.25f, 1.5f);
            yield return new WaitForSeconds(0.25f);
            gameObject.transform.scaleTo(0.25f, 1f);
        }
    }
}