using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPickup : MonoBehaviour {
    private GameObject healthBar;
    public GameObject healthHead;
    void Start()
    {
        healthBar = GameObject.Find("HealthBar");
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.name == "Player")
        {
            healthBar.GetComponent<HealthBarUI>().AddLife();
            Destroy(gameObject);
        }
    }
}
