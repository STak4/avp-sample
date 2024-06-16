using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace STak4
{
    public class AnimatorTrigger : MonoBehaviour
    {
        public Material TargetMaterial;
        public float TransitionTime = 3.0f;
        private MeshRenderer _renderer;
        private MaterialPropertyBlock _propertyBlock;

        private readonly string _blendKey = "_Blend";
        // Start is called before the first frame update
        void Start()
        {
            _renderer = GetComponent<MeshRenderer>();
            _propertyBlock = new MaterialPropertyBlock();
        }

        public void OnReset()
        {
            TargetMaterial.SetFloat(_blendKey,0f);
        }

        public void OnClear()
        {
            StartCoroutine(TransitionRoutine(1.0f, TransitionTime));
        }

        IEnumerator TransitionRoutine(float target, float duration)
        {
            var current = 0f;
            var startTime = Time.time;

            while (current < target)
            {
                current = (Time.time - startTime) / duration;
                TargetMaterial.SetFloat(_blendKey, current);
                yield return null;
            }
        }
    }

}