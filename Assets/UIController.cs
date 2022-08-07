using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public InGameScreen inGame;
    public StartScreenController startScreen;
    public FailScreen failScreen;
    #region Singleton
    public static UIController instance;

    void Awake()
    {
        instance = this;
    }
    #endregion
    public void StartScreen()
    {
        startScreen.gameObject.SetActive(true);
        inGame.gameObject.SetActive(false);
        failScreen.gameObject.SetActive(false);
        inGame.StartScreen();
    }
    public void InGame()
    {
        inGame.gameObject.SetActive(true);
        startScreen.gameObject.SetActive(false);
        failScreen.gameObject.SetActive(false);
    }
    public void Fail()
    {
        failScreen.gameObject.SetActive(true);
        startScreen.gameObject.SetActive(false);
        inGame.gameObject.SetActive(false);
    }
    public void Ramp()
    {
        inGame.Ramp();
    }
}
