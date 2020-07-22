using System;
using JmfGameKit.Spells;
using UnityEngine;

namespace JmfGameKit.Input
{
    [CreateAssetMenu]
    public class SwipeUpGesture : Gesture
    {
        [SerializeField] Spell _spell;

        public override void Execute(Vector3 oldPos, Vector3 newPos, GameObject target)
        {
            var distance = newPos - oldPos;
            
            if (!(Mathf.Abs(distance.y) > Mathf.Abs(distance.x))) return;
            
            if (newPos.y > 0)
            {
                _spell.Cast(target);
            }
        }
    }
}
