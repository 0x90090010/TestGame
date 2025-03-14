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
 
    //ボタンのサイズ
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
            // image用のゲームオブジェクトを作成
            GameObject footerMenuButton = new GameObject(footerMenuList[i]);

            // imageコンポーネントを追加
            Image footerButtonImage = footerMenuButton.AddComponent<Image>();

            // canvasの子要素に設定
            footerMenuButton.transform.SetParent(canvas.transform, false);

            // ボタンの配置
            RectTransform rectTransform = footerMenuButton.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(imageWidth, imageHeight);
            Debug.Log(0 - imageWidth / 2 * (footerMenuList.Count - 1) + imageWidth * i);
            rectTransform.anchoredPosition = new Vector2(0 - imageWidth / 2 * (footerMenuList.Count - 1) + imageWidth * i, 0 - Screen.height / 2 * (float)0.8);
            footerButtonImage = footerMenuButton.GetComponent<Image>();

            // 仮の背景
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
            // image用のゲームオブジェクトを作成
            GameObject footerButtonHitbox = new GameObject(footerMenuList[i] + "Hitbox");

            // imageコンポーネントを追加
            Image hitBoxImage = footerButtonHitbox.AddComponent<Image>();
            
            // 透明にする
            hitBoxImage.color = new Color(1, 1, 1, 0);
            footerButtonHitbox.transform.SetParent(canvas.transform, false);

            // ボタンの配置
            RectTransform rectTransform = footerButtonHitbox.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(imageWidth, imageHeight);
            Debug.Log(0 - imageWidth / 2 * (footerMenuList.Count - 1) + imageWidth * i);
            rectTransform.anchoredPosition = new Vector2(0 - imageWidth / 2 * (footerMenuList.Count - 1) + imageWidth * i, 0 - Screen.height / 2 * (float)0.8);

            // イベントを追加（ボタンやタップを検出）
            switch (i)
            {
                case 0:
                    Debug.Log("ボタン0の処理");
                    footerButtonHitbox.AddComponent<Button>().onClick.AddListener(() => HomeHitboxClicked());
                    break;

                case 1:
                    Debug.Log("ボタン1の処理");
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
