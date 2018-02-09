using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorClose : MonoBehaviour {
    public string doorString;

    private GameObject[] doors;

    void Awake()
    {
        doors = GameObject.FindGameObjectsWithTag(doorString);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
   
        if (col.gameObject.name == "Player")
        {
            foreach (GameObject door in doors)
                door.SetActive(true);
        } 
    }
}
