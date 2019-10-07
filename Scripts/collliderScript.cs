using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collliderScript : MonoBehaviour {

    PlacingFoundation placingFoundation;
    Vector3 sizeOfFoundation;

	// Use this for initialization
	void Start ()
    {
        placingFoundation = transform.parent.parent.GetComponent<PlacingFoundation>();
        sizeOfFoundation = transform.parent.parent.GetComponent<Collider>().bounds.size;	

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        //Platform snapping into position
        if(BuildingScript.isBuilding && other.tag == "Foundation" && placingFoundation.isPlaced && !other.GetComponent<PlacingFoundation>().isSnapped)
        {
            PlacingFoundation placingFoundation = other.GetComponent<PlacingFoundation>();
            placingFoundation.isSnapped = true;

            placingFoundation.MousePosX = Input.GetAxis("Mouse X");
            placingFoundation.MousePosY = Input.GetAxis("Mouse Y");

            float sizeX = sizeOfFoundation.x;
            float sizeZ = sizeOfFoundation.z;

            switch (this.transform.tag)
            {
                case "Westcollider":
                    other.transform.position = new Vector3(transform.parent.parent.position.x - sizeX, 2f , transform.parent.position.z);
                    break;
                case "Eastcollider":
                    other.transform.position = new Vector3(transform.parent.parent.position.x + sizeX, 2f, transform.parent.position.z);
                    break;
                case "Northcollider":
                    other.transform.position = new Vector3(transform.parent.parent.position.x, 2f, transform.parent.position.z + sizeZ);
                    break;
                case "Southcollider":
                    other.transform.position = new Vector3(transform.parent.parent.position.x, 2f, transform.parent.position.z - sizeZ);
                    break;
            }
        }
    }

}
