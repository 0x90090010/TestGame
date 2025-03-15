using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeaderAreaLabelManager : MonoBehaviour
{
    public void SetHeaderAreaLabel(string areaName, Canvas canvas)
    {
        // image用のゲームオブジェクトを作成
        GameObject headerAreaLabelImageObject = new GameObject("HeaderAreaLabelImage");

        // 呼び出し側のcanvasの子要素に設定
        headerAreaLabelImageObject.transform.SetParent(canvas.transform, false);


        // imageコンポーネントを追加
        Image headerAreaLabelImage = headerAreaLabelImageObject.AddComponent<Image>();

        // 仮の背景
        Texture2D headerAreaLabelTexture = Resources.Load<Texture2D>("DefaultHeaderAreaLabel");
        Sprite sprite = Sprite.Create(headerAreaLabelTexture, new Rect(0, 0, headerAreaLabelTexture.width, headerAreaLabelTexture.height), new Vector2(0.5f, 0.5f));
        headerAreaLabelImage.sprite = sprite;

        // ImageのRectTransform設定
        RectTransform imageRect = headerAreaLabelImageObject.GetComponent<RectTransform>();
        //RectTransform imageRect = headerAreaLabelCanvas.GetComponent<RectTransform>();
        imageRect.sizeDelta = new Vector2(300, 100); // サイズを適宜調整
        imageRect.anchorMin = new Vector2(0f, 1f); // 左上基準
        imageRect.anchorMax = new Vector2(0f, 1f);
        imageRect.pivot = new Vector2(0f, 1f);
        imageRect.anchoredPosition = new Vector2(10, -10); // 少しオフセット

        // --- Textの追加 ---
        GameObject headerAreaLabeltextObject = new GameObject(areaName + "HeaderText");
        headerAreaLabeltextObject.transform.SetParent(headerAreaLabelImageObject.transform, false);

        // Textコンポーネントの追加 (TextMeshProを推奨)
        Text text = headerAreaLabeltextObject.AddComponent<Text>();

        // フォントを設定（デフォルトの Arial フォントを使用）
        text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");

        // テキストの設定
        Debug.Log(areaName);
        text.text = areaName;
        text.fontSize = 36;
        text.alignment = TextAnchor.MiddleCenter;
        text.color = Color.black;

        // テキストのRectTransform設定
        RectTransform textRect = headerAreaLabeltextObject.GetComponent<RectTransform>();
        textRect.sizeDelta = imageRect.sizeDelta;
        textRect.anchoredPosition = Vector2.zero;
        Debug.Log("処理完了");
    }
}

