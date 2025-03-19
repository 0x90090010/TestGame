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
        // canvas�p�̃Q�[���I�u�W�F�N�g���쐬
        GameObject titleBackgroundCanvasObject = new GameObject("TitleBackground");
        
        // Canvas�R���|�[�l���g��ǉ�
        Canvas titleBackgroundCanvas = titleBackgroundCanvasObject.AddComponent<Canvas>();
        
        // �����_�[���[�h��ScreenSpaceCamera�ɐݒ�
        titleBackgroundCanvas.renderMode = RenderMode.ScreenSpaceCamera;
        titleBackgroundCanvasObject.AddComponent<GraphicRaycaster>();       
        
        // EventSystem�𐶐�(�{�^����C�x���g�őJ�ڂȂǂ�����ۂɂ͕K���K�v)
        GameObject eventSystemObject = new GameObject("TitleEventSystem");
        eventSystemObject.AddComponent<EventSystem>();
        eventSystemObject.AddComponent<StandaloneInputModule>();
        
        // image�p�̃Q�[���I�u�W�F�N�g���쐬
        GameObject titleBackgroundImageObject = new GameObject("TitleBackgroundImage");
        
        // image�R���|�[�l���g��ǉ�
        Image titleBackgroundImage = titleBackgroundImageObject.AddComponent<Image>();
        
        // canvas�̎q�v�f�ɐݒ�
        titleBackgroundImageObject.transform.SetParent(titleBackgroundCanvas.transform, false);
        
        // RectTransform�̐ݒ�(�E�B���h�E�S�̂ɕ\������)
        RectTransform rectTransform = titleBackgroundImageObject.GetComponent<RectTransform>();
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;

        // ���̔w�i
        Texture2D titleBackgroundTexture = Resources.Load<Texture2D>("DefaultTitleBackground");
        Sprite sprite = Sprite.Create(titleBackgroundTexture, new Rect(0, 0, titleBackgroundTexture.width, titleBackgroundTexture.height), new Vector2(0.5f, 0.5f));
        titleBackgroundImage.sprite = sprite;
    }

    void SetGameStartHitbox()
    {
        // canvas�p�̃Q�[���I�u�W�F�N�g���쐬
        GameObject gameStartHitboxCanvasObject = new GameObject("GameStart");
        GameObject parentCanvas = GameObject.Find("TitleBackground");
        gameStartHitboxCanvasObject.AddComponent<GraphicRaycaster>();

        // image�p�̃Q�[���I�u�W�F�N�g���쐬
        GameObject gameStartHitboxImageObject = new GameObject("GameStartImage");
        
        // image�R���|�[�l���g��ǉ�
        Image gameStartHitboxImage = gameStartHitboxImageObject.AddComponent<Image>();
        
        // �����ɂ���
        gameStartHitboxImage.color = new Color(1, 1, 1, 0f); 
        
        // canvas�̎q�v�f�ɐݒ�
        gameStartHitboxImageObject.transform.SetParent(parentCanvas.transform, false);

        // �{�^���g�p���̓���(�Ăяo���֐�)
        parentCanvas.AddComponent<Button>().onClick.AddListener(() => GameStartHitboxClicked());
    }

    void GameStartHitboxClicked()
    {
        // Home�V�[���ɑJ�ڂ�����
        Debug.Log("gameStartHitboxClicked");
        SceneManager.LoadScene("MainScene");
    }
}
