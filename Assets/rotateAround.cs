using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateAround : MonoBehaviour
{
    [SerializeField] bool x;
    [SerializeField] bool y;
    [SerializeField] bool z;
    [SerializeField] bool isClockWise;
    public int speed;
    void Update()
    {
        if (x) transform.Rotate(new Vector3(1, 0, 0), 90 * Time.deltaTime*speed, Space.Self);
        else if (y)
        {
            if (isClockWise)
            {
                transform.Rotate(new Vector3(0, 1, 0), 90 * Time.deltaTime*speed, Space.Self);
            }
            else
            {
                transform.Rotate(new Vector3(0, 1, 0), -90 * Time.deltaTime*speed, Space.Self);
            }
        }

        else if (z)
        {
            if (isClockWise)
            {
                transform.Rotate(new Vector3(0, 0, 1), 90 * Time.deltaTime*speed, Space.Self);
            }
            else
            {
                transform.Rotate(new Vector3(0, 0, 1), -90 * Time.deltaTime*speed, Space.Self);
            }
        }
    }
}
