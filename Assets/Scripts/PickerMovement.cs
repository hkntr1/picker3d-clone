using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using DG.Tweening;

public class PickerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float firstSpeed;
    public MeshCollider meshCollider;
    public BoxCollider boxCollider;
    [SerializeField] float horizontalSpeed;
    [SerializeField] DynamicJoystick dj;
    [SerializeField] float horizontalInput;
    public bool isFly;

    #region Singleton
    public static PickerMovement instance;

    void Awake()
    {
        instance = this;
    }
    #endregion
    void Start()
    {
        firstSpeed = speed;

        meshCollider = GetComponent<MeshCollider>();
        boxCollider = GetComponent<BoxCollider>();
    }
    void FixedUpdate()
    {
        if (speed < 0)
        {
            speed = 0;
        }
        if (StateManager.instance.eState == GameState.Runner||StateManager.instance.eState==GameState.Ramp)
        {
            if (isFly)
            {
                transform.DORotate(new Vector3(90,0,0),5f);
            }
            rb.MovePosition(transform.position + Vector3.right * dj.Horizontal * horizontalSpeed * Time.fixedDeltaTime + transform.TransformDirection(Vector3.up) * speed * Time.fixedDeltaTime);
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
        if (StateManager.instance.eState == GameState.Finish)
        {
            rb.MovePosition(transform.position + Vector3.right * dj.Horizontal * horizontalSpeed * Time.fixedDeltaTime + transform.TransformDirection(Vector3.up) * speed * Time.fixedDeltaTime);
        }
    }
}
