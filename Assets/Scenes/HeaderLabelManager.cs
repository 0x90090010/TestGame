using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeaderLabelManager : MonoBehaviour
{
    // �w�b�_�[�e�L�X�g�̎Q�Ƃ�ۑ�
    private Text headerText;  

    public void SetHeaderLabel(string setText, Canvas canvas)
    {
        // image�p�̃Q�[���I�u�W�F�N�g���쐬
        GameObject headerLabelImageObject = new GameObject("HeaderLabelImage");

        // �Ăяo������canvas�̎q�v�f�ɐݒ�
        headerLabelImageObject.transform.SetParent(canvas.transform, false);


        // image�R���|�[�l���g��ǉ�
        Image headerLabelImage = headerLabelImageObject.AddComponent<Image>();

        // ���̔w�i
        Texture2D headerLabelTexture = Resources.Load<Texture2D>("DefaultHeaderLabel");
        Sprite sprite = Sprite.Create(headerLabelTexture, new Rect(0, 0, headerLabelTexture.width, headerLabelTexture.height), new Vector2(0.5f, 0.5f));
        headerLabelImage.sprite = sprite;

        // Image��RectTransform�ݒ�
        RectTransform imageRect = headerLabelImageObject.GetComponent<RectTransform>();
        //RectTransform imageRect = headerLabelCanvas.GetComponent<RectTransform>();
        imageRect.sizeDelta = new Vector2(300, 100); // �T�C�Y��K�X����
        imageRect.anchorMin = new Vector2(0f, 1f); // ����
        imageRect.anchorMax = new Vector2(0f, 1f);
        imageRect.pivot = new Vector2(0f, 1f);
        imageRect.anchoredPosition = new Vector2(10, -10); // �����I�t�Z�b�g

        // --- Text�̒ǉ� ---
        GameObject headerLabeltextObject = new GameObject(setText + "HeaderText");
        headerLabeltextObject.transform.SetParent(headerLabelImageObject.transform, false);

        // Text�R���|�[�l���g�̒ǉ� (TextMeshPro�𐄏�)
        headerText = headerLabeltextObject.AddComponent<Text>();

        // �t�H���g��ݒ�i�f�t�H���g�� Arial �t�H���g���g�p�j
        headerText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");

        // �e�L�X�g�̐ݒ�
        Debug.Log(setText);
        headerText.text = setText;
        headerText.fontSize = 36;
        headerText.alignment = TextAnchor.MiddleCenter;
        headerText.color = Color.black;

        // �e�L�X�g��RectTransform�ݒ�
        RectTransform textRect = headerLabeltextObject.GetComponent<RectTransform>();
        textRect.sizeDelta = imageRect.sizeDelta;
        textRect.anchoredPosition = Vector2.zero;
        Debug.Log("��������");
    }

    public void ChangeHeaderText(string newText)
    {

        if (headerText != null)
        {
            headerText.text = newText;
        }
    }
}

