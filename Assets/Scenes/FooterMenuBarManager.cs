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
    private MenuScreenManager menuScreenManager;
    private GameObject footerMenuBarActiveScreenImageObject;


    //ボタンのサイズ
    int imageWidth = 250;
    int imageHeight = 100;

    List<string> footerMenuList = new List<string>
    {
        "FooterHomeButton",
        "FooterMenuButton",
    };

    void Start()
    {
        // シーン内から検索して設定
        mainSceneManager = FindObjectOfType<MainSceneManager>();
        headerLabelManager = FindObjectOfType<HeaderLabelManager>();
        menuScreenManager = FindObjectOfType<MenuScreenManager>();
    }

    public void SetFooterMenuBarBackground()
    {
        Canvas footerMenuBarBackgroundCanvas = FindObjectOfType<Canvas>();
        
        for (int i = 0; i < footerMenuList.Count; i++)
        {
            // image用のゲームオブジェクトを作成
            GameObject footerMenuBarBackgroundImageObject = new GameObject(footerMenuList[i] + "BackgroundGameObject");

            // imageコンポーネントを追加
            Image footerMenuBarBackgroundImage = footerMenuBarBackgroundImageObject.AddComponent<Image>();

            // canvasの子要素に設定
            footerMenuBarBackgroundImageObject.transform.SetParent(footerMenuBarBackgroundCanvas.transform, false);

            // ボタンの配置
            RectTransform rectTransform = footerMenuBarBackgroundImageObject.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(imageWidth, imageHeight);
            rectTransform.anchorMin = new Vector2(rectTransform.anchorMin.x, 0);
            rectTransform.anchorMax = new Vector2(rectTransform.anchorMax.x, 0);
            rectTransform.pivot = new Vector2(rectTransform.pivot.x, 0);
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, 0);
            Debug.Log(0 - imageWidth / 2 * (footerMenuList.Count - 1) + imageWidth * i);
            rectTransform.anchoredPosition = new Vector2(0 - imageWidth / 2 * (footerMenuList.Count - 1) + imageWidth * i, rectTransform.rect.height / 4);
            footerMenuBarBackgroundImage = footerMenuBarBackgroundImageObject.GetComponent<Image>();

            // 仮の背景
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
        
        // image用のゲームオブジェクトを作成
        footerMenuBarActiveScreenImageObject = new GameObject("FooterActiveScreenGameObject");

        // imageコンポーネントを追加
        Image footerMenuBarActiveScreenImage = footerMenuBarActiveScreenImageObject.AddComponent<Image>();

        // canvasの子要素に設定
        footerMenuBarActiveScreenImageObject.transform.SetParent(footerMenuBarActiveScreenCanvas.transform, false);

        // 配置
        RectTransform rectTransform = footerMenuBarActiveScreenImageObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(imageWidth, imageHeight);
        rectTransform.sizeDelta = new Vector2(imageWidth, imageHeight);
        rectTransform.anchorMin = new Vector2(rectTransform.anchorMin.x, 0);
        rectTransform.anchorMax = new Vector2(rectTransform.anchorMax.x, 0);
        rectTransform.pivot = new Vector2(rectTransform.pivot.x, 0);

        // MainSceneManagerの現在の画面情報を取得
        int activeIndex = -1; // デフォルトでHomeボタンの位置
        switch (GameManager.currentState)
        {
            case GameManager.GameState.Home:
                activeIndex = 0; // Homeボタンの位置にする
                break;

            case GameManager.GameState.Menu:
                activeIndex = 1; // Menuボタンの位置にする
                break;

        }
        rectTransform.anchoredPosition = new Vector2(0 - imageWidth / 2 * (footerMenuList.Count - 1) + imageWidth * activeIndex, rectTransform.rect.height / 4);
        footerMenuBarActiveScreenImage = footerMenuBarActiveScreenImageObject.GetComponent<Image>();

        // 仮の背景
        Texture2D footerMenuBarActiveScreenTexture = Resources.Load<Texture2D>("FooterMenuButtonActiveScreen");
        Sprite sprite = Sprite.Create(footerMenuBarActiveScreenTexture, new Rect(0, 0, footerMenuBarActiveScreenTexture.width, footerMenuBarActiveScreenTexture.height), new Vector2(0.5f, 0.5f));
        footerMenuBarActiveScreenImage.sprite = sprite;
    }

    void UpdateActiveScreenPosition(int activeIndex)
    {
        Debug.Log(activeIndex);
        RectTransform rectTransform = footerMenuBarActiveScreenImageObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(imageWidth, imageHeight);
        rectTransform.anchorMin = new Vector2(rectTransform.anchorMin.x, 0);
        rectTransform.anchorMax = new Vector2(rectTransform.anchorMax.x, 0);
        rectTransform.pivot = new Vector2(rectTransform.pivot.x, 0);
        rectTransform.anchoredPosition = new Vector2(0 - imageWidth / 2 * (footerMenuList.Count - 1) + imageWidth * activeIndex, rectTransform.rect.height / 4);

    }

    void SetFooterMenuBarButton()
    {
        Canvas footerMenuBarButtonCanvas = FindObjectOfType<Canvas>();

        for (int i = 0; i < footerMenuList.Count; i++)
        {
            // image用のゲームオブジェクトを作成
            GameObject footerMenuBarButtonImageObject = new GameObject(footerMenuList[i]);

            // imageコンポーネントを追加
            Image footerMenuBarButtonImage = footerMenuBarButtonImageObject.AddComponent<Image>();

            // canvasの子要素に設定
            footerMenuBarButtonImageObject.transform.SetParent(footerMenuBarButtonCanvas.transform, false);

            // ボタンの配置
            RectTransform rectTransform = footerMenuBarButtonImageObject.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(imageWidth, imageHeight);
            rectTransform.sizeDelta = new Vector2(imageWidth, imageHeight);
            rectTransform.anchorMin = new Vector2(rectTransform.anchorMin.x, 0);
            rectTransform.anchorMax = new Vector2(rectTransform.anchorMax.x, 0);
            rectTransform.pivot = new Vector2(rectTransform.pivot.x, 0);
            Debug.Log(0 - imageWidth / 2 * (footerMenuList.Count - 1) + imageWidth * i);
            rectTransform.anchoredPosition = new Vector2(0 - imageWidth / 2 * (footerMenuList.Count - 1) + imageWidth * i, rectTransform.rect.height / 4);
            footerMenuBarButtonImage = footerMenuBarButtonImageObject.GetComponent<Image>();

            // 仮の背景
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
            // image用のゲームオブジェクトを作成
            GameObject footerButtonHitbox = new GameObject(footerMenuList[i] + "Hitbox");

            // imageコンポーネントを追加
            Image hitBoxImage = footerButtonHitbox.AddComponent<Image>();
            
            // 透明にする
            hitBoxImage.color = new Color(1, 1, 1, 0);
            footerButtonHitbox.transform.SetParent(footerMenuBarButtonHitboxCanvas.transform, false);

            // ボタンの配置
            RectTransform rectTransform = footerButtonHitbox.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(imageWidth, imageHeight);
            rectTransform.sizeDelta = new Vector2(imageWidth, imageHeight);
            rectTransform.anchorMin = new Vector2(rectTransform.anchorMin.x, 0);
            rectTransform.anchorMax = new Vector2(rectTransform.anchorMax.x, 0);
            rectTransform.pivot = new Vector2(rectTransform.pivot.x, 0);
            Debug.Log(0 - imageWidth / 2 * (footerMenuList.Count - 1) + imageWidth * i);
            rectTransform.anchoredPosition = new Vector2(0 - imageWidth / 2 * (footerMenuList.Count - 1) + imageWidth * i, rectTransform.rect.height / 4);

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

        // 事前に呼び出し
        menuScreenManager = FindObjectOfType<MenuScreenManager>();
        // Menuのウィンドウを消す
        menuScreenManager.DeactivateAllMenuWindows();

        // MainSceneManager の SetHomeScreen() を呼ぶ
        mainSceneManager.SetHomeScreen();
        
        // ヘッダーのテキストをHomeに変更する
        headerLabelManager.ChangeHeaderText("Home");

        // Active Screenの位置を更新
        UpdateActiveScreenPosition(0);



    }

    void MenuHitboxClicked()
    {

        Debug.Log("MenuHitboxClicked");
        // MainSceneManager の SetMenuScreen() を呼ぶ
        mainSceneManager.SetMenuScreen();

        // ヘッダーのテキストをMenuに変更する
        headerLabelManager.ChangeHeaderText("Menu");

        // Active Screenの位置を更新
        UpdateActiveScreenPosition(1);
    }

}
