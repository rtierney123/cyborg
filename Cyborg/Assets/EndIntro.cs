using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndIntro : MonoBehaviour {
    public DialogManager dialog;
    private bool allowCheck = false;
    private bool startNextLevel = true;
    private void Update()
    {
        if (!allowCheck)
        {
            if (dialog.sentences.Count != 0)
            {
                allowCheck = true;
            }
        } else
        {
            if (dialog.sentences.Count == 0)
            {
                if (startNextLevel)
                {
                    Invoke("StartGame", 1);
                }
                startNextLevel = false;
            }
        }
    
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

}
