namespace Project
{
    using System.Collections;
    using System.Collections.Generic;
    using SagoTouch;
    using Touch = SagoTouch.Touch;
    using UnityEngine;

    public class CustomTouch : MonoBehaviour, ISingleTouchObserver {

        #region Non Serialized 
        [System.NonSerialized]
        private Camera m_Camera;

        [System.NonSerialized]
        private Renderer m_Renderer;

        [System.NonSerialized]
        private Transform m_Transform;

        //[System.NonSerialized]
        //private Touch m_Touch;

        [System.NonSerialized]
        private List<Touch> m_Touches;
        #endregion


        #region Properties
        public Camera Camera {
            get { return m_Camera = m_Camera ?? CameraUtils.FindRootCamera(this.Transform); }
        }

        public Renderer Renderer {
            get { return m_Renderer = m_Renderer ?? GetComponent<Renderer>(); }
        }

        public Transform Transform {
            get { return m_Transform = m_Transform ?? GetComponent<Transform>(); }
        }

        public List<Touch> Touches {
            get { return m_Touches = m_Touches ?? new List<Touch>(); }
        }
        #endregion


        #region Unity Functions
        //Register with the TouchDispatcher
        public void OnEnable() {
            if (TouchDispatcher.Instance) {
                TouchDispatcher.Instance.Add(this, 0, true);
            }
        }

        //Deregister with the TouchDispatcher
        public void OnDisable() {
            if (TouchDispatcher.Instance) {
                TouchDispatcher.Instance.Remove(this);
            }
        }
        #endregion


        #region General Functions
        //Hit Testing
        private bool HitTest(Touch touch) {
            var bounds = this.Renderer.bounds;
            bounds.extents += Vector3.forward;
            return bounds.Contains(CameraUtils.TouchToWorldPoint(touch, this.Transform, this.Camera));
        }
        #endregion

        #region ISingleTouchObserver
        public bool OnTouchBegan(Touch touch) {
            //Single Touch Behaviour
            //if(m_Touch == null && HitTest(touch)) {
            //    m_Touch = touch;
            //    return true;
            //}

            //Mutitouch Behaviour
            if(HitTest(touch)) {
                this.Touches.Add(touch);
                return true;
            }

            return false;
        }

        public void OnTouchMoved(Touch touch)  {
            //
        }

        public void OnTouchEnded(Touch touch) {
            //Single touch behaviour
            //m_Touch = null;

            //Mutitouch behaviour
            this.Touches.Remove(touch);
        }

        public void OnTouchCancelled(Touch touch) {
            OnTouchEnded(touch);
        }
        #endregion
    }

}

