using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuScreenManager : MonoBehaviour
{
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
    }
}
