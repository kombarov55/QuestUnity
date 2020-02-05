using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Scripts
{
    public class DoSomethingScript : MonoBehaviour
    {
        public Image doSomethingButton;
        public GameObject animationContainer;
        
        public void Start()
        {
            var animator = animationContainer.GetComponentInChildren<Animator>();
            var onClickObservable = doSomethingButton.GetComponent<OnClickObservable>();

            onClickObservable.onPointerDownAction = () =>
            {
                animator.enabled = true;
                animator.Play("CountdownAnimation", 0, 0f);
            };
        }
    }
}