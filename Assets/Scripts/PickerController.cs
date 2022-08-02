using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PickerController : MonoBehaviour
{
   
    public List<Ball> Balls;
    
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
            LevelController.instance.CheckPoint(other.transform);
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
