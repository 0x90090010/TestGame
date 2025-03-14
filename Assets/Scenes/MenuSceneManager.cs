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
        // canvas用のゲームオブジェクトを作成
        GameObject menuBackgroundCanvasObject = new GameObject("MenuBackground");

        // Canvasコンポーネントを追加
        Canvas menuBackgroundCanvas = menuBackgroundCanvasObject.AddComponent<Canvas>();

        // レンダーモードをScreenSpaceCameraに設定
        menuBackgroundCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        menuBackgroundCanvasObject.AddComponent<GraphicRaycaster>();

        // EventSystemを生成(ボタンやイベントで遷移などをする際には必ず必要)
        GameObject eventSystemObject = new GameObject("MenuEventSystem");
        eventSystemObject.AddComponent<EventSystem>();
        eventSystemObject.AddComponent<StandaloneInputModule>();

        // image用のゲームオブジェクトを作成
        GameObject menuBackgroundImageObject = new GameObject("MenuBackgroundImage");

        // imageコンポーネントを追加
        Image menuBackgroundImage = menuBackgroundImageObject.AddComponent<Image>();

        // canvasの子要素に設定
        menuBackgroundImageObject.transform.SetParent(menuBackgroundCanvas.transform, false);

        // RectTransformの設定(ウィンドウ全体に表示する)
        RectTransform rectTransform = menuBackgroundImageObject.GetComponent<RectTransform>();
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;

        // 仮の背景
        Texture2D menuBackgroundTexture = Resources.Load<Texture2D>("DefaultMenuBackground");
        Sprite sprite = Sprite.Create(menuBackgroundTexture, new Rect(0, 0, menuBackgroundTexture.width, menuBackgroundTexture.height), new Vector2(0.5f, 0.5f));
        menuBackgroundImage.sprite = sprite;
    }

    void SetFooterMenuBar()
    {
        // FooterMenuBarの呼び出し
        Canvas canvas = FindObjectOfType<Canvas>();
        GameObject footerMenuBarObject = new GameObject("FooterMenuBar");
        footerMenuBarObject.transform.SetParent(canvas.transform, false);
        FooterMenuBarManager footerMenuBar = footerMenuBarObject.AddComponent<FooterMenuBarManager>();
        footerMenuBar.SetFooterMenuButton();
    }
}
