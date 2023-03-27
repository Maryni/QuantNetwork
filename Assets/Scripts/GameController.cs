using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Inspector variables

    [SerializeField] private VehicleControl vehicleControl;
    [SerializeField] private UIButtons uiButtons;
    [SerializeField] private Timer timer;

    #endregion Inspector variables

    #region Unity functions

    private void Start()
    {
        timer.AddActionOnTimerFinish(vehicleControl.RotateToNormal);
        timer.StartTimer();
        uiButtons.AddAction(TypePedal.Left, vehicleControl.PushForward);
        uiButtons.AddAction(TypePedal.Left, timer.StartTimer);
        uiButtons.AddAction(TypePedal.Right, vehicleControl.PushBackward);
        uiButtons.AddAction(TypePedal.Right, timer.StartTimer);
    }

    #endregion Unity functions
}
