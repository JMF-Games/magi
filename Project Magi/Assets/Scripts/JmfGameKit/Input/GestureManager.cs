using System;
using UnityEngine;

namespace JmfGameKit.Input
{
    public class GestureManager : MonoBehaviour
    {
        [SerializeReference] Gesture[] _gestures;
        [SerializeField] float _deadZone = 0f;
        [SerializeField] float _distance = 100f;
        [SerializeField] LayerMask _mask;

        Vector3 _startGesturePosition, _endGesturePosition;
        Camera _camera;
        Input _input;
        Ray _ray;
        RaycastHit _hit;
        GameObject _target;

        void Awake()
        {
            _input = FindObjectOfType<Input>();

            _camera = Camera.main;

            Cursor.visible = false;
            
            foreach (var gesture in _gestures)
            {
                gesture.Initialize(_input);
            }
        }

        void Update()
        {
            if (_input.GetKeyDown(KeyCode.Mouse0))
                StartGesture();
            
            if (_input.GetKeyUp(KeyCode.Mouse0))
                EndGesture();
        }

        void StartGesture()
        {
            _startGesturePosition = _input.MousePositionAxis;

            Debug.Log(_startGesturePosition);

            RayCast();
            
            Cursor.lockState = CursorLockMode.None;
        }

        void EndGesture()
        {
            _endGesturePosition = _input.MousePositionAxis;
            
            Debug.Log(_endGesturePosition);

            UpdateGesture();

            _target = null;

           Cursor.lockState = CursorLockMode.Locked;
        }

        void UpdateGesture()
        {
            var swipeDistance = Vector3.Distance(_endGesturePosition, _startGesturePosition);
            
            Debug.Log(swipeDistance);

            if (swipeDistance > _deadZone)
            {
                foreach (var gesture in _gestures)
                {
                    if (!_target) return;
                    gesture.Execute(_startGesturePosition,_endGesturePosition, _target);
                }
            }
        }
        
        void RayCast()
        {
            _ray = _camera.ScreenPointToRay(_input.MousePosition);
            if (Physics.Raycast(_ray, out _hit, _distance, _mask))
            {
                _target = _hit.collider.gameObject;
                Debug.Log(_target);
            }
        }
    }
}
