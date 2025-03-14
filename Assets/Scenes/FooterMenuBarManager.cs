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
 
    //�{�^���̃T�C�Y
    int imageWidth = 250;
    int imageHeight = 100;

    List<string> footerMenuList = new List<string>
    {
        "FooterHomeButton",
        "FooterMenuButton",
    };

    public void SetFooterMenuButton()
    {
        Canvas canvas = FindObjectOfType<Canvas>();

        for (int i = 0; i < footerMenuList.Count; i++)
        {
            // image�p�̃Q�[���I�u�W�F�N�g���쐬
            GameObject footerMenuButton = new GameObject(footerMenuList[i]);

            // image�R���|�[�l���g��ǉ�
            Image footerButtonImage = footerMenuButton.AddComponent<Image>();

            // canvas�̎q�v�f�ɐݒ�
            footerMenuButton.transform.SetParent(canvas.transform, false);

            // �{�^���̔z�u
            RectTransform rectTransform = footerMenuButton.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(imageWidth, imageHeight);
            Debug.Log(0 - imageWidth / 2 * (footerMenuList.Count - 1) + imageWidth * i);
            rectTransform.anchoredPosition = new Vector2(0 - imageWidth / 2 * (footerMenuList.Count - 1) + imageWidth * i, 0 - Screen.height / 2 * (float)0.8);
            footerButtonImage = footerMenuButton.GetComponent<Image>();

            // ���̔w�i
            Texture2D footerMenuButtonTexture = Resources.Load<Texture2D>(footerMenuList[i]);
            Sprite sprite = Sprite.Create(footerMenuButtonTexture, new Rect(0, 0, footerMenuButtonTexture.width, footerMenuButtonTexture.height), new Vector2(0.5f, 0.5f));
            footerButtonImage.sprite = sprite;

        }
        SetFooterButtonHitBox();
    }

    void SetFooterButtonHitBox()
    {
        Canvas canvas = FindObjectOfType<Canvas>();

        for (int i = 0; i < footerMenuList.Count; i++)
        {
            // image�p�̃Q�[���I�u�W�F�N�g���쐬
            GameObject footerButtonHitbox = new GameObject(footerMenuList[i] + "Hitbox");

            // image�R���|�[�l���g��ǉ�
            Image hitBoxImage = footerButtonHitbox.AddComponent<Image>();
            
            // �����ɂ���
            hitBoxImage.color = new Color(1, 1, 1, 0);
            footerButtonHitbox.transform.SetParent(canvas.transform, false);

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
        SceneManager.LoadScene("HomeScene");
    }

    void MenuHitboxClicked()
    {
        Debug.Log("MenuHitboxClicked");
        SceneManager.LoadScene("MenuScene");
    }

}
