using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PickerController : MonoBehaviour
{
   
    public List<Ball> Balls;
    public GameObject Wings;
    public bool isCreated;
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
            other.GetComponent<SpawnerController>().StartSpawn();
        
        }
        else if (other.CompareTag("Ramp"))
        {
            LevelController.instance.Ramp();
            if (!isCreated)
            {
            SceneManager.instance.CreateNextLevel();
                isCreated = true;
            }


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Balls.Remove(other.GetComponent<Ball>());
        }
    }
    

}
