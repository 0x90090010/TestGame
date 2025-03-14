using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuSceneManager : MonoBehaviour
{
    void Start()
    {
        SetMenuBackground();
        SetFooterMenuBar();
    }

    void SetMenuBackground()
    {
        // canvas�p�̃Q�[���I�u�W�F�N�g���쐬
        GameObject menuBackgroundCanvasObject = new GameObject("MenuBackground");

        // Canvas�R���|�[�l���g��ǉ�
        Canvas menuBackgroundCanvas = menuBackgroundCanvasObject.AddComponent<Canvas>();

        // �����_�[���[�h��ScreenSpaceCamera�ɐݒ�
        menuBackgroundCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        menuBackgroundCanvasObject.AddComponent<GraphicRaycaster>();

        // EventSystem�𐶐�(�{�^����C�x���g�őJ�ڂȂǂ�����ۂɂ͕K���K�v)
        GameObject eventSystemObject = new GameObject("MenuEventSystem");
        eventSystemObject.AddComponent<EventSystem>();
        eventSystemObject.AddComponent<StandaloneInputModule>();

        // image�p�̃Q�[���I�u�W�F�N�g���쐬
        GameObject menuBackgroundImageObject = new GameObject("MenuBackgroundImage");

        // image�R���|�[�l���g��ǉ�
        Image menuBackgroundImage = menuBackgroundImageObject.AddComponent<Image>();

        // canvas�̎q�v�f�ɐݒ�
        menuBackgroundImageObject.transform.SetParent(menuBackgroundCanvas.transform, false);

        // RectTransform�̐ݒ�(�E�B���h�E�S�̂ɕ\������)
        RectTransform rectTransform = menuBackgroundImageObject.GetComponent<RectTransform>();
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;

        // ���̔w�i
        Texture2D menuBackgroundTexture = Resources.Load<Texture2D>("DefaultMenuBackground");
        Sprite sprite = Sprite.Create(menuBackgroundTexture, new Rect(0, 0, menuBackgroundTexture.width, menuBackgroundTexture.height), new Vector2(0.5f, 0.5f));
        menuBackgroundImage.sprite = sprite;
    }

    void SetFooterMenuBar()
    {
        // FooterMenuBar�̌Ăяo��
        Canvas canvas = FindObjectOfType<Canvas>();
        GameObject footerMenuBarObject = new GameObject("FooterMenuBar");
        footerMenuBarObject.transform.SetParent(canvas.transform, false);
        FooterMenuBarManager footerMenuBar = footerMenuBarObject.AddComponent<FooterMenuBarManager>();
        footerMenuBar.SetFooterMenuButton();
    }
}
