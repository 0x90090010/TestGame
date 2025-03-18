using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuScreenManager : MonoBehaviour
{
    public GameObject windowCanvasGameObject;

    public void MenuScreen(Canvas canvas)
    {
        // image�p�̃Q�[���I�u�W�F�N�g���쐬
        GameObject menuBackgroundImageObject = new GameObject("MenuBackgroundImage");

        // �Ăяo������canvas�̎q�v�f�ɐݒ�
        menuBackgroundImageObject.transform.SetParent(canvas.transform, false);

        // image�R���|�[�l���g��ǉ�
        Image menuBackgroundImage = menuBackgroundImageObject.AddComponent<Image>();

        // ���̔w�i
        Texture2D menuBackgroundTexture = Resources.Load<Texture2D>("DefaultMenuBackground");
        Sprite sprite = Sprite.Create(menuBackgroundTexture, new Rect(0, 0, menuBackgroundTexture.width, menuBackgroundTexture.height), new Vector2(0.5f, 0.5f));
        menuBackgroundImage.sprite = sprite;

        // RectTransform�̐ݒ�(�E�B���h�E�S�̂ɕ\������)
        RectTransform rectTransform = menuBackgroundImageObject.GetComponent<RectTransform>();
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;

        SetMenuScreenButton();
        SetMenuScreenButtonHitBox();
    }

    //�{�^���̃T�C�Y
    int imageWidth = 250;
    int imageHeight = 100;
    int imageWindowWidth = 864;
    int imageWindowHeight = 486;
    string setText = "Window";
    // �w�b�_�[�e�L�X�g�̎Q�Ƃ�ۑ�
    private Text windowText;

    List<string> menuScreenButtonList = new List<string>
    {
        "WindowButton"
    };

    void SetMenuScreenButton()
    {
        Canvas menuScreenButtonCanvas = FindObjectOfType<Canvas>();
        for (int i = 0; i < menuScreenButtonList.Count; i++)
        {
            // image�p�̃Q�[���I�u�W�F�N�g���쐬
            GameObject menuScreenButtonImageObject = new GameObject(menuScreenButtonList[i]);

            // image�R���|�[�l���g��ǉ�
            Image menuScreenButtonImage = menuScreenButtonImageObject.AddComponent<Image>();

            // canvas�̎q�v�f�ɐݒ�
            menuScreenButtonImageObject.transform.SetParent(menuScreenButtonCanvas.transform, false);

            // ���̔w�i
            Texture2D menuScreenButtonTexture = Resources.Load<Texture2D>("WindowButton");
            Sprite sprite = Sprite.Create(menuScreenButtonTexture, new Rect(0, 0, menuScreenButtonTexture.width, menuScreenButtonTexture.height), new Vector2(0.5f, 0.5f));
            menuScreenButtonImage.sprite = sprite;

            // �{�^���̔z�u
            RectTransform rectTransform = menuScreenButtonImageObject.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(imageWidth, imageHeight);
            rectTransform.sizeDelta = new Vector2(imageWidth, imageHeight);
            rectTransform.anchorMin = new Vector2(rectTransform.anchorMin.x, 1);
            rectTransform.anchorMax = new Vector2(rectTransform.anchorMax.x, 1);
            rectTransform.pivot = new Vector2(rectTransform.pivot.x, 1);
            rectTransform.anchoredPosition = new Vector2(0 - imageWidth / 2 * (menuScreenButtonList.Count - 1) + imageWidth * i, 0 - rectTransform.rect.height);
        }


    }

    void SetMenuScreenButtonHitBox()
    {
        Canvas footerMenuBarButtonHitboxCanvas = FindObjectOfType<Canvas>();

        for (int i = 0; i < menuScreenButtonList.Count; i++)
        {
            // image�p�̃Q�[���I�u�W�F�N�g���쐬
            GameObject menuScreenButtonHitboxImageObject = new GameObject(menuScreenButtonList[i] + "Hitbox");

            // image�R���|�[�l���g��ǉ�
            Image hitBoxImage = menuScreenButtonHitboxImageObject.AddComponent<Image>();

            // �����ɂ���
            hitBoxImage.color = new Color(1, 1, 1, 0);
            menuScreenButtonHitboxImageObject.transform.SetParent(footerMenuBarButtonHitboxCanvas.transform, false);

            // �{�^���̔z�u
            RectTransform rectTransform = menuScreenButtonHitboxImageObject.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(imageWidth, imageHeight);
            rectTransform.sizeDelta = new Vector2(imageWidth, imageHeight);
            rectTransform.anchorMin = new Vector2(rectTransform.anchorMin.x, 1);
            rectTransform.anchorMax = new Vector2(rectTransform.anchorMax.x, 1);
            rectTransform.pivot = new Vector2(rectTransform.pivot.x, 1);
            Debug.Log(0 - imageWidth / 2 * (menuScreenButtonList.Count - 1) + imageWidth * i);
            rectTransform.anchoredPosition = new Vector2(0 - imageWidth / 2 * (menuScreenButtonList.Count - 1) + imageWidth * i, 0 - rectTransform.rect.height);

            // �C�x���g��ǉ��i�{�^����^�b�v�����o�j
            switch (i)
            {
                case 0:
                    Debug.Log("�{�^��0�̏���");
                    menuScreenButtonHitboxImageObject.AddComponent<Button>().onClick.AddListener(() => WindowHitboxClicked());
                    break;

            }
        }

    }

    void WindowHitboxClicked()
    {
        Debug.Log("HomeHitboxClicked");
        Window();
    }

    void Window()
    {
        if (windowCanvasGameObject == null)
        {
            windowCanvasGameObject = new GameObject("WindowCanvasGameObject");
            Canvas windowCanvas = windowCanvasGameObject.AddComponent<Canvas>();
            windowCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        
            // GraphicRaycaster��ǉ�
            windowCanvasGameObject.AddComponent<GraphicRaycaster>();

            CanvasScaler canvasScaler = windowCanvas.gameObject.AddComponent<CanvasScaler>();
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.referenceResolution = new Vector2(1920, 1080);
            canvasScaler.matchWidthOrHeight = 0.5f;


            // image�p�̃Q�[���I�u�W�F�N�g���쐬
            GameObject windowBackgroundImageObject = new GameObject("WindowBackgroundImage");

            // image�R���|�[�l���g��ǉ�
            Image windowBackgroundImage = windowBackgroundImageObject.AddComponent<Image>();
        
            // canvas�̎q�v�f�ɐݒ�
            windowBackgroundImageObject.transform.SetParent(windowCanvasGameObject.transform, false);

            // ���̔w�i
            Texture2D windowBackgroundTexture = Resources.Load<Texture2D>("WindowBackground");
            Sprite sprite = Sprite.Create(windowBackgroundTexture, new Rect(0, 0, windowBackgroundTexture.width, windowBackgroundTexture.height), new Vector2(0.5f, 0.5f));
            windowBackgroundImage.sprite = sprite;

            // Image��RectTransform�ݒ�
            RectTransform imageRect = windowBackgroundImageObject.GetComponent<RectTransform>();
            //imageRect.SetParent(windowCanvas.transform, false);
            imageRect.sizeDelta = new Vector2(imageWindowWidth, imageWindowHeight);
            imageRect.anchorMin = new Vector2(0.5f, 0.5f); // ���S�
            imageRect.anchorMax = new Vector2(0.5f, 0.5f);
            imageRect.pivot = new Vector2(0.5f, 0.5f);
            imageRect.anchoredPosition = new Vector2(0, 0); 

            // Text�̒ǉ�
            GameObject windowTextObject = new GameObject("WindowText");
            windowTextObject.transform.SetParent(windowCanvas.transform, false);

            // Text�R���|�[�l���g�̒ǉ� (TextMeshPro�𐄏�)
            windowText = windowTextObject.AddComponent<Text>();

            // �t�H���g��ݒ�i�f�t�H���g�� Arial �t�H���g���g�p�j
            windowText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");

            // �e�L�X�g�̐ݒ�
            Debug.Log(setText);
            windowText.text = setText;
            windowText.fontSize = 36;
            windowText.alignment = TextAnchor.UpperCenter;
            windowText.color = Color.black;

            // �e�L�X�g��RectTransform�ݒ�
            RectTransform textRect = windowTextObject.GetComponent<RectTransform>();
            textRect.sizeDelta = imageRect.sizeDelta;
            textRect.anchoredPosition = Vector2.zero;

            windowCanvas.sortingOrder = 15;
            Debug.Log("��������");

            if (windowCanvasGameObject == null)
            {
                Debug.LogError("windowCanvasGameObject is Null");
            }
            WindowCloseButton();
        }
        // �E�B���h�E��\��
        windowCanvasGameObject.SetActive(true);
    }

    void WindowCloseButton()
    {
        // �{�^���p��GameObject���쐬
        GameObject windowCloseButtonGameObject = new GameObject("CloseButton");
        windowCloseButtonGameObject.transform.SetParent(windowCanvasGameObject.transform, false);

        // Button�R���|�[�l���g��Image�R���|�[�l���g��ǉ�
        Button closeButton = windowCloseButtonGameObject.AddComponent<Button>();

        // image�R���|�[�l���g��ǉ�
        Image windowCloseButtonImage = windowCloseButtonGameObject.AddComponent<Image>();

        // RectTransform�ݒ�
        RectTransform buttonRect = windowCloseButtonGameObject.GetComponent<RectTransform>();
        buttonRect.sizeDelta = new Vector2(250, 100); 
        buttonRect.anchorMin = new Vector2(0.5f, 0.35f); 
        buttonRect.anchorMax = new Vector2(0.5f, 0.35f);
        buttonRect.pivot = new Vector2(0.5f, 0.5f);
        buttonRect.anchoredPosition = new Vector2(0, 5); 

        // �{�^���̃e�L�X�g��ǉ�
        GameObject buttonTextObject = new GameObject("CloseButtonText");
        buttonTextObject.transform.SetParent(windowCloseButtonGameObject.transform, false);

        Text buttonText = buttonTextObject.AddComponent<Text>();
        buttonText.text = "�Ƃ���";
        buttonText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
        buttonText.fontSize = 30;
        buttonText.alignment = TextAnchor.MiddleCenter;
        buttonText.color = Color.black;

        // �e�L�X�g��RectTransform�ݒ�
        RectTransform textRect = buttonTextObject.GetComponent<RectTransform>();
        textRect.sizeDelta = buttonRect.sizeDelta;
        textRect.anchoredPosition = Vector2.zero;

        // ���̔w�i
        Texture2D windowCloseButtonTexture = Resources.Load<Texture2D>("ButtonTexture");
        Sprite sprite = Sprite.Create(windowCloseButtonTexture, new Rect(0, 0, windowCloseButtonTexture.width, windowCloseButtonTexture.height), new Vector2(0.5f, 0.5f));
        windowCloseButtonImage.sprite = sprite;

        // �{�^���̃N���b�N�C�x���g��ݒ�
        closeButton.onClick.AddListener(CloseWindow);
    }

    void CloseWindow()
    {
         windowCanvasGameObject.SetActive(false);
    }

    // ���ׂẲ�ʂ��\���ɂ���
    public void DeactivateAllMenuWindows()
    {
        if (windowCanvasGameObject != null)
        {
            windowCanvasGameObject.SetActive(false);
        }
    }

}
