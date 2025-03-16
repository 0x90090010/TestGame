using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuScreenManager : MonoBehaviour
{
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
    }
}
