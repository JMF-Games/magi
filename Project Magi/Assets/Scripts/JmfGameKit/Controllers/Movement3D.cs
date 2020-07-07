using System;
using JmfGameKit.Input;
using UnityEngine;

namespace JmfGameKit.Controllers
{
    public class Movement3D : MonoBehaviour, IController
    {
        [SerializeField] Input.Input _input;
        GameObject _gameObjectToMove;
        Vector3 _directionToMoveIn;
        
        [SerializeField] float _speed;

        void Awake()
        {
            _gameObjectToMove = gameObject;
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
            _gameObjectToMove.transform.position += new Vector3
                (
                (_directionToMoveIn.x + _input.MovementDirection.x) * _speed * Time.fixedDeltaTime,
                0f, 
                (_directionToMoveIn.z + _input.MovementDirection.y) * _speed * Time.fixedDeltaTime
                );
        }
    }
}
