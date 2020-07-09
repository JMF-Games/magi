using UnityEngine;

namespace JmfGameKit.Controllers
{
    public class Movement3D : MonoBehaviour, IController
    {
        #region Variables

        [SerializeField] float _speed = 2f;
        
        Input.Input _input;
        GameObject _gameObjectToMove;
        Vector3 _directionToMoveIn;

        float _xDirection = 0f;
        float _yDirection = 0f;

        #endregion
        
        #region Methods

        void Awake()
        {
            _gameObjectToMove = gameObject;
            _input = GetComponent<Input.Input>();
        }

        void Update()
        {
            GetMouseInput();
            Move();
        }

        public void Move()
        {
            _gameObjectToMove.transform.Translate
            (
                _xDirection,
                0f, 
                _yDirection
            );
        }
        
        #endregion

        #region HelperMethods

        void GetMouseInput()
        {
            _xDirection = _input.GetAxis("Horizontal") * _speed * Time.fixedDeltaTime;
            _yDirection = _input.GetAxis("Vertical") * _speed * Time.fixedDeltaTime;
        }
        
        #endregion
    }
}
