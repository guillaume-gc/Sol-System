using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusManager : MonoBehaviour
{
    public int zoomSpeed = 10;
    public float cameraSpeedH = 2.0f;
    public float cameraSpeedV = 2.0f;

    private GameObject currentBodyCamRef;

    private bool isFocused;

    // Start is called before the first frame update
    void Start()
    {
        isFocused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastingRightClick();
        }
        else if (isFocused)
        {
            FocusedEvent();
        }
    }

    private void RaycastingRightClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            string hitObjectName = hit.collider.gameObject.name;
            string camRefName = hitObjectName + "Center";

            // Did the user click on a body (planet, moon, etc...)?
            if (hit.collider.gameObject.CompareTag("Body"))
            {
               
                Debug.Log("Clicked on " + hitObjectName);
                currentBodyCamRef = GameObject.Find(camRefName);

                transform.parent = currentBodyCamRef.transform;

                transform.localPosition = new Vector3(0f, 0f, 2f);

                transform.LookAt(currentBodyCamRef.transform);

                isFocused = true;
            }
            else
            {
                Debug.Log("Click Another Object, other group");
            }
        }
    }

    private void FocusedEvent()
    {
        // Zoom with mouse wheel (if not too close)
        float scrollWheelAxis = Input.GetAxis("Mouse ScrollWheel");

        if (scrollWheelAxis != 0)
        {
            //Debug.Log("Mouse ScrollWheel " + Input.GetAxis("Mouse ScrollWheel") + " local position z " + transform.localPosition.z);
            transform.Translate(0, 0, Input.GetAxis("Mouse ScrollWheel") * zoomSpeed);
        }
        // Mouse right button, used to rotate camera around object.
        else if (Input.GetMouseButton(1))
        {
            // Move mouse
            float mouseXAxis = Input.GetAxis("Mouse X");
            float mouseYAxis = Input.GetAxis("Mouse Y");

            //Debug.Log("Mouse Right Button Down X Axis " + mouseXAxis + " Y Axis " + mouseYAxis);

            transform.Translate(-mouseXAxis, -mouseYAxis, 0);
            transform.LookAt(currentBodyCamRef.transform);
        }
    }
}
