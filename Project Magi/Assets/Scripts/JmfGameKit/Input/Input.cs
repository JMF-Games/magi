using System;
using UnityEngine;

namespace JmfGameKit.Input
{
    public class Input : MonoBehaviour, IInput
    {
        #region Variables

        Vector2 _mousePositionAxis;
        Vector2 _mousePosition;

        public Vector2 MousePositionAxis
        {
            get
            {
                _mousePositionAxis = new Vector2(UnityEngine.Input.GetAxis("Mouse X"), UnityEngine.Input.GetAxis("Mouse Y"));
                return _mousePositionAxis;
            }
        }

        public Vector2 MousePosition => UnityEngine.Input.mousePosition;

        #endregion

        #region Methods

        public bool GetKeyDown(KeyCode button)
        {
            return UnityEngine.Input.GetKeyDown(button);
        }
        
        public bool GetKeyUp(KeyCode button)
        {
            return UnityEngine.Input.GetKeyUp(button);
        }

        public float GetAxis(string axis)
        {
            return UnityEngine.Input.GetAxis(axis);
        }

        #endregion
    }
}
