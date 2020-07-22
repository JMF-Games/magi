using UnityEngine;

namespace JmfGameKit.Spells
{
    [CreateAssetMenu]
    public class ChangeScale : Spell
    {
        [SerializeField] Vector3 _sizeChange;
        Camera _camera;

        void OnEnable()
        {
            _camera = Camera.main;
        }
        
        public override void Cast(GameObject target)
        { 
           //var proximity = Vector3.Distance(_camera.gameObject.transform.position, target.transform.position);

           var targetLayerName = 1 << target.layer;
           var spellTargetLayerName = Layer.value;
           
           if (targetLayerName == spellTargetLayerName)
           {
               target.transform.localScale = new Vector3(_sizeChange.x, _sizeChange.y, _sizeChange.z);
           }
        }
    }
}
