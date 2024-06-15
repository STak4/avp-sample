using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace STak4
{
    public class SpawnObject : MonoBehaviour
    {
        [SerializeField] private GameObject spawnPrefab;
        [SerializeField] private Transform spawnTransform;

        private List<GameObject> _spawned = new List<GameObject>();
        public List<GameObject> SpawnedObjects => _spawned;
        
        public void Spawn()
        {
            var obj = GameObject.Instantiate(spawnPrefab, spawnTransform);
            _spawned.Add(obj);
        }
    }
}
