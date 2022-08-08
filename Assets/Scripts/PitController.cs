using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class PitController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI counterText;
    [SerializeField] int limit;
    [SerializeField] Counter counter;
    public Transform ground;
    public Transform barrier;

    void Update()
    {
        counterText.text = counter.BallList.Count.ToString()+"/"+limit.ToString();
    }
   public bool CheckLimit()
    {

        if (counter.BallList.Count >= limit)
        {
            return true;
        }
        else return false;
    }
}
