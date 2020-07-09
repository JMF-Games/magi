using System;
using UnityEngine;

namespace JmfGameKit.Input
{
    public class Gesture : ScriptableObject
    {
        private Input _input;

        public void Initialize(IInput input)
        {
            _input = (Input)input;
        }

        public virtual void Execute(Vector3 endGesturePosition, Vector3 newPos, GameObject target)
        {
            
        }
    }
}
