using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace STak4
{
    public class MeshMaterialSetter : MonoBehaviour
    {
        [SerializeField] private ARMeshManager meshManager;

        public void SetMaterials(Material mat)
        {
            foreach (var mesh in meshManager.meshes)
            {
                mesh.GetComponent<MeshRenderer>().material = mat;
            }
        }
    }
}
