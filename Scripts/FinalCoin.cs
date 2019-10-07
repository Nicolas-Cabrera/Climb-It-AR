using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCoin : MonoBehaviour
{

    public float speed = 2f;
    public GameObject pauseButton, BuiltButton, Gameover;

    //public GameObject CoinLevelOne, Coin2LevelOne;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speed, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        pauseButton.SetActive(false);
        BuiltButton.SetActive(false);
        Gameover.SetActive(true);

    }
}
