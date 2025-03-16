using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    // UI�̊e��ʁi�z�[���A�N�G�X�g�A�o�g���Ȃǁj���i�[���邽�߂̕ϐ�
    public GameObject headerLabelCanvasObject;              // �w�b�_�[
    public GameObject footerMenuBarCanvasObject;            // �t�b�^�[
    public GameObject mainScreenEventSystemGameObject;      // �C�x���g�p�Q�[���I�u�W�F�N�g
    public GameObject homeScreenCanvasObject;               // �z�[�����
    public GameObject menuScreenCanvasObject;               // �N�G�X�g���

    public string screenName;

    void Start()
    {
        // �Q�[����ԂɊ�Â��ēK�؂ȉ�ʂ�\��
        switch (GameManager.currentState)
        {
            case GameManager.GameState.Home:
                screenName = "Home";
                SetHomeScreen();
                SetHeaderLabel();
                SetFooterMenuBar();
                SetMainScreenEvent();
                break;

            case GameManager.GameState.Menu:
                screenName = "Menu";
                SetMenuScreen();
                SetHeaderLabel();
                SetFooterMenuBar();
                SetMainScreenEvent();
                break;
        }
    }

    public void SetFooterMenuBar()
    {
        if (footerMenuBarCanvasObject == null)
        {
            // headerScreenLabel��GameObject���쐬
            footerMenuBarCanvasObject = new GameObject("FooterMenuBar");

            // homeScreen�p��Canvas���쐬
            Canvas footerMenuBarCanvas = footerMenuBarCanvasObject.AddComponent<Canvas>();
            footerMenuBarCanvas.renderMode = RenderMode.ScreenSpaceCamera;

            // GraphicRaycaster��ǉ�
            footerMenuBarCanvasObject.AddComponent<GraphicRaycaster>();

            // canvas�̎q�v�f�ɐݒ�
            footerMenuBarCanvasObject.transform.SetParent(footerMenuBarCanvas.transform, false);

            // HeaderAreaLabelManager ���A�^�b�`
            FooterMenuBarManager footerMenuBar = headerLabelCanvasObject.AddComponent<FooterMenuBarManager>();
            footerMenuBar.SetFooterMenuBarBackground();
            footerMenuBarCanvas.sortingOrder = 10;
        }
    }

    public void SetHeaderLabel()
    {
        if (headerLabelCanvasObject == null)
        {
            // headerScreenLabel��GameObject���쐬
            headerLabelCanvasObject = new GameObject("HeaderScreenLabel");

            // homeScreen�p��Canvas���쐬
            Canvas headerLabelCanvas = headerLabelCanvasObject.AddComponent<Canvas>();

            // �����_�[���[�h��ScreenSpaceCamera�ɐݒ�
            headerLabelCanvas.renderMode = RenderMode.ScreenSpaceCamera;

            // GraphicRaycaster��ǉ�
            headerLabelCanvasObject.AddComponent<GraphicRaycaster>();

            // canvas�̎q�v�f�ɐݒ�
            headerLabelCanvasObject.transform.SetParent(headerLabelCanvas.transform, false);

            // HeaderAreaLabelManager ���A�^�b�`
            HeaderLabelManager headerLabel = headerLabelCanvasObject.AddComponent<HeaderLabelManager>();
            headerLabel.SetHeaderLabel(screenName, headerLabelCanvas);
            headerLabelCanvas.sortingOrder = 10;
        }
    }

    public void SetMainScreenEvent()
    {
        if (mainScreenEventSystemGameObject == null)
        {
            // EventSystem�𐶐�(�{�^����C�x���g�őJ�ڂȂǂ�����ۂɂ͕K���K�v)
            mainScreenEventSystemGameObject = new GameObject("mainEventSystem");
            mainScreenEventSystemGameObject.AddComponent<EventSystem>();
            mainScreenEventSystemGameObject.AddComponent<StandaloneInputModule>();
        }
    }

    // �z�[����ʂ�\��
    public void SetHomeScreen()
    {
        DeactivateAllScreens();
        if (homeScreenCanvasObject == null)
        {
            // homeScreen��GameObject���쐬
            homeScreenCanvasObject = new GameObject("HomeScreen");            
            Canvas homeScreenCanvas = homeScreenCanvasObject.AddComponent<Canvas>();

            // �����_�[���[�h��ScreenSpaceCamera�ɐݒ�
            homeScreenCanvas.renderMode = RenderMode.ScreenSpaceCamera;

            // GraphicRaycaster��ǉ�
            homeScreenCanvasObject.AddComponent<GraphicRaycaster>();

            // canvas�̎q�v�f�ɐݒ�
            homeScreenCanvasObject.transform.SetParent(homeScreenCanvas.transform, false);

            // HomeScreenManager ���A�^�b�`
            HomeScreenManager homeScreen = homeScreenCanvasObject.AddComponent<HomeScreenManager>();
            homeScreen.HomeScreen(homeScreenCanvas);
            homeScreenCanvas.sortingOrder = 5;
        }

        // �z�[����\��
        homeScreenCanvasObject.SetActive(true);

        // �w�b�_�[�ƃt�b�^�[��\��
        if (headerLabelCanvasObject != null && !headerLabelCanvasObject.activeSelf)
        {
            headerLabelCanvasObject.SetActive(true);
        }
        if (footerMenuBarCanvasObject != null && !footerMenuBarCanvasObject.activeSelf)
        {
            footerMenuBarCanvasObject.SetActive(true);
        }
        
    }

    // ���j���[��ʂ�\��
    public void SetMenuScreen()
    {
        DeactivateAllScreens();

        if (menuScreenCanvasObject == null)
        {
            // homeScreen��GameObject���쐬
            menuScreenCanvasObject = new GameObject("MenuScreen");
            Canvas menuScreenCanvas = menuScreenCanvasObject.AddComponent<Canvas>();

            // �����_�[���[�h��ScreenSpaceCamera�ɐݒ�
            menuScreenCanvas.renderMode = RenderMode.ScreenSpaceCamera;

            // GraphicRaycaster��ǉ�
            menuScreenCanvasObject.AddComponent<GraphicRaycaster>();

            // canvas�̎q�v�f�ɐݒ�
            menuScreenCanvasObject.transform.SetParent(menuScreenCanvas.transform, false);

            // HomeScreenManager ���A�^�b�`
            MenuScreenManager menuScreen = menuScreenCanvasObject.AddComponent<MenuScreenManager>();
            menuScreen.MenuScreen(menuScreenCanvas);
            menuScreenCanvas.sortingOrder = 5;
        }

        // ���j���[��\��
        menuScreenCanvasObject.SetActive(true);

        // �w�b�_�[�ƃt�b�^�[��\��
        if (headerLabelCanvasObject != null && !headerLabelCanvasObject.activeSelf)
        {
            headerLabelCanvasObject.SetActive(true);
        }
        if (footerMenuBarCanvasObject != null && !footerMenuBarCanvasObject.activeSelf)
        {
            footerMenuBarCanvasObject.SetActive(true);
        }
    }

    // ���ׂẲ�ʂ��\���ɂ���
    private void DeactivateAllScreens()
    {
        if (homeScreenCanvasObject != null)
        {
            homeScreenCanvasObject.SetActive(false);
        }
        if (menuScreenCanvasObject != null)
        {
            menuScreenCanvasObject.SetActive(false);
        }
    }
}
