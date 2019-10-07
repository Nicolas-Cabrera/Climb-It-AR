using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ifPlayerFalls : MonoBehaviour {

    public GameObject pauseButton, BuiltButton, Gameover;


    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        pauseButton.SetActive(false);
        BuiltButton.SetActive(false);
        Gameover.SetActive(true);

    }
}
