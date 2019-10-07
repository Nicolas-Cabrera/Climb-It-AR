using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BuildingScript : MonoBehaviour {

    //for items to carry on spawing while on buiding mode
    public bool PlayerisOnBuildingMode = false;

    //cool down for building
    public int coolDown = 10;
    public float coolDownTimer;
    public Text coolDownText;

    //PlacingFoundation placingFoundation;
    public static bool isBuilding;

    public GameObject Platform;

    void Start()
    {
        //placingFoundation = transform.parent.parent.GetComponent<PlacingFoundation>();
    }

    void Update()
    {
        //cool down
        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
            coolDownText.text = "cool down time is " + coolDownTimer;
        }

        if (coolDownTimer < 0)
        {
            coolDownTimer = 0;
            coolDownText.text = "You can now build";

        }

        

        // = "cool down time is " + coolDownTimer;
        Debug.Log("cool down time is " + coolDownTimer);

        

        //if (Input.GetKeyDown("space") && !isBuilding)
        if(PlayerisOnBuildingMode && Input.GetMouseButtonDown(0) && !isBuilding && coolDownTimer == 0)
        {
            coolDownTimer = coolDown;
            isBuilding = true;
            Instantiate(Platform, Vector3.zero, Platform.transform.rotation);
        }

    }

       public void onBuildingMode()
    {
        PlayerisOnBuildingMode = true;
    }

    public void onLeaveBuildingMode()
    {
        PlayerisOnBuildingMode = false;
    }
}
