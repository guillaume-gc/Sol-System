using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalCamera : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject localCamRef;
    public GameObject centerCamRef;
    public int zoomSpeed = 50;

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
            // Zoom with mouse wheel (if not too close)
            float scrollWheelAxis = Input.GetAxis("Mouse ScrollWheel");
            if (scrollWheelAxis != 0 &&
                !(mainCamera.transform.localPosition.z < 1.5 && Input.GetAxis("Mouse ScrollWheel") > 0))
            {
                Debug.Log("Mouse ScrollWheel " + Input.GetAxis("Mouse ScrollWheel") + " local position z " + mainCamera.transform.localPosition.z);
                mainCamera.transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * zoomSpeed);
            }

            if (centerCamRef != null)
            {
                mainCamera.transform.LookAt(centerCamRef.transform);
            }
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

            if (centerCamRef != null)
            {
                mainCamera.transform.LookAt(centerCamRef.transform);
            }
        }
    }

    private void FocusedEvent()
    {

    }
}
