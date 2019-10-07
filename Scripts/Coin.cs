using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public float speed = 2f;

    //public GameObject CoinLevelOne, Coin2LevelOne;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(speed, 0, 0);
	}

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        //CoinLevelOne.SetActive(true);
        //Coin2LevelOne.SetActive(true);
    }
}
