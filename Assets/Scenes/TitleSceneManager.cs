using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleSceneManager : MonoBehaviour
{
    void Start()
    {
        SetTitleBackground();
        SetGameStartHitbox();
        Debug.Log($"Window Size: {Screen.width} x {Screen.height}");
    }

    void SetTitleBackground()
    {
        // canvas用のゲームオブジェクトを作成
        GameObject titleBackgroundCanvasObject = new GameObject("TitleBackground");
        
        // Canvasコンポーネントを追加
        Canvas titleBackgroundCanvas = titleBackgroundCanvasObject.AddComponent<Canvas>();
        
        // レンダーモードをScreenSpaceCameraに設定
        titleBackgroundCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        titleBackgroundCanvasObject.AddComponent<GraphicRaycaster>();       
        
        // EventSystemを生成(ボタンやイベントで遷移などをする際には必ず必要)
        GameObject eventSystemObject = new GameObject("TitleEventSystem");
        eventSystemObject.AddComponent<EventSystem>();
        eventSystemObject.AddComponent<StandaloneInputModule>();
        
        // image用のゲームオブジェクトを作成
        GameObject titleBackgroundImageObject = new GameObject("TitleBackgroundImage");
        
        // imageコンポーネントを追加
        Image titleBackgroundImage = titleBackgroundImageObject.AddComponent<Image>();
        
        // canvasの子要素に設定
        titleBackgroundImageObject.transform.SetParent(titleBackgroundCanvas.transform, false);
        
        // RectTransformの設定(ウィンドウ全体に表示する)
        RectTransform rectTransform = titleBackgroundImageObject.GetComponent<RectTransform>();
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;

        // 仮の背景
        Texture2D titleBackgroundTexture = Resources.Load<Texture2D>("DefaultTitleBackground");
        Sprite sprite = Sprite.Create(titleBackgroundTexture, new Rect(0, 0, titleBackgroundTexture.width, titleBackgroundTexture.height), new Vector2(0.5f, 0.5f));
        titleBackgroundImage.sprite = sprite;
    }

    void SetGameStartHitbox()
    {
        // canvas用のゲームオブジェクトを作成
        GameObject gameStartHitboxCanvasObject = new GameObject("GameStart");
        GameObject parentCanvas = GameObject.Find("TitleBackground");
        gameStartHitboxCanvasObject.AddComponent<GraphicRaycaster>();

        // image用のゲームオブジェクトを作成
        GameObject gameStartHitboxImageObject = new GameObject("GameStartImage");
        
        // imageコンポーネントを追加
        Image gameStartHitboxImage = gameStartHitboxImageObject.AddComponent<Image>();
        
        // 透明にする
        gameStartHitboxImage.color = new Color(1, 1, 1, 0f); 
        
        // canvasの子要素に設定
        gameStartHitboxImageObject.transform.SetParent(parentCanvas.transform, false);

        // ボタン使用時の動作(呼び出す関数)
        parentCanvas.AddComponent<Button>().onClick.AddListener(() => GameStartHitboxClicked());
    }

    void GameStartHitboxClicked()
    {
        // Homeシーンに遷移させる
        Debug.Log("gameStartHitboxClicked");
        SceneManager.LoadScene("MainScene");
    }
}
