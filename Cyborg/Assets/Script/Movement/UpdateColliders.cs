using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateColliders : MonoBehaviour {
    [HideInInspector]
    public GameObject tpCol;
    [HideInInspector]
    public GameObject bmCol;
    [HideInInspector]
    public GameObject rtCol;
    [HideInInspector]
    public GameObject ltCol;
    

    private void Start()
    {
        tpCol = this.transform.Find("tpCol").gameObject;
        bmCol = this.transform.Find("bmCol").gameObject;
        rtCol = this.transform.Find("rtCol").gameObject;
        ltCol = this.transform.Find("ltCol").gameObject;
        
    }
    
           
}
