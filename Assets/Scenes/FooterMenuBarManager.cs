using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.Video;
using UnityEngine.EventSystems;

public class FooterMenuBarManager : MonoBehaviour
{

    private MainSceneManager mainSceneManager;
    private HeaderLabelManager headerLabelManager;
    private GameObject footerMenuBarActiveScreenImageObject;

    //�{�^���̃T�C�Y
    int imageWidth = 250;
    int imageHeight = 100;

    List<string> footerMenuList = new List<string>
    {
        "FooterHomeButton",
        "FooterMenuButton",
    };

    void Start()
    {
        // �V�[�������猟�����Đݒ�
        mainSceneManager = FindObjectOfType<MainSceneManager>();
        headerLabelManager = FindObjectOfType<HeaderLabelManager>();
    }

    public void SetFooterMenuBarBackground()
    {
        Canvas footerMenuBarBackgroundCanvas = FindObjectOfType<Canvas>();
        
        for (int i = 0; i < footerMenuList.Count; i++)
        {
            // image�p�̃Q�[���I�u�W�F�N�g���쐬
            GameObject footerMenuBarBackgroundImageObject = new GameObject(footerMenuList[i] + "BackgroundGameObject");

            // image�R���|�[�l���g��ǉ�
            Image footerMenuBarBackgroundImage = footerMenuBarBackgroundImageObject.AddComponent<Image>();

            // canvas�̎q�v�f�ɐݒ�
            footerMenuBarBackgroundImageObject.transform.SetParent(footerMenuBarBackgroundCanvas.transform, false);

            // �{�^���̔z�u
            RectTransform rectTransform = footerMenuBarBackgroundImageObject.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(imageWidth, imageHeight);
            Debug.Log(0 - imageWidth / 2 * (footerMenuList.Count - 1) + imageWidth * i);
            rectTransform.anchoredPosition = new Vector2(0 - imageWidth / 2 * (footerMenuList.Count - 1) + imageWidth * i, 0 - Screen.height / 2 * (float)0.8);
            footerMenuBarBackgroundImage = footerMenuBarBackgroundImageObject.GetComponent<Image>();

            // ���̔w�i
            Texture2D footerMenuButtonTexture = Resources.Load<Texture2D>(footerMenuList[i] + "Background");
            Sprite sprite = Sprite.Create(footerMenuButtonTexture, new Rect(0, 0, footerMenuButtonTexture.width, footerMenuButtonTexture.height), new Vector2(0.5f, 0.5f));
            footerMenuBarBackgroundImage.sprite = sprite;
        }

        SetFooterMenuBarActiveScreen();
        SetFooterMenuBarButton();
        SetFooterButtonHitBox();
    }

    void SetFooterMenuBarActiveScreen()
    {
        Canvas footerMenuBarActiveScreenCanvas = FindObjectOfType<Canvas>();
        
        // image�p�̃Q�[���I�u�W�F�N�g���쐬
        footerMenuBarActiveScreenImageObject = new GameObject("FooterActiveScreenGameObject");

        // image�R���|�[�l���g��ǉ�
        Image footerMenuBarActiveScreenImage = footerMenuBarActiveScreenImageObject.AddComponent<Image>();

        // canvas�̎q�v�f�ɐݒ�
        footerMenuBarActiveScreenImageObject.transform.SetParent(footerMenuBarActiveScreenCanvas.transform, false);

        // �z�u
        RectTransform rectTransform = footerMenuBarActiveScreenImageObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(imageWidth, imageHeight);

        // MainSceneManager�̌��݂̉�ʏ����擾
        int activeIndex = -1; // �f�t�H���g��Home�{�^���̈ʒu
        switch (GameManager.currentState)
        {
            case GameManager.GameState.Home:
                activeIndex = 0; // Home�{�^���̈ʒu�ɂ���
                break;

            case GameManager.GameState.Menu:
                activeIndex = 1; // Menu�{�^���̈ʒu�ɂ���
                break;

        }
        rectTransform.anchoredPosition = new Vector2(0 - imageWidth / 2 * (footerMenuList.Count - 1) + imageWidth * activeIndex, 0 - Screen.height / 2 * (float)0.8);
        footerMenuBarActiveScreenImage = footerMenuBarActiveScreenImageObject.GetComponent<Image>();

        // ���̔w�i
        Texture2D footerMenuBarActiveScreenTexture = Resources.Load<Texture2D>("FooterMenuButtonActiveScreen");
        Sprite sprite = Sprite.Create(footerMenuBarActiveScreenTexture, new Rect(0, 0, footerMenuBarActiveScreenTexture.width, footerMenuBarActiveScreenTexture.height), new Vector2(0.5f, 0.5f));
        footerMenuBarActiveScreenImage.sprite = sprite;
    }

