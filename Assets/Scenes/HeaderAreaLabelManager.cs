using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeaderAreaLabelManager : MonoBehaviour
{
    public void SetHeaderAreaLabel(string areaName, Canvas canvas)
    {
        // image�p�̃Q�[���I�u�W�F�N�g���쐬
        GameObject headerAreaLabelImageObject = new GameObject("HeaderAreaLabelImage");

        // �Ăяo������canvas�̎q�v�f�ɐݒ�
        headerAreaLabelImageObject.transform.SetParent(canvas.transform, false);


        // image�R���|�[�l���g��ǉ�
        Image headerAreaLabelImage = headerAreaLabelImageObject.AddComponent<Image>();

        // ���̔w�i
        Texture2D headerAreaLabelTexture = Resources.Load<Texture2D>("DefaultHeaderAreaLabel");
        Sprite sprite = Sprite.Create(headerAreaLabelTexture, new Rect(0, 0, headerAreaLabelTexture.width, headerAreaLabelTexture.height), new Vector2(0.5f, 0.5f));
        headerAreaLabelImage.sprite = sprite;

        // Image��RectTransform�ݒ�
        RectTransform imageRect = headerAreaLabelImageObject.GetComponent<RectTransform>();
        //RectTransform imageRect = headerAreaLabelCanvas.GetComponent<RectTransform>();
        imageRect.sizeDelta = new Vector2(300, 100); // �T�C�Y��K�X����
        imageRect.anchorMin = new Vector2(0f, 1f); // ����
        imageRect.anchorMax = new Vector2(0f, 1f);
        imageRect.pivot = new Vector2(0f, 1f);
        imageRect.anchoredPosition = new Vector2(10, -10); // �����I�t�Z�b�g

        // --- Text�̒ǉ� ---
        GameObject headerAreaLabeltextObject = new GameObject(areaName + "HeaderText");
        headerAreaLabeltextObject.transform.SetParent(headerAreaLabelImageObject.transform, false);

        // Text�R���|�[�l���g�̒ǉ� (TextMeshPro�𐄏�)
        Text text = headerAreaLabeltextObject.AddComponent<Text>();

        // �t�H���g��ݒ�i�f�t�H���g�� Arial �t�H���g���g�p�j
        text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");

        // �e�L�X�g�̐ݒ�
        Debug.Log(areaName);
        text.text = areaName;
        text.fontSize = 36;
        text.alignment = TextAnchor.MiddleCenter;
        text.color = Color.black;

        // �e�L�X�g��RectTransform�ݒ�
        RectTransform textRect = headerAreaLabeltextObject.GetComponent<RectTransform>();
        textRect.sizeDelta = imageRect.sizeDelta;
        textRect.anchoredPosition = Vector2.zero;
        Debug.Log("��������");
    }
}

