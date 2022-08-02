using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public List<Ball> BallList;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            BallList.Add(other.GetComponent<Ball>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            BallList.Remove(other.GetComponent<Ball>());
        }
    }
}
