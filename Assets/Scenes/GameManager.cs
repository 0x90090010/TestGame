using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Home,
        Menu
    }

    public static GameState currentState;

    void Awake()
    {
        // 初期状態をホーム画面に設定
        currentState = GameState.Home;
    }
}
