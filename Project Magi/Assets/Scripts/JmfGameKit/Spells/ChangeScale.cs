using UnityEngine;

namespace JmfGameKit.Spells
{
    [CreateAssetMenu]
    public class ChangeScale : Spell
    {
        [SerializeField] Vector3 _sizeChange;
        [SerializeField] float _duration = 0;
        Camera _camera;

        void OnEnable()
        {
            _camera = Camera.main;
        }
        
        public override void Cast(GameObject target)
        {
            Debug.Log("CAST");
            
           var proximity = Vector3.Distance(_camera.gameObject.transform.position, target.transform.position);

           var targetLayerName = 1 << target.layer;
           var spellTargetLayerName = Layer.value;
           
           if (proximity <= Distance && targetLayerName == spellTargetLayerName)
           {
               //Vector3.Lerp(target.transform.localScale, _sizeChange, _duration);
               target.transform.localScale = new Vector3(.1f, .1f, .1f);
           }
        }
    }
}
