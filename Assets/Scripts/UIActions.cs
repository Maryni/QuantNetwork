using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.Actions
{

    #region enum

    public enum TypeUI
    {
        None,
        MainMenu,
        Links
    }

    #endregion
    public class UIActions : MonoBehaviour
    {
        #region Inspector variables

        [SerializeField] private GameObject mainMenuGameObject;
        [SerializeField] private GameObject linksGameObject;
        
        [SerializeField] private Button playButton;
        [SerializeField] private Button aboutMeButton;
        [SerializeField] private Button aboutMeInButton;
        [SerializeField] private Button exitButton;

        #endregion Inspector variables

        #region public functions

        public void Load(int index)
        {
            SceneManager.LoadSceneAsync(index);
        }

        public void Exit()
        {
            Application.Quit();
        }

        public void SetVisible(TypeUI typeUI, bool visible = true)
        {
            switch (typeUI)
            {
                case TypeUI.Links: 
                    linksGameObject.SetActive(visible);
                    break;
                case TypeUI.MainMenu: 
                    mainMenuGameObject.SetActive(visible);
                    break;
                default:
                    break;
            }
        }

        public void OpenURL(string url)
        {
            Application.OpenURL(url);
        }

        #endregion public functions

        #region Unity functions

        private void Awake()
        {
            playButton.onClick.AddListener(()=> Load(1));
            playButton.onClick.AddListener(()=> SetVisible(TypeUI.MainMenu, false));
            aboutMeButton.onClick.AddListener(()=> SetVisible(TypeUI.Links, true));
            exitButton.onClick.AddListener(()=> SetVisible(TypeUI.MainMenu, false));
            exitButton.onClick.AddListener(Exit);
            aboutMeInButton.onClick.AddListener(()=> OpenURL("t.me/prikolchik574"));
            aboutMeInButton.onClick.AddListener(()=> SetVisible(TypeUI.Links, false));
        }

        #endregion Unity functions
        
    }
}
