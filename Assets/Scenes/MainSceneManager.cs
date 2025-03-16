using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    // UIの各画面（ホーム、クエスト、バトルなど）を格納するための変数
    public GameObject headerLabelCanvasObject;              // ヘッダー
    public GameObject footerMenuBarCanvasObject;            // フッター
    public GameObject mainScreenEventSystemGameObject;      // イベント用ゲームオブジェクト
    public GameObject homeScreenCanvasObject;               // ホーム画面
    public GameObject menuScreenCanvasObject;               // クエスト画面

    public string screenName;

    void Start()
    {
        // ゲーム状態に基づいて適切な画面を表示
        switch (GameManager.currentState)
        {
            case GameManager.GameState.Home:
                screenName = "Home";
                SetHomeScreen();
                SetHeaderLabel();
                SetFooterMenuBar();
                SetMainScreenEvent();
                break;

            case GameManager.GameState.Menu:
                screenName = "Menu";
                SetMenuScreen();
                SetHeaderLabel();
                SetFooterMenuBar();
                SetMainScreenEvent();
                break;
        }
    }

    public void SetFooterMenuBar()
    {
        if (footerMenuBarCanvasObject == null)
        {
            // headerScreenLabelのGameObjectを作成
            footerMenuBarCanvasObject = new GameObject("FooterMenuBar");

            // homeScreen用のCanvasを作成
            Canvas footerMenuBarCanvas = footerMenuBarCanvasObject.AddComponent<Canvas>();
            footerMenuBarCanvas.renderMode = RenderMode.ScreenSpaceCamera;

            // GraphicRaycasterを追加
            footerMenuBarCanvasObject.AddComponent<GraphicRaycaster>();

            // canvasの子要素に設定
            footerMenuBarCanvasObject.transform.SetParent(footerMenuBarCanvas.transform, false);

            // HeaderAreaLabelManager をアタッチ
            FooterMenuBarManager footerMenuBar = headerLabelCanvasObject.AddComponent<FooterMenuBarManager>();
            footerMenuBar.SetFooterMenuBarBackground();
            footerMenuBarCanvas.sortingOrder = 10;
        }
    }

    public void SetHeaderLabel()
    {
        if (headerLabelCanvasObject == null)
        {
            // headerScreenLabelのGameObjectを作成
            headerLabelCanvasObject = new GameObject("HeaderScreenLabel");

            // homeScreen用のCanvasを作成
            Canvas headerLabelCanvas = headerLabelCanvasObject.AddComponent<Canvas>();

            // レンダーモードをScreenSpaceCameraに設定
            headerLabelCanvas.renderMode = RenderMode.ScreenSpaceCamera;

            // GraphicRaycasterを追加
            headerLabelCanvasObject.AddComponent<GraphicRaycaster>();

            // canvasの子要素に設定
            headerLabelCanvasObject.transform.SetParent(headerLabelCanvas.transform, false);

            // HeaderAreaLabelManager をアタッチ
            HeaderLabelManager headerLabel = headerLabelCanvasObject.AddComponent<HeaderLabelManager>();
            headerLabel.SetHeaderLabel(screenName, headerLabelCanvas);
            headerLabelCanvas.sortingOrder = 10;
        }
    }

    public void SetMainScreenEvent()
    {
        if (mainScreenEventSystemGameObject == null)
        {
            // EventSystemを生成(ボタンやイベントで遷移などをする際には必ず必要)
            mainScreenEventSystemGameObject = new GameObject("mainEventSystem");
            mainScreenEventSystemGameObject.AddComponent<EventSystem>();
            mainScreenEventSystemGameObject.AddComponent<StandaloneInputModule>();
        }
    }

    // ホーム画面を表示
    public void SetHomeScreen()
    {
        DeactivateAllScreens();
        if (homeScreenCanvasObject == null)
        {
            // homeScreenのGameObjectを作成
            homeScreenCanvasObject = new GameObject("HomeScreen");            
            Canvas homeScreenCanvas = homeScreenCanvasObject.AddComponent<Canvas>();

            // レンダーモードをScreenSpaceCameraに設定
            homeScreenCanvas.renderMode = RenderMode.ScreenSpaceCamera;

            // GraphicRaycasterを追加
            homeScreenCanvasObject.AddComponent<GraphicRaycaster>();

            // canvasの子要素に設定
            homeScreenCanvasObject.transform.SetParent(homeScreenCanvas.transform, false);

            // HomeScreenManager をアタッチ
            HomeScreenManager homeScreen = homeScreenCanvasObject.AddComponent<HomeScreenManager>();
            homeScreen.HomeScreen(homeScreenCanvas);
            homeScreenCanvas.sortingOrder = 5;
        }

        // ホームを表示
        homeScreenCanvasObject.SetActive(true);

        // ヘッダーとフッターを表示
        if (headerLabelCanvasObject != null && !headerLabelCanvasObject.activeSelf)
        {
            headerLabelCanvasObject.SetActive(true);
        }
        if (footerMenuBarCanvasObject != null && !footerMenuBarCanvasObject.activeSelf)
        {
            footerMenuBarCanvasObject.SetActive(true);
        }
        
    }

    // メニュー画面を表示
    public void SetMenuScreen()
    {
        DeactivateAllScreens();

        if (menuScreenCanvasObject == null)
        {
            // homeScreenのGameObjectを作成
            menuScreenCanvasObject = new GameObject("MenuScreen");
            Canvas menuScreenCanvas = menuScreenCanvasObject.AddComponent<Canvas>();

            // レンダーモードをScreenSpaceCameraに設定
            menuScreenCanvas.renderMode = RenderMode.ScreenSpaceCamera;

            // GraphicRaycasterを追加
            menuScreenCanvasObject.AddComponent<GraphicRaycaster>();

            // canvasの子要素に設定
            menuScreenCanvasObject.transform.SetParent(menuScreenCanvas.transform, false);

            // HomeScreenManager をアタッチ
            MenuScreenManager menuScreen = menuScreenCanvasObject.AddComponent<MenuScreenManager>();
            menuScreen.MenuScreen(menuScreenCanvas);
            menuScreenCanvas.sortingOrder = 5;
        }

        // メニューを表示
        menuScreenCanvasObject.SetActive(true);

        // ヘッダーとフッターを表示
        if (headerLabelCanvasObject != null && !headerLabelCanvasObject.activeSelf)
        {
            headerLabelCanvasObject.SetActive(true);
        }
        if (footerMenuBarCanvasObject != null && !footerMenuBarCanvasObject.activeSelf)
        {
            footerMenuBarCanvasObject.SetActive(true);
        }
    }

    // すべての画面を非表示にする
    private void DeactivateAllScreens()
    {
        if (homeScreenCanvasObject != null)
        {
            homeScreenCanvasObject.SetActive(false);
        }
        if (menuScreenCanvasObject != null)
        {
            menuScreenCanvasObject.SetActive(false);
        }
    }
}
