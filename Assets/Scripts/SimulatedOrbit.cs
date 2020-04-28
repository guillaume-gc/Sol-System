using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulatedOrbit : MonoBehaviour
{
    private Vector3 rotationTarget = new Vector3(0f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Spin the object around the world origin at 10 degrees/second.
        transform.RotateAround(rotationTarget, Vector3.up, 20 * Time.deltaTime);
    }
}
