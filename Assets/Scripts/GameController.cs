using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI.Buttons;

namespace Core.Controllers
{
    public class GameController : MonoBehaviour
    {
        #region Inspector variables

        [SerializeField] private VehicleControl vehicleControl;
        [SerializeField] private UIButtons uiButtons;

        #endregion Inspector variables

        #region Unity functions

        private void Start()
        {
            uiButtons.AddAction(TypePedal.Left, () => vehicleControl.PushBackward(-1f));
            uiButtons.AddAction(TypePedal.Left, () => vehicleControl.PushVehicle(-1f));
            uiButtons.AddAction(TypePedal.Right, () => vehicleControl.PushForward(1f));
            uiButtons.AddAction(TypePedal.Right, () => vehicleControl.PushVehicle(1f));
        }

        #endregion Unity functions
    }
}
