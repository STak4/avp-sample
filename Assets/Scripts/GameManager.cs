using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace STak4
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private float resetInterval = 1.0f;
        [SerializeField] private float autoResetInterval = 10f;
        public UnityEvent OnCleared = new UnityEvent();
        public UnityEvent OnReset = new UnityEvent();

        private bool isProcessing = false;

        private void Start()
        {
            Reset();
        }

        public void Reset()
        {
            if(isProcessing) return;
            StartCoroutine(OnResetRoutine());
        }
        
        public void Clear()
        {
            if(isProcessing) return;
            StartCoroutine(OnClearRoutine());
        }

        IEnumerator OnClearRoutine()
        {
            isProcessing = true;
            Debug.Log("[GameManager] Clear");
            OnCleared?.Invoke();
            yield return new WaitForSeconds(autoResetInterval);
            isProcessing = false;
            Reset();
        }

        IEnumerator OnResetRoutine()
        {
            isProcessing = true;
            OnReset?.Invoke();
            Debug.Log("[GameManager] Reset");
            yield return new WaitForSeconds(resetInterval);            
            isProcessing = false;
        }
    }
}
