using JmfGameKit.Input;
using UnityEngine;

namespace JmfGameKit.Controllers
{
    public class LookAround3D : MonoBehaviour, IController
    {
        [SerializeField] Input.Input _input;
        [SerializeField] float _sensitivity = 1f;
        [SerializeField] float _clampAngle = 90f;
        float _xRotation = 0f;
        GameObject _gameObjectToLook;
        Vector3 _directionToMoveIn;
        
        [SerializeField] float _speed;

        void Awake()
        {
            _gameObjectToLook = gameObject;
            _input = GetComponent<Input.Input>();
            
            // default position
            _directionToMoveIn = new Vector3(0f, 2.5f, 0f);
        }

        void Update()
        {
            Move();
        }

        public void Move()
        {
            _gameObjectToLook.transform.position += new Vector3
            (
                (_directionToMoveIn.x + _input.MovementDirection.x) * _speed * Time.fixedDeltaTime,
                0f, 
                (_directionToMoveIn.z + _input.MovementDirection.y) * _speed * Time.fixedDeltaTime
            );
        }
    }
}
