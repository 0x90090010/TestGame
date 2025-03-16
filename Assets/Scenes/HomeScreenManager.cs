using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeScreenManager : MonoBehaviour
{
    public void HomeScreen(Canvas canvas)
    {
        // image�p�̃Q�[���I�u�W�F�N�g���쐬
        GameObject homeBackgroundImageObject = new GameObject("homeBackgroundImage");

        // �Ăяo������canvas�̎q�v�f�ɐݒ�
        homeBackgroundImageObject.transform.SetParent(canvas.transform, false);

        // image�R���|�[�l���g��ǉ�
        Image homeBackgroundImage = homeBackgroundImageObject.AddComponent<Image>();

        // ���̔w�i
        Texture2D homeBackgroudTexture = Resources.Load<Texture2D>("DefaultHomeBackground");
        Sprite sprite = Sprite.Create(homeBackgroudTexture, new Rect(0, 0, homeBackgroudTexture.width, homeBackgroudTexture.height), new Vector2(0.5f, 0.5f));
        homeBackgroundImage.sprite = sprite;

        // RectTransform�̐ݒ�(�E�B���h�E�S�̂ɕ\������)
        RectTransform rectTransform = homeBackgroundImageObject.GetComponent<RectTransform>();
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;
    }
}
