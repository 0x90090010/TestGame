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
        // ������Ԃ��z�[����ʂɐݒ�
        currentState = GameState.Home;
    }
}
