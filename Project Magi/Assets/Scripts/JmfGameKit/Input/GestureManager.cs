using UnityEngine;

namespace JmfGameKit.Input
{
    public class GestureManager : MonoBehaviour
    {
        [SerializeReference] Gesture[] _gestures;
        [SerializeField] float _deadZone = 0f;
        [SerializeField] float _distance = 100f;
        [SerializeField] LayerMask _mask;
        [SerializeField] double _gestureDuration;
        Vector3 _startGesturePosition, _endGesturePosition;
        Camera _camera;
        Input _input;
        Ray _ray;
        RaycastHit _hit;
        GameObject _target;
        float _startTime;
        float _endTime;

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
            else if (_input.GetKeyUp(KeyCode.Mouse0))
                EndGesture();
        }

        void StartGesture()
        {
            _startTime = Time.time;
            _startGesturePosition = _input.MousePositionAxis;
            RayCast();
            Cursor.lockState = CursorLockMode.None;
        }

        void EndGesture()
        {
            _endTime = Time.time;
            _endGesturePosition = _input.MousePositionAxis;
            UpdateGesture();
           // _target = null;
            Cursor.lockState = CursorLockMode.Locked;
        }

        void UpdateGesture()
        {
            var swipeDistance = (_endGesturePosition - _startGesturePosition).magnitude;
            var swipeTime = _endTime - _startTime;

            if (swipeTime < _gestureDuration && swipeDistance > _deadZone)
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
