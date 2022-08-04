using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateManager : MonoBehaviour
{
    public GameState eState;
    public static event Action<GameState> OnGameStateChanged;
    #region Singleton
    public static StateManager instance;

    void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;
    }
    #endregion
    void Start()
    {
        UpdateGameState(GameState.StartScreen);
    }
    public void UpdateGameState(GameState newState, Transform target = null)
    {
        eState = newState;
        switch (newState)
        {
            case GameState.StartScreen:
                StartScreen();
                break;
            case GameState.Runner:
                Runner();
                break;
            case GameState.Fail:
                Fail();
                break;
        }
        OnGameStateChanged?.Invoke(newState);
    }
    void StartScreen()
    {
        UIController.instance.StartScreen();
    }
    void Runner()
    {
        UIController.instance.InGame();
    }
    void Fail()
    {
        UIController.instance.Fail();
    }
    
}
public enum GameState
{
    StartScreen,
    Runner,
    Fail,
}
