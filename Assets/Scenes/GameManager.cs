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
        // ‰Šúó‘Ô‚ğƒz[ƒ€‰æ–Ê‚Éİ’è
        currentState = GameState.Home;
    }
}
