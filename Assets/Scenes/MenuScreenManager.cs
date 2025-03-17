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
        // image用のゲームオブジェクトを作成
        GameObject menuBackgroundImageObject = new GameObject("MenuBackgroundImage");

        // 呼び出し側のcanvasの子要素に設定
        menuBackgroundImageObject.transform.SetParent(canvas.transform, false);

        // imageコンポーネントを追加
        Image menuBackgroundImage = menuBackgroundImageObject.AddComponent<Image>();

        // 仮の背景
        Texture2D menuBackgroundTexture = Resources.Load<Texture2D>("DefaultMenuBackground");
        Sprite sprite = Sprite.Create(menuBackgroundTexture, new Rect(0, 0, menuBackgroundTexture.width, menuBackgroundTexture.height), new Vector2(0.5f, 0.5f));
        menuBackgroundImage.sprite = sprite;

        // RectTransformの設定(ウィンドウ全体に表示する)
        RectTransform rectTransform = menuBackgroundImageObject.GetComponent<RectTransform>();
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;

        SetMenuScreenButton();
        SetMenuScreenButtonHitBox();
    }

    //ボタンのサイズ
    int imageWidth = 250;
    int imageHeight = 100;
    int imageWindowWidth = 864;
    int imageWindowHeight = 486;
    string setText = "Window";
    // ヘッダーテキストの参照を保存
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
            // image用のゲームオブジェクトを作成
            GameObject menuScreenButtonImageObject = new GameObject(menuScreenButtonList[i]);

            // imageコンポーネントを追加
            Image menuScreenButtonImage = menuScreenButtonImageObject.AddComponent<Image>();

            // canvasの子要素に設定
            menuScreenButtonImageObject.transform.SetParent(menuScreenButtonCanvas.transform, false);

            // 仮の背景
            Texture2D menuScreenButtonTexture = Resources.Load<Texture2D>("WindowButton");
            Sprite sprite = Sprite.Create(menuScreenButtonTexture, new Rect(0, 0, menuScreenButtonTexture.width, menuScreenButtonTexture.height), new Vector2(0.5f, 0.5f));
            menuScreenButtonImage.sprite = sprite;

            // ボタンの配置
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
            // image用のゲームオブジェクトを作成
            GameObject menuScreenButtonHitboxImageObject = new GameObject(menuScreenButtonList[i] + "Hitbox");

            // imageコンポーネントを追加
            Image hitBoxImage = menuScreenButtonHitboxImageObject.AddComponent<Image>();

            // 透明にする
            hitBoxImage.color = new Color(1, 1, 1, 0);
            menuScreenButtonHitboxImageObject.transform.SetParent(footerMenuBarButtonHitboxCanvas.transform, false);

            // ボタンの配置
            RectTransform rectTransform = menuScreenButtonHitboxImageObject.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(imageWidth, imageHeight);
            rectTransform.sizeDelta = new Vector2(imageWidth, imageHeight);
            rectTransform.anchorMin = new Vector2(rectTransform.anchorMin.x, 1);
            rectTransform.anchorMax = new Vector2(rectTransform.anchorMax.x, 1);
            rectTransform.pivot = new Vector2(rectTransform.pivot.x, 1);
            Debug.Log(0 - imageWidth / 2 * (menuScreenButtonList.Count - 1) + imageWidth * i);
            rectTransform.anchoredPosition = new Vector2(0 - imageWidth / 2 * (menuScreenButtonList.Count - 1) + imageWidth * i, 0 - rectTransform.rect.height);

            // イベントを追加（ボタンやタップを検出）
            switch (i)
            {
                case 0:
                    Debug.Log("ボタン0の処理");
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
        
            // GraphicRaycasterを追加
            windowCanvasGameObject.AddComponent<GraphicRaycaster>();

            CanvasScaler canvasScaler = windowCanvas.gameObject.AddComponent<CanvasScaler>();
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.referenceResolution = new Vector2(1920, 1080);
            canvasScaler.matchWidthOrHeight = 0.5f;


            // image用のゲームオブジェクトを作成
            GameObject windowBackgroundImageObject = new GameObject("WindowBackgroundImage");

            // imageコンポーネントを追加
            Image windowBackgroundImage = windowBackgroundImageObject.AddComponent<Image>();
        
            // canvasの子要素に設定
            windowBackgroundImageObject.transform.SetParent(windowCanvasGameObject.transform, false);

            // 仮の背景
            Texture2D windowBackgroundTexture = Resources.Load<Texture2D>("WindowBackground");
            Sprite sprite = Sprite.Create(windowBackgroundTexture, new Rect(0, 0, windowBackgroundTexture.width, windowBackgroundTexture.height), new Vector2(0.5f, 0.5f));
            windowBackgroundImage.sprite = sprite;

            // ImageのRectTransform設定
            RectTransform imageRect = windowBackgroundImageObject.GetComponent<RectTransform>();
            //imageRect.SetParent(windowCanvas.transform, false);
            imageRect.sizeDelta = new Vector2(imageWindowWidth, imageWindowHeight);
            imageRect.anchorMin = new Vector2(0.5f, 0.5f); // 中心基準
            imageRect.anchorMax = new Vector2(0.5f, 0.5f);
            imageRect.pivot = new Vector2(0.5f, 0.5f);
            imageRect.anchoredPosition = new Vector2(0, 0); 

            // Textの追加
            GameObject windowTextObject = new GameObject("WindowText");
            windowTextObject.transform.SetParent(windowCanvas.transform, false);

            // Textコンポーネントの追加 (TextMeshProを推奨)
            windowText = windowTextObject.AddComponent<Text>();

            // フォントを設定（デフォルトの Arial フォントを使用）
            windowText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");

            // テキストの設定
            Debug.Log(setText);
            windowText.text = setText;
            windowText.fontSize = 36;
            windowText.alignment = TextAnchor.UpperCenter;
            windowText.color = Color.black;

            // テキストのRectTransform設定
            RectTransform textRect = windowTextObject.GetComponent<RectTransform>();
            textRect.sizeDelta = imageRect.sizeDelta;
            textRect.anchoredPosition = Vector2.zero;

            windowCanvas.sortingOrder = 15;
            Debug.Log("処理完了");

            if (windowCanvasGameObject == null)
            {
                Debug.LogError("windowCanvasGameObject is Null");
            }
        }
        // ウィンドウを表示
        windowCanvasGameObject.SetActive(true);
    }

    // すべての画面を非表示にする
    public void DeactivateAllMenuWindows()
    {
        if (windowCanvasGameObject != null)
        {
            windowCanvasGameObject.SetActive(false);
        }
    }

}
