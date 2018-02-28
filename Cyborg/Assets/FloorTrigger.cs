using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTrigger : MonoBehaviour {

    private FloorController parent;

    void Start()
    {
        parent = transform.parent.GetComponent<FloorController>();
    }

    void OnTriggerEnter2D(Collider2D aCol)
    {
       parent.OnChildTriggerEnter(aCol); 
    }
}
