using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulatedRotation : MonoBehaviour
{
    public float rotationSpeed = 0.1f;

    void FixedUpdate()
    {
        transform.Rotate(0, rotationSpeed, 0, Space.Self);
    }
}
