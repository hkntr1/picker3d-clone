using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && StateManager.instance.eState == GameState.StartScreen)
        {
            StateManager.instance.UpdateGameState(GameState.Runner);
        }
    }
}
