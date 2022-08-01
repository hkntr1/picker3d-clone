using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class PickerMovement : MonoBehaviour
{
    [SerializeField] SplineFollower sf;
    [SerializeField] DynamicJoystick dj;
    [SerializeField] float horizontalInput;

    void Start()
    {
    }
    void FixedUpdate()
    {
        if (dj.Horizontal != 0)
        {
            horizontalInput = dj.Horizontal;
        }
       sf.motion.offset= Vector2.Lerp(sf.motion.offset,new Vector2(Mathf.Clamp(horizontalInput*1.7f,-1.7f,1.7f),0),0.1f);
    }
}
