using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour {
    void Start()
    {
        Invoke("GoToMainMenu", 5);
    }

    private void GoToMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }

}
