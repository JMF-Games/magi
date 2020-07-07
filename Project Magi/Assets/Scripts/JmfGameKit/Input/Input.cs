using System;
using UnityEngine;

namespace JmfGameKit.Input
{
    public class Input : MonoBehaviour, IInput
    {
        [SerializeField] string _horizontalAxis, _verticalAxis, _mouseXAxis, _mouseYAxis;

        Vector3 _mousePosition, _movementDirection;

        public Vector3 MovementDirection
        {
            get => _movementDirection;
            set => _movementDirection = value;
        }
        
        public Vector3 MousePosition
        {
            get => _mousePosition;
            set => _mousePosition = value;
        }

        void Update()
        {
            GetMouse();
            GetKey();
        }

        public float[] GetMouse()
        {
            _mousePosition.x = UnityEngine.Input.GetAxis(_mouseXAxis);
            _mousePosition.y = UnityEngine.Input.GetAxis(_mouseYAxis);

            var floatConversion = new[] {_mousePosition.x, _mousePosition.y};
            return floatConversion;
        }

        public float[] GetKey()
        {
            _movementDirection.x = UnityEngine.Input.GetAxis(_horizontalAxis);
            _movementDirection.y = UnityEngine.Input.GetAxis(_verticalAxis);
            
            var floatConversion = new[] {_movementDirection.x, _movementDirection.y};
            return floatConversion;
        }
    }
}
