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

        [SerializeField] private CanvasGroup mainMenuGameObject;
        [SerializeField] private CanvasGroup linksGameObject;

        [SerializeField] private float durationLoadFade;
        [SerializeField] private float durationExitFade;
        [SerializeField] private float durationShowFade;

        [SerializeField] private Button playButton;
        [SerializeField] private Button aboutMeButton;
        [SerializeField] private Button aboutMeInButton;
        [SerializeField] private Button exitButton;

        private Tween fadeTween;

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
                    ApplyFade(1, durationShowFade, linksGameObject, () =>
                    {
                        linksGameObject.interactable = true;
                        linksGameObject.blocksRaycasts = true;
                    });
                    //linksGameObject.gameObject.SetActive(visible);
                    break;
                case TypeUI.MainMenu: 
                    ApplyFade(1, durationShowFade, mainMenuGameObject, () =>
                    {
                        mainMenuGameObject.interactable = true;
                        mainMenuGameObject.blocksRaycasts = true;
                    });
                    //mainMenuGameObject.gameObject.SetActive(visible);
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
            DOTween.Init();
            playButton.onClick.AddListener(()=> SetVisible(TypeUI.MainMenu, false));
            playButton.onClick.AddListener(()=> Load(1));
            aboutMeButton.onClick.AddListener(()=> SetVisible(TypeUI.Links, true));
            aboutMeButton.onClick.AddListener(()=> SetVisible(TypeUI.MainMenu, false));
            exitButton.onClick.AddListener(()=> SetVisible(TypeUI.MainMenu, false));
            exitButton.onClick.AddListener(Exit);
            aboutMeInButton.onClick.AddListener(()=> OpenURL("t.me/prikolchik574"));
            aboutMeInButton.onClick.AddListener(()=> SetVisible(TypeUI.Links, false));
            aboutMeInButton.onClick.AddListener(()=> SetVisible(TypeUI.MainMenu, true));
        }

        #endregion Unity functions
        
        #region private functions

        private void ApplyFade(float endValue, float duration, CanvasGroup canvasGroup, TweenCallback onEnd)
        {
            if (fadeTween != null)
            {
                fadeTween.Kill(false);
            }

            fadeTween = canvasGroup.DOFade(endValue, duration);
            fadeTween.onComplete += onEnd;
        }

        #endregion private functions
    }
}
