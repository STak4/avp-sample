using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace STak4
{
    public class ClearTrigger : MonoBehaviour
    {
        public UnityEvent OnTriggered = new UnityEvent();
        public string TargetColliderTag = "Clear";
        private void OnTriggerEnter(Collider other)
        {
            if (string.Equals(other.tag, TargetColliderTag, StringComparison.OrdinalIgnoreCase))
            {
                Debug.Log("[ClearTrigger] Clear");
                OnTriggered?.Invoke();
            }
        }
    }

}
