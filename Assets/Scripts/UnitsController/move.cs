using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class move : MonoBehaviour
{
    public float speed;
    private Vector3 targetposition;
    private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(Input.mousePosition);
            setTarget();
        }
        if (isMoving)
        {
            Move();
        }
    }

    void setTarget()
    {
        targetposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetposition.z = transform.position.z;

        isMoving = true;
    }
    void Move()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetposition);
        transform.position = Vector3.MoveTowards(transform.position, targetposition, speed * Time.deltaTime);

        if (transform.position == targetposition)
        {
            isMoving = false;
        }
    }
}
