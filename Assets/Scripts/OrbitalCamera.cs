using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalCamera : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject localCamRef;
    public GameObject centerCamRef;

    public int zoomSpeed = 50;
    public float cameraSpeedH = 2.0f;
    public float cameraSpeedV = 2.0f;

    private bool camIsFocused;

    // Start is called before the first frame update
    void Start()
    {
        camIsFocused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (camIsFocused)
        {
            FocusedEvent();
        }
    }

    void OnMouseDown()
    {
        if (Input.GetKey("mouse 0"))
        {
            Debug.Log("User pressed mouse 0 on " + ToString() + " local cam ref is " + localCamRef.ToString());

            camIsFocused = true;
            mainCamera.transform.SetParent(localCamRef.transform);

            mainCamera.transform.localPosition = new Vector3(0f, 0f, 2f);

            mainCamera.transform.LookAt(localCamRef.transform);
        }
    }

    private void FocusedEvent()
    {
        // Zoom with mouse wheel (if not too close)
        float scrollWheelAxis = Input.GetAxis("Mouse ScrollWheel");

        if (scrollWheelAxis != 0 &&
            !(mainCamera.transform.localPosition.z < 1.5 && scrollWheelAxis > 0))
        {
            Debug.Log("Mouse ScrollWheel " + Input.GetAxis("Mouse ScrollWheel") + " local position z " + mainCamera.transform.localPosition.z);
            mainCamera.transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * zoomSpeed);
        }

        if (Input.GetMouseButton(1))
        {
            // Move mouse
            float mouseXAxis = Input.GetAxis("Mouse X");
            float mouseYAxis = Input.GetAxis("Mouse Y");

            Debug.Log("Mouse Right Button Down X Axis " + mouseXAxis + " Y Axis " + mouseYAxis);

            mainCamera.transform.Translate(-mouseXAxis, -mouseYAxis, 0);
            mainCamera.transform.LookAt(localCamRef.transform);
        }
    }
}
