using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{

    #region enum

    public enum TypePedal
    {
        Left,
        Right
    }

    #endregion

    public class UIButtons : MonoBehaviour
    {
        #region Inspector variables

        [SerializeField] private Button leftButton;
        [SerializeField] private Button rightButton;

        #endregion Inspector variables

        #region public functions

        public void AddAction(TypePedal typePedal, Action action)
        {
            switch (typePedal)
            {
                case TypePedal.Left:
                    leftButton.onClick.AddListener(action.Invoke);
                    break;
                case TypePedal.Right:
                    rightButton.onClick.AddListener(action.Invoke);
                    break;
            }
        }

        #endregion public functions
    }
}
