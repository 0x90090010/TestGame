using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasResizeManager : MonoBehaviour
{
    private RectTransform canvasRectTransform;
    private Vector2 previousScreenSize;

    void Start()
    {
        // canvas�T�C�Y���擾
        canvasRectTransform = GetComponent<RectTransform>();
        previousScreenSize = new Vector2(Screen.width, Screen.height);
        ResizeCanvas();
    }

    void Update()
    {
        // ��ʃT�C�Y���ύX���ꂽ���`�F�b�N
        if (previousScreenSize.x != Screen.width || previousScreenSize.y != Screen.height)
        {
            ResizeCanvas();
            previousScreenSize = new Vector2(Screen.width, Screen.height); // ��ʃT�C�Y���X�V
        }
    }

    public void ResizeCanvas()
    {
        if (canvasRectTransform != null) // null�`�F�b�N
        {
            // canvas�̃T�C�Y���X�N���[���T�C�Y�ɍ��킹��
            canvasRectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
            Debug.Log("resized!");
        }
    }
}
