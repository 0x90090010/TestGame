using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HomeSceneManager : MonoBehaviour
{

    void Start()
    {
        SetHomeBackground();
        SetFooterMenuBar();
        SetHomeHeaderLabel();
    }

    void SetHomeBackground()
    {
        // canvas�p�̃Q�[���I�u�W�F�N�g���쐬
        GameObject homeBackgroundCanvasObject = new GameObject("HomeBackground");

        // Canvas�R���|�[�l���g��ǉ�
        Canvas homeBackgroundCanvas = homeBackgroundCanvasObject.AddComponent<Canvas>();

        // �����_�[���[�h��ScreenSpaceCamera�ɐݒ�
        homeBackgroundCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        homeBackgroundCanvasObject.AddComponent<GraphicRaycaster>();

        // EventSystem�𐶐�(�{�^����C�x���g�őJ�ڂȂǂ�����ۂɂ͕K���K�v)
        GameObject eventSystemObject = new GameObject("homeEventSystem");
        eventSystemObject.AddComponent<EventSystem>();
        eventSystemObject.AddComponent<StandaloneInputModule>();

        // image�p�̃Q�[���I�u�W�F�N�g���쐬
        GameObject homeBackgroundImageObject = new GameObject("homeBackgroundImage");

        // image�R���|�[�l���g��ǉ�
        Image homeBackgroundImage = homeBackgroundImageObject.AddComponent<Image>();

        // canvas�̎q�v�f�ɐݒ�
        homeBackgroundImageObject.transform.SetParent(homeBackgroundCanvas.transform, false);

        // RectTransform�̐ݒ�(�E�B���h�E�S�̂ɕ\������)
        RectTransform rectTransform = homeBackgroundImageObject.GetComponent<RectTransform>();
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;

        // ���̔w�i
        Texture2D homeBackgroundTexture = Resources.Load<Texture2D>("DefaultHomeBackground");
        Sprite sprite = Sprite.Create(homeBackgroundTexture, new Rect(0, 0, homeBackgroundTexture.width, homeBackgroundTexture.height), new Vector2(0.5f, 0.5f));
        homeBackgroundImage.sprite = sprite;
    }

    // FooterMenuBar�̌Ăяo��
    void SetFooterMenuBar()
    {

        Canvas footerMenuBarCanvas = FindObjectOfType<Canvas>();
        GameObject footerMenuBarObject = new GameObject("FooterMenuBar");
        footerMenuBarObject.transform.SetParent(footerMenuBarCanvas.transform, false);
        FooterMenuBarManager footerMenuBar = footerMenuBarObject.AddComponent<FooterMenuBarManager>();
        footerMenuBar.SetFooterMenuButton();
    }

    // HeaderAreaLabel�̌Ăяo��
    void SetHomeHeaderLabel()
    {
        // canvas�p�̃Q�[���I�u�W�F�N�g���쐬
        GameObject headerAreaLabelCanvasObject = new GameObject("HomeHeaderAreaLabel");

        // ������Canvas�R���|�[�l���g���擾
        Canvas headerAreaLabelCanvas = FindObjectOfType<Canvas>();

        // canvas�̎q�v�f�ɐݒ�
        headerAreaLabelCanvasObject.transform.SetParent(headerAreaLabelCanvas.transform, false);

        // HeaderAreaLabelManager ���A�^�b�`
        HeaderAreaLabelManager headerAreaLabel = headerAreaLabelCanvasObject.AddComponent<HeaderAreaLabelManager>();
        headerAreaLabel.SetHeaderAreaLabel("Home", headerAreaLabelCanvas);
    }
}
