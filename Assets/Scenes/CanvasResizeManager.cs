using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasResizeManager : MonoBehaviour
{
    private RectTransform canvasRectTransform;
    private Vector2 previousScreenSize;

    void Start()
    {
        // canvasサイズを取得
        canvasRectTransform = GetComponent<RectTransform>();
        previousScreenSize = new Vector2(Screen.width, Screen.height);
        ResizeCanvas();
    }

    void Update()
    {
        // 画面サイズが変更されたかチェック
        if (previousScreenSize.x != Screen.width || previousScreenSize.y != Screen.height)
        {
            ResizeCanvas();
            previousScreenSize = new Vector2(Screen.width, Screen.height); // 画面サイズを更新
        }
    }

    public void ResizeCanvas()
    {
        if (canvasRectTransform != null) // nullチェック
        {
            // canvasのサイズをスクリーンサイズに合わせる
            canvasRectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
            Debug.Log("resized!");
        }
    }
}
