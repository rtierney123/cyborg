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
            GameObject rightmostHealth = healthBar.transform.GetChild(healthBar.transform.childCount - 1).gameObject;
            Vector2 place = rightmostHealth.transform.position;
            place.x = place.x + 1;
            Instantiate(healthHead, place, Quaternion.identity).transform.parent = healthBar.transform;
            Destroy(this.gameObject);
        }
    }
}
