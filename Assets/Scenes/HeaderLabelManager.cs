using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeaderLabelManager : MonoBehaviour
{
    // ヘッダーテキストの参照を保存
    private Text headerText;  

    public void SetHeaderLabel(string setText, Canvas canvas)
    {
        // image用のゲームオブジェクトを作成
        GameObject headerLabelImageObject = new GameObject("HeaderLabelImage");

        // 呼び出し側のcanvasの子要素に設定
        headerLabelImageObject.transform.SetParent(canvas.transform, false);


        // imageコンポーネントを追加
        Image headerLabelImage = headerLabelImageObject.AddComponent<Image>();

        // 仮の背景
        Texture2D headerLabelTexture = Resources.Load<Texture2D>("DefaultHeaderLabel");
        Sprite sprite = Sprite.Create(headerLabelTexture, new Rect(0, 0, headerLabelTexture.width, headerLabelTexture.height), new Vector2(0.5f, 0.5f));
        headerLabelImage.sprite = sprite;

        // ImageのRectTransform設定
        RectTransform imageRect = headerLabelImageObject.GetComponent<RectTransform>();
        //RectTransform imageRect = headerLabelCanvas.GetComponent<RectTransform>();
        imageRect.sizeDelta = new Vector2(300, 100); // サイズを適宜調整
        imageRect.anchorMin = new Vector2(0f, 1f); // 左上基準
        imageRect.anchorMax = new Vector2(0f, 1f);
        imageRect.pivot = new Vector2(0f, 1f);
        imageRect.anchoredPosition = new Vector2(10, -10); // 少しオフセット

        // --- Textの追加 ---
        GameObject headerLabeltextObject = new GameObject(setText + "HeaderText");
        headerLabeltextObject.transform.SetParent(headerLabelImageObject.transform, false);

        // Textコンポーネントの追加 (TextMeshProを推奨)
        headerText = headerLabeltextObject.AddComponent<Text>();

        // フォントを設定（デフォルトの Arial フォントを使用）
        headerText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");

        // テキストの設定
        Debug.Log(setText);
        headerText.text = setText;
        headerText.fontSize = 36;
        headerText.alignment = TextAnchor.MiddleCenter;
        headerText.color = Color.black;

        // テキストのRectTransform設定
        RectTransform textRect = headerLabeltextObject.GetComponent<RectTransform>();
        textRect.sizeDelta = imageRect.sizeDelta;
        textRect.anchoredPosition = Vector2.zero;
        Debug.Log("処理完了");
    }

    public void ChangeHeaderText(string newText)
    {

        if (headerText != null)
        {
            headerText.text = newText;
        }
    }
}

