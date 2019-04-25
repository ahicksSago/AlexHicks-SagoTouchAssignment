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
        public void OnEnable() {
            this.TouchAreaObserver.TouchUpDelegate = OnTouchUp;
        }

        public void OnDisable() {
            this.TouchAreaObserver.TouchUpDelegate = null;
        }

        public void OnTouchUp(TouchArea touchArea, Touch touch) {
            Debug.LogFormat("Touch Up: {0}", this);
        }
        #endregion
    }
}
