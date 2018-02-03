using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart_Level : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("r"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

    }
}
