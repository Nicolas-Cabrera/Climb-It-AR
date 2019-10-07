using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlacingFoundation : BuildingScript {




    public bool isSnapped;
    public bool isPlaced;
    //public bool ItemWasPlaced = false;

    public bool isOnLevel1 = false;
    public bool isOnLevel2 = false;

    public float MousePosX;
    public float MousePosY;

    //public float heightOfPlatforms = 2f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(coolDownTimer);

        if (!isPlaced && !isSnapped)
        {
            isBuilding = true;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
                this.transform.position = new Vector3(hit.point.x, 2f, hit.point.z);
        }
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            //if (Input.GetMouseButtonUp(0))
            if(Input.GetMouseButtonUp(0) && coolDownTimer == 0)
            {
                isPlaced = true;
                isBuilding = false;
            }
        }

        if (isSnapped && !isPlaced && Mathf.Abs(MousePosX - Input.GetAxis("Mouse X")) > 0.2f || Mathf.Abs(MousePosY - Input.GetAxis("Mouse Y")) > 0.2f)
        {
            isSnapped = false;
        }

        //Debug.Log("The height of the platform is " + heightOfPlatforms);

    }   
}
