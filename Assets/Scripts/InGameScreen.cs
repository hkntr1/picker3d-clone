using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InGameScreen : MonoBehaviour
{
    [SerializeField] GameObject dynamicjoystick;
    public Slider forceController;
    public void Ramp()
    {
        forceController.gameObject.SetActive(true);
        dynamicjoystick.SetActive(false);
        
    }
}
