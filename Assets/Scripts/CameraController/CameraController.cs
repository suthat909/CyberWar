using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panTime= 0.7f;
    public float panSpeed = 0.1f;
    public float panBorderThickness = 0.6f;
    public Vector3 newPosition;
    void Start()
    {
        newPosition = transform.position;
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            newPosition += (transform.up * panSpeed);
        }

        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness)
       {
            newPosition += (transform.up * -panSpeed);
        }

        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness) 
        {
            newPosition += (transform.right * panSpeed);
        }

        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness)
        {
            newPosition += (transform.right * -panSpeed);
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * panTime);
    }

}
