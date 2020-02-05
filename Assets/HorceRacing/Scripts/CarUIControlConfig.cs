using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

namespace DefaultNamespace.Scripts
{
    public class CarUIControlConfig : MonoBehaviour
    {

        public Image breakPedalImage;
        public Image gasPedalImage;
        public Image leftArrowImage;
        public Image rightArrowImage;

        public GameObject car;
        
        public void Start()
        {
            var breakPedalOnClickObservable = breakPedalImage.GetComponent<OnClickObservable>();
            var gasPedalOnClickObservable = gasPedalImage.GetComponent<OnClickObservable>();
            var leftArrowOnClickObservable = leftArrowImage.GetComponent<OnClickObservable>();
            var rightArrowOnClickObservable = rightArrowImage.GetComponent<OnClickObservable>();

            var carUserControl = car.GetComponentInChildren<CarUserControl>();

            breakPedalOnClickObservable.onPointerDownAction = () => carUserControl.v = -1;
            breakPedalOnClickObservable.onPointerUpAction = () => carUserControl.v = 0;
            
            gasPedalOnClickObservable.onPointerDownAction = () => carUserControl.v = 1;
            gasPedalOnClickObservable.onPointerUpAction = () => carUserControl.v = 0;
            
            leftArrowOnClickObservable.onPointerDownAction = () => carUserControl.h = -1;
            leftArrowOnClickObservable.onPointerUpAction = () => carUserControl.h = 0;
            
            rightArrowOnClickObservable.onPointerDownAction = () => carUserControl.h = 1;
            rightArrowOnClickObservable.onPointerUpAction = () => carUserControl.h = 0;
        }
    }
}