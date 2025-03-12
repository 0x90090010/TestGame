using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleSceneManager : MonoBehaviour
{
    void Start()
    {
        SetTitleBackground();
    }

    void SetTitleBackground()
    {
        //canvas�p�̃Q�[���I�u�W�F�N�g���쐬
        GameObject titleBackgroundCanvasObject = new GameObject("TitleBackground");
        //Canvas�R���|�[�l���g��ǉ�
        Canvas titleBackgroundCanvas = titleBackgroundCanvasObject.AddComponent<Canvas>();
        //�����_�[���[�h��ScreenSpaceCamera�ɐݒ�
        titleBackgroundCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        titleBackgroundCanvasObject.AddComponent<GraphicRaycaster>();

        //image�p�̃Q�[���I�u�W�F�N�g���쐬
        GameObject titleBackgroundImageObject = new GameObject("TitleBackgroundImage");
        //image�R���|�[�l���g��ǉ�
        Image titleBackgroundImage = titleBackgroundImageObject.AddComponent<Image>();
        //canvas�̎q�v�f�ɐݒ�
        titleBackgroundImageObject.transform.SetParent(titleBackgroundCanvas.transform, false);
        // RectTransform�̐ݒ�(�E�B���h�E�S�̂ɕ\������)
        RectTransform rectTransform = titleBackgroundImageObject.GetComponent<RectTransform>();
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;

        //���̔w�i
        Texture2D titleBackgroundTexture = Resources.Load<Texture2D>("defaultTitleBackground");
        Sprite sprite = Sprite.Create(titleBackgroundTexture, new Rect(0, 0, titleBackgroundTexture.width, titleBackgroundTexture.height), new Vector2(0.5f, 0.5f));
        titleBackgroundImage.sprite = sprite;
    }

}
