using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace STak4
{
    public class ImageTrackedContainer : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Image manager on the AR Session Origin")]
        ARTrackedImageManager m_ImageManager;

        [SerializeField]
        [Tooltip("Reference Image Library")]
        XRReferenceImageLibrary m_ImageLibrary;

        [SerializeField] private GameObject trackedTarget;
        

        void OnEnable()
        {
            m_ImageManager.trackedImagesChanged += ImageManagerOnTrackedImagesChanged;
        }

        void OnDisable()
        {
            m_ImageManager.trackedImagesChanged -= ImageManagerOnTrackedImagesChanged;
        }

        void ImageManagerOnTrackedImagesChanged(ARTrackedImagesChangedEventArgs obj)
        {
            // added, spawn prefab
            foreach (var image in obj.added)
            {
                var guid = image.referenceImage.guid;
                var imageTransform = image.transform;
                trackedTarget.transform.position = imageTransform.position;
                trackedTarget.transform.rotation = imageTransform.rotation;
            }

            // updated, set prefab position and rotation
            foreach (var image in obj.updated)
            {
                var guid = image.referenceImage.guid;
                var imageTransform = image.transform;
                trackedTarget.transform.position = imageTransform.position;
                trackedTarget.transform.rotation = imageTransform.rotation;
            }

            // removed, destroy spawned instance
            foreach (var image in obj.removed)
            {

            }
        }
    }
}
