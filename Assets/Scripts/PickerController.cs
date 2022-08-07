using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PickerController : MonoBehaviour
{
   
    public List<Ball> Balls;
    public GameObject Wings;
    public bool isCreated;
    int prizeScore;
    #region Singleton
    public static PickerController instance;

    void Awake()
    {
        instance = this;
    }
    #endregion
  
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Ball"))
        {
          Balls.Add(other.GetComponent<Ball>());
        }
        else if (other.CompareTag("CheckPoint"))
        {
            Wings.SetActive(false);
            LevelController.instance.CheckPoint(other.transform);
        }
        else if (other.CompareTag("Prize"))
        {
            Wings.SetActive(true);
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Spawner"))
        {
            var modifier = other.GetComponent<SpawnerController>();
            handleModifierState(modifier.ModifierType,other.transform);
        }
        else if (other.CompareTag("Ramp"))
        {
            StateManager.instance.UpdateGameState(GameState.Ramp);
            if (!isCreated)
            {
            SceneManager.instance.CreateNextLevel();
            isCreated = true;               
            }
        }
        else if (other.CompareTag("RampEnd"))
        {
            PickerMovement.instance.isFly = true;
        }
        else if (other.CompareTag("PrizeGround"))
        {
            if (StateManager.instance.eState!=GameState.Finish)
            {
                PickerMovement.instance.isFly=false;
                DOTween.To(() => PickerMovement.instance.speed, x => PickerMovement.instance.speed = x, 0, 1f);
                prizeScore = other.GetComponent<LevelEndController>().point;
                StartCoroutine(levelEnd(prizeScore));
            }

        }
        else if (other.CompareTag("LevelStart"))
        {
            StateManager.instance.UpdateGameState(GameState.StartScreen);
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Balls.Remove(other.GetComponent<Ball>());
        }
    }
       IEnumerator levelEnd(int score)
    {
        StateManager.instance.UpdateGameState(GameState.Finish);
        yield return new WaitForSeconds(1f);
        LevelController.instance.LevelEnd(score);
        PickerMovement.instance.speed=PickerMovement.instance.firstSpeed;
        yield return new WaitForSeconds(10f);
        SceneManager.instance.DestroyOldLevel();

    }
    private void handleModifierState(espawmerType modifierModifierType,Transform spawner)
    {
        switch (modifierModifierType)
        {
            case espawmerType.BALLBOMB:
                spawner.GetComponent<SpawnerController>().BallBomb();
                break;
            case espawmerType.HELICOPTER:
                spawner.GetComponent<SpawnerController>().StartSpawn();
                break;
        }

    }


}
