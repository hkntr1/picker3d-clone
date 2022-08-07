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
            case GameState.Ramp:
                Ramp();
                break;
            case GameState.Fail:
                Fail();
                break;
            case GameState.Finish:
                break;
        }
        OnGameStateChanged?.Invoke(newState);
    }
    void StartScreen()
    {
        UIController.instance.StartScreen();
        LevelController.instance.StartScreen(PickerMovement.instance);
    }
    void Runner()
    {
        UIController.instance.InGame();
    }
    void Fail()
    {
        UIController.instance.Fail();
    }
    void Ramp()
    {
        UIController.instance.Ramp();
        LevelController.instance.Ramp(PickerMovement.instance);
       
    }
}
public enum GameState
{
    StartScreen,
    Runner,
    Ramp,
    Fail,
    Finish,
}