    void UpdateActiveScreenPosition(int activeIndex)
    {
        Debug.Log(activeIndex);
        RectTransform rectTransform = footerMenuBarActiveScreenImageObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0 - imageWidth / 2 * (footerMenuList.Count - 1) + imageWidth * activeIndex, 0 - Screen.height / 2 * (float)0.8);
    }

    void SetFooterMenuBarButton()
    {
        Canvas footerMenuBarButtonCanvas = FindObjectOfType<Canvas>();

        for (int i = 0; i < footerMenuList.Count; i++)
        {
            // image�p�̃Q�[���I�u�W�F�N�g���쐬
            GameObject footerMenuBarButtonImageObject = new GameObject(footerMenuList[i]);

            // image�R���|�[�l���g��ǉ�
            Image footerMenuBarButtonImage = footerMenuBarButtonImageObject.AddComponent<Image>();

            // canvas�̎q�v�f�ɐݒ�
            footerMenuBarButtonImageObject.transform.SetParent(footerMenuBarButtonCanvas.transform, false);

            // �{�^���̔z�u
            RectTransform rectTransform = footerMenuBarButtonImageObject.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(imageWidth, imageHeight);
            Debug.Log(0 - imageWidth / 2 * (footerMenuList.Count - 1) + imageWidth * i);
            rectTransform.anchoredPosition = new Vector2(0 - imageWidth / 2 * (footerMenuList.Count - 1) + imageWidth * i, 0 - Screen.height / 2 * (float)0.8);
            footerMenuBarButtonImage = footerMenuBarButtonImageObject.GetComponent<Image>();

            // ���̔w�i
            Texture2D footerMenuButtonTexture = Resources.Load<Texture2D>(footerMenuList[i]);
            Sprite sprite = Sprite.Create(footerMenuButtonTexture, new Rect(0, 0, footerMenuButtonTexture.width, footerMenuButtonTexture.height), new Vector2(0.5f, 0.5f));
            footerMenuBarButtonImage.sprite = sprite;

        }
        
    }

    void SetFooterButtonHitBox()
    {
        Canvas footerMenuBarButtonHitboxCanvas = FindObjectOfType<Canvas>();

        for (int i = 0; i < footerMenuList.Count; i++)
        {
            // image�p�̃Q�[���I�u�W�F�N�g���쐬
            GameObject footerButtonHitbox = new GameObject(footerMenuList[i] + "Hitbox");

            // image�R���|�[�l���g��ǉ�
            Image hitBoxImage = footerButtonHitbox.AddComponent<Image>();
            
            // �����ɂ���
            hitBoxImage.color = new Color(1, 1, 1, 0);
            footerButtonHitbox.transform.SetParent(footerMenuBarButtonHitboxCanvas.transform, false);

            // �{�^���̔z�u
            RectTransform rectTransform = footerButtonHitbox.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(imageWidth, imageHeight);
            Debug.Log(0 - imageWidth / 2 * (footerMenuList.Count - 1) + imageWidth * i);
            rectTransform.anchoredPosition = new Vector2(0 - imageWidth / 2 * (footerMenuList.Count - 1) + imageWidth * i, 0 - Screen.height / 2 * (float)0.8);

            // �C�x���g��ǉ��i�{�^����^�b�v�����o�j
            switch (i)
            {
                case 0:
                    Debug.Log("�{�^��0�̏���");
                    footerButtonHitbox.AddComponent<Button>().onClick.AddListener(() => HomeHitboxClicked());
                    break;

                case 1:
                    Debug.Log("�{�^��1�̏���");
                    footerButtonHitbox.AddComponent<Button>().onClick.AddListener(() => MenuHitboxClicked());
                    break;

            }
        }

    }

    void HomeHitboxClicked()
    {
        Debug.Log("HomeHitboxClicked");
        // MainSceneManager �� SetHomeScreen() ���Ă�
        mainSceneManager.SetHomeScreen();

        // �w�b�_�[�̃e�L�X�g��Home�ɕύX����
        headerLabelManager.ChangeHeaderText("Home");

        // Active Screen�̈ʒu���X�V
        UpdateActiveScreenPosition(0);

    }

    void MenuHitboxClicked()
    {
        Debug.Log("MenuHitboxClicked");
        // MainSceneManager �� SetMenuScreen() ���Ă�
        mainSceneManager.SetMenuScreen();

        // �w�b�_�[�̃e�L�X�g��Menu�ɕύX����
        headerLabelManager.ChangeHeaderText("Menu");

        // Active Screen�̈ʒu���X�V
        UpdateActiveScreenPosition(1);
    }

}
