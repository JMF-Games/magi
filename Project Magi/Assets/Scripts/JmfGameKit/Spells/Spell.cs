using System;
using UnityEngine;

namespace JmfGameKit.Spells
{
    public class Spell : ScriptableObject, ISpell
    {
        [SerializeField] float _distance = 100f;
        [SerializeField] LayerMask _layerMask;

        protected float Distance => _distance;
        protected LayerMask Layer => _layerMask;

        public virtual void Cast(GameObject target)
        {
            
        }
    }
}
