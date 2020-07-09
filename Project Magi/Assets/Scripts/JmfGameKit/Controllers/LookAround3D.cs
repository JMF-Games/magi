using UnityEngine;

namespace JmfGameKit.Controllers
{
    public class LookAround3D : MonoBehaviour, IController
    {
        #region Variables
        
        [SerializeField] float _sensitivity = 100f;
        [SerializeField] float _clampAngle = 90f;

        Camera _mainCam;
        Input.Input _input;

        float _xRotation = 0f, _yRotation = 0f;
        
        #endregion

        #region Methods

        void Awake()
        {
            _input = GetComponent<Input.Input>();
            _mainCam = Camera.main;

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            GetMouseInput();
            Move();
        }

        public void Move()
        {
            RotateCameraY();
            RotateObjectX();
        }

        #endregion

        #region  HelperMethods
        
        void GetMouseInput()
        {
            _xRotation = _input.GetAxis("Mouse X") * _sensitivity * Time.fixedDeltaTime;
            _yRotation -= _input.GetAxis("Mouse Y") * _sensitivity * Time.fixedDeltaTime;
        }

        void RotateCameraY()
        {
            _yRotation = Mathf.Clamp(_yRotation, -_clampAngle, _clampAngle);
            _mainCam.transform.localRotation = Quaternion.Euler(_yRotation, 0, 0);
        }

        void RotateObjectX()
        {
            transform.Rotate(0, _xRotation, 0);
        }

        #endregion
    }
}
