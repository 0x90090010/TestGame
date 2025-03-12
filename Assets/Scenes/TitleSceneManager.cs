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
        //canvas用のゲームオブジェクトを作成
        GameObject titleBackgroundCanvasObject = new GameObject("TitleBackground");
        //Canvasコンポーネントを追加
        Canvas titleBackgroundCanvas = titleBackgroundCanvasObject.AddComponent<Canvas>();
        //レンダーモードをScreenSpaceCameraに設定
        titleBackgroundCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        titleBackgroundCanvasObject.AddComponent<GraphicRaycaster>();

        //image用のゲームオブジェクトを作成
        GameObject titleBackgroundImageObject = new GameObject("TitleBackgroundImage");
        //imageコンポーネントを追加
        Image titleBackgroundImage = titleBackgroundImageObject.AddComponent<Image>();
        //canvasの子要素に設定
        titleBackgroundImageObject.transform.SetParent(titleBackgroundCanvas.transform, false);
        // RectTransformの設定(ウィンドウ全体に表示する)
        RectTransform rectTransform = titleBackgroundImageObject.GetComponent<RectTransform>();
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;

        //仮の背景
        Texture2D titleBackgroundTexture = Resources.Load<Texture2D>("defaultTitleBackground");
        Sprite sprite = Sprite.Create(titleBackgroundTexture, new Rect(0, 0, titleBackgroundTexture.width, titleBackgroundTexture.height), new Vector2(0.5f, 0.5f));
        titleBackgroundImage.sprite = sprite;
    }

}
