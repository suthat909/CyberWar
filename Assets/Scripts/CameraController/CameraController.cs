using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    public float panTime= 0.7f;
    public float panSpeed = 0.1f;
    public float panBorderThickness = 0.6f;
    
    public Vector3 newPosition;
    private Vector3 dragOrigin;

    void Start()
    {
        newPosition = transform.position;
    }



    // Update is called once per frame
    void Update()
    {
        PanCamera();
    }

    void PanCamera()
    {
        if (Input.GetMouseButtonDown(1))
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
            cam.transform.position += difference;
            transform.position += difference;
        }

        if (Input.mousePosition.y >= Screen.height - panBorderThickness && !Input.GetMouseButton(1))
        {
            newPosition += (transform.up * panSpeed);
        }

        if (Input.mousePosition.y <= panBorderThickness && !Input.GetMouseButton(1))
        {
            newPosition += (transform.up * -panSpeed);
        }

        if (Input.mousePosition.x >= Screen.width - panBorderThickness && !Input.GetMouseButton(1))
        {
            newPosition += (transform.right * panSpeed);
        }

        if (Input.mousePosition.x <= panBorderThickness && !Input.GetMouseButton(1))
        {
            newPosition += (transform.right * -panSpeed);
        }

        if (!Input.GetMouseButton(1))
        {
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * panTime);
        }
    }

}
