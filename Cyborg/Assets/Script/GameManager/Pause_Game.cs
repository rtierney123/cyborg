using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Game : MonoBehaviour
{

    private bool pauseButton;
    private bool dialogPause;
    public GameObject pauseMenu;

    private void Start()
    {
        pauseButton = false;
        dialogPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Adjusts the status of the pause button
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (pauseButton) {
                pauseMenu.SetActive(false);
            }
            else {
                pauseMenu.SetActive(true);
            }
            PauseButton = !PauseButton;
            
        }

        //Time will come to a stop if the game has not been manually paused, AND the game has not been force paused by dialogue.
        if (MasterPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    //This will return that the game is paused either if the player has manually paused the game, 
    // or if it has been force-paused by dialog pop-ups.
    public bool MasterPause
    {
        get
        {
            if (PauseButton || DialogPause)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public bool PauseButton
    {
        get
        {
            return pauseButton;
        }
        set
        {
            pauseButton = value;
        }
    }

    public bool DialogPause
    {
        get
        {
            return dialogPause;
        }
        set
        {
            dialogPause = value;
        }
    }
}
       
        