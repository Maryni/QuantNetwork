using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Camera
{
    public class CameraFollow : MonoBehaviour
    {
        #region Inspector variables

        [SerializeField] private Transform targetLookAt;

        #endregion Inspector variables

        #region private variables

        private Vector3 offset;

        #endregion private variables

        #region Unity functions

        private void Start()
        {
            offset = transform.position - targetLookAt.position;
        }

        private void Update()
        {
            transform.position = targetLookAt.position + offset;
        }

        #endregion Unity functions
    }
}
