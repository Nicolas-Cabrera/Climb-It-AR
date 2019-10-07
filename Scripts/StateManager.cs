using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Vuforia;

public enum GameState
{
    SCAN, GAMEPLAY, PROPRENDERING, RESET, PAUSE, UNPAUSE, ONBUILT
}

public class StateManager : MonoBehaviour
{

    //Private members of the smart terrain

    

    private GUIStyle m_buttonDone;
    private static StateManager s_StateManager;
    private GameState m_states;
    //private Pause m_paused;
    private ReconstructionBehaviour m_reconstructionBehaviour;
    private DefaultSmartTerrainEventHandler m_smartTerrainEventHandler;

    //Building button 
    public int counter = 0;

    //buttons 

    public GameObject pauseButton, pausePanel, mainCharacter, doneButton, BuiltButton, BackToGameplay, World, Coins, Stairs, timerCountDown;

    //public GameObject[] worldObjects;
    //public RenderingWorld creatingWorld;

    //Accessing building mode script
    //public BaseBuilder baseBuilding;

    void Start()
    {
        m_reconstructionBehaviour = FindObjectOfType(typeof(ReconstructionBehaviour)) as ReconstructionBehaviour;
        m_smartTerrainEventHandler = GameObject.FindObjectOfType(typeof(DefaultSmartTerrainEventHandler)) as DefaultSmartTerrainEventHandler;
        //m_renderingWorld

        Debug.Log(m_states);
    }

    void ActionOnStates()
    {

        switch (m_states)
        {
            case GameState.SCAN:
                Debug.Log("Scanning");
                
                break;


            case GameState.GAMEPLAY:
                //Debug.Log("Gameplay");
                
                mainCharacter.SetActive(true);
                pauseButton.SetActive(true);
                BuiltButton.SetActive(true);
                doneButton.SetActive(false);
                BuiltButton.SetActive(true);
                BackToGameplay.SetActive(false);
                World.SetActive(true);
                Coins.SetActive(true);
                Stairs.SetActive(true);
                timerCountDown.SetActive(false);

                if ((m_reconstructionBehaviour != null) && (m_reconstructionBehaviour.Reconstruction != null))
                {
                    m_reconstructionBehaviour.Reconstruction.Stop();
                }

                break;


                case GameState.PROPRENDERING:
                    Debug.Log("Render Models");
                    // rendering models
                break;


                case GameState.RESET:

                SceneManager.LoadScene("CimbItAR");

                Time.timeScale = 1;
                Debug.Log("Go back to starting page");

                break;

                case GameState.ONBUILT:

                pauseButton.SetActive(false);
                BackToGameplay.SetActive(true);
                BuiltButton.SetActive(false);
                timerCountDown.SetActive(true);

                Debug.Log("You can now build");
                //baseBuilding.onBuilding();

                break;


                case GameState.PAUSE:

                    Debug.Log("Pause");
                pausePanel.SetActive(true);
                pauseButton.SetActive(false);
                BuiltButton.SetActive(false);
                BackToGameplay.SetActive(false);

                Time.timeScale = 0;

                break;

            case GameState.UNPAUSE:
                    Debug.Log("Un Pause");

                pausePanel.SetActive(false);
                pauseButton.SetActive(true);
                Time.timeScale = 1;
                m_states = GameState.GAMEPLAY;

                break;
        }
    }

    //Methods for Buttons

    public void onPause()
    {
        m_states = GameState.PAUSE;
    }

    public void UnPause()
    {
        m_states = GameState.UNPAUSE;
    }

    public void recreatingWorld()
    {
        m_states = GameState.RESET;
    }
    
    public void DoneStartPlaying()
    {
        m_states = GameState.GAMEPLAY;
    }

    public void onStartBuilding()
    {
        m_states = GameState.ONBUILT;
    }
    
    private void Update()
    {
        ActionOnStates();
    }
}
