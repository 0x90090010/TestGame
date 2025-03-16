using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeScreenManager : MonoBehaviour
{
    public void HomeScreen(Canvas canvas)
    {
        // image用のゲームオブジェクトを作成
        GameObject homeBackgroundImageObject = new GameObject("homeBackgroundImage");

        // 呼び出し側のcanvasの子要素に設定
        homeBackgroundImageObject.transform.SetParent(canvas.transform, false);

        // imageコンポーネントを追加
        Image homeBackgroundImage = homeBackgroundImageObject.AddComponent<Image>();

        // 仮の背景
        Texture2D homeBackgroudTexture = Resources.Load<Texture2D>("DefaultHomeBackground");
        Sprite sprite = Sprite.Create(homeBackgroudTexture, new Rect(0, 0, homeBackgroudTexture.width, homeBackgroudTexture.height), new Vector2(0.5f, 0.5f));
        homeBackgroundImage.sprite = sprite;

        // RectTransformの設定(ウィンドウ全体に表示する)
        RectTransform rectTransform = homeBackgroundImageObject.GetComponent<RectTransform>();
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;
    }
}
