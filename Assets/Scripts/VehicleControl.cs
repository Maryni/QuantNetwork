using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Core.Controllers
{
    public class VehicleControl : MonoBehaviour
    {
        #region Inspector variables

        [SerializeField] private Rigidbody2D backTireRig;
        [SerializeField] private Rigidbody2D forwardTireRig;
        [SerializeField] private Rigidbody2D vehicleControllerRig;
        [SerializeField] private float speed;
        [SerializeField] private float angleRotation;
        [SerializeField] private float dampingRotation;

        #endregion Inspector variables

        #region public functions

        public void PushForward(float value)
        {
            forwardTireRig.AddTorque(-value * speed * Time.fixedDeltaTime);
            Quaternion currentRotation = transform.rotation;
            var rotationQ = transform.eulerAngles.z;
            rotationQ += rotationQ * Time.fixedDeltaTime;
            var rotationQFull = Quaternion.Euler(currentRotation.x,
                currentRotation.y,
                rotationQ);
            transform.rotation =
                Quaternion.Lerp(transform.rotation, rotationQFull, Time.fixedDeltaTime * dampingRotation);
        }

        public void PushBackward(float value)
        {
            backTireRig.AddTorque(-value * speed * Time.fixedDeltaTime);
            Quaternion currentRotation = transform.rotation;
            var rotationQ = transform.eulerAngles.z;
            rotationQ -= rotationQ * Time.fixedDeltaTime;
            var rotationQFull = Quaternion.Euler(currentRotation.x,
                currentRotation.y,
                rotationQ);
            transform.rotation =
                Quaternion.Lerp(transform.rotation, rotationQFull, Time.fixedDeltaTime * dampingRotation);
        }

        public void PushVehicle(float value)
        {
            vehicleControllerRig.AddTorque(-value * speed * Time.fixedDeltaTime);
        }


        #endregion public functions

    }
}
