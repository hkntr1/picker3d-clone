using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class PickerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    [SerializeField] float horizontalSpeed;
    [SerializeField] DynamicJoystick dj;
    [SerializeField] float horizontalInput;
    #region Singleton
    public static PickerMovement instance;

    void Awake()
    {
        instance = this;
    }
    #endregion
    void Start()
    {
    }
    void FixedUpdate()
    {
        rb.MovePosition(transform.position+Vector3.right*dj.Horizontal*horizontalSpeed*Time.fixedDeltaTime+Vector3.forward*speed*Time.fixedDeltaTime);
        if (transform.position.x > 1.7f)
        {
            Vector3 newPos = transform.position;
            newPos.x = 1.7f;
            transform.position = newPos;
        }
        if (transform.position.x < -1.7f)
        {
            Vector3 newPos = transform.position;
            newPos.x = -1.7f;
            transform.position = newPos;
        }
    }
}
