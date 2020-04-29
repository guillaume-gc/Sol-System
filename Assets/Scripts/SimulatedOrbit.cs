using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulatedOrbit : MonoBehaviour
{
    public GameObject rotateFrom;
    public GameObject center;
    public float orbitSpeed = 20f;
    public float orbitXAxis = 0f;
    public float orbitYAxis = 1f;
    public float orbitZAxis = 0f;

    private Vector3 rotateFromLocation;
    private Vector3 distanceFromCenter;

    void Start()
    {
        rotateFromLocation = rotateFrom.transform.position;
        distanceFromCenter = transform.position - rotateFromLocation;
    }

    void FixedUpdate()
    {
        rotateFromLocation = rotateFrom.transform.position;

        // Spin the object around the world origin at orbitSpeed - 10 degrees/second.
        transform.RotateAround(rotateFromLocation, new Vector3(orbitXAxis, orbitYAxis, orbitZAxis), orbitSpeed * Time.deltaTime);

        // The behavior is repeted for the object center (the object rotate, but not its center)
        center.transform.position = transform.position;
    }
}
