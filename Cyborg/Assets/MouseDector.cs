using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Mouse X") < 0)
        {
            //Code for action on mouse moving left
            //Debug.Log(Input.mousePosition.x);
        }
        if (Input.GetAxis("Mouse X") > 0)
        {
            //Code for action on mouse moving right
            //Debug.Log(Input.mousePosition.y);
        }
    }
}
