using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_R1_L1 : MonoBehaviour {
    public GameObject tech_basicEnemy;
    public void Start()
    {
        Instantiate(tech_basicEnemy, new Vector3(10, 15, 0f), Quaternion.identity);
        Instantiate(tech_basicEnemy, new Vector3(15, 15, 0f), Quaternion.identity);
        Instantiate(tech_basicEnemy, new Vector3(25, 5, 0f), Quaternion.identity);
    }
}
