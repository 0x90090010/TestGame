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
        // canvas用のゲームオブジェクトを作成
        GameObject homeBackgroundCanvasObject = new GameObject("HomeBackground");

        // Canvasコンポーネントを追加
        Canvas homeBackgroundCanvas = homeBackgroundCanvasObject.AddComponent<Canvas>();

        // レンダーモードをScreenSpaceCameraに設定
        homeBackgroundCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        homeBackgroundCanvasObject.AddComponent<GraphicRaycaster>();

        // EventSystemを生成(ボタンやイベントで遷移などをする際には必ず必要)
        GameObject eventSystemObject = new GameObject("homeEventSystem");
        eventSystemObject.AddComponent<EventSystem>();
        eventSystemObject.AddComponent<StandaloneInputModule>();

        // image用のゲームオブジェクトを作成
        GameObject homeBackgroundImageObject = new GameObject("homeBackgroundImage");

        // imageコンポーネントを追加
        Image homeBackgroundImage = homeBackgroundImageObject.AddComponent<Image>();

        // canvasの子要素に設定
        homeBackgroundImageObject.transform.SetParent(homeBackgroundCanvas.transform, false);

        // RectTransformの設定(ウィンドウ全体に表示する)
        RectTransform rectTransform = homeBackgroundImageObject.GetComponent<RectTransform>();
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;

        // 仮の背景
        Texture2D homeBackgroundTexture = Resources.Load<Texture2D>("DefaultHomeBackground");
        Sprite sprite = Sprite.Create(homeBackgroundTexture, new Rect(0, 0, homeBackgroundTexture.width, homeBackgroundTexture.height), new Vector2(0.5f, 0.5f));
        homeBackgroundImage.sprite = sprite;
    }

    // FooterMenuBarの呼び出し
    void SetFooterMenuBar()
    {

        Canvas footerMenuBarCanvas = FindObjectOfType<Canvas>();
        GameObject footerMenuBarObject = new GameObject("FooterMenuBar");
        footerMenuBarObject.transform.SetParent(footerMenuBarCanvas.transform, false);
        FooterMenuBarManager footerMenuBar = footerMenuBarObject.AddComponent<FooterMenuBarManager>();
        footerMenuBar.SetFooterMenuButton();
    }

    // HeaderAreaLabelの呼び出し
    void SetHomeHeaderLabel()
    {
        // canvas用のゲームオブジェクトを作成
        GameObject headerAreaLabelCanvasObject = new GameObject("HomeHeaderAreaLabel");

        // 既存のCanvasコンポーネントを取得
        Canvas headerAreaLabelCanvas = FindObjectOfType<Canvas>();

        // canvasの子要素に設定
        headerAreaLabelCanvasObject.transform.SetParent(headerAreaLabelCanvas.transform, false);

        // HeaderAreaLabelManager をアタッチ
        HeaderAreaLabelManager headerAreaLabel = headerAreaLabelCanvasObject.AddComponent<HeaderAreaLabelManager>();
        headerAreaLabel.SetHeaderAreaLabel("Home", headerAreaLabelCanvas);
    }
}
