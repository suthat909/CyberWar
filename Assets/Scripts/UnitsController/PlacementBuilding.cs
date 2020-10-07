using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementBuilding : MonoBehaviour
{
    private bool isObjSelected = false;

    private GameObject currentlySectedObj;

    private Camera cam;

    [SerializeField]
    private GameObject selectableObj;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Building();
    }

    public void Building()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 spawPos = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));

        if (isObjSelected == false)
        {
            currentlySectedObj = (GameObject)Instantiate(selectableObj,spawPos, Quaternion.identity);
            isObjSelected = true;
        }

        if(Input.GetMouseButtonDown(1) && isObjSelected == true)
        {
            Destroy(currentlySectedObj);
            isObjSelected = false;
        }
    }
}
