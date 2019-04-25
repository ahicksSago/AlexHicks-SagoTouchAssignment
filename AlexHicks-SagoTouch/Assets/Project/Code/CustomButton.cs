namespace Project {

    using System.Collections;
    using System.Collections.Generic;
    using SagoTouch;
    using Touch = SagoTouch.Touch;
    using UnityEngine;

    public class CustomButton : MonoBehaviour {

        #region Fields
        [System.NonSerialized]
        private TouchArea m_TouchArea;

        [System.NonSerialized]
        private TouchAreaObserver m_TouchAreaObserver;
        #endregion


        #region Properties
        public TouchArea TouchArea {
            get { return m_TouchArea = m_TouchArea ?? GetComponent<TouchArea>(); }
        }

        public TouchAreaObserver TouchAreaObserver {
            get { return m_TouchAreaObserver = m_TouchAreaObserver ?? GetComponent<TouchAreaObserver>(); }
        }
        #endregion


        #region Methods
        public void Update() {
            if (Input.GetKeyUp(KeyCode.P)) {
                DisableTouchArea();
            }

            if (Input.GetKeyUp(KeyCode.O)) {
                EnableTouchArea();
            }
        }

        public void OnEnable() {
            this.TouchAreaObserver.TouchUpDelegate = OnTouchUp;
        }

        public void OnDisable() {
            this.TouchAreaObserver.TouchUpDelegate = null;
        }

        public void OnTouchUp(TouchArea touchArea, Touch touch) {
            Debug.LogFormat("Touch Up: {0}", this);
        }

        #region Touch Area
        //Disable our Touch Area
        private void DisableTouchArea() {
            this.TouchArea.enabled = false;
        }

        //Enable our Touch Area
        private void EnableTouchArea() {
            this.TouchArea.enabled = true;
        }
        #endregion


        #region Touch Dispatcher 
        //Disable All input
        private void DisableAllTouchInput() {
            if(TouchDispatcher.Instance) {
                TouchDispatcher.Instance.enabled = false;
            }
        }

        //Enable all input
        private void EnableAllTouchInput() {
            if (TouchDispatcher.Instance) {
                TouchDispatcher.Instance.enabled = true;
            }
        }
        #endregion
        #endregion
    }
}
