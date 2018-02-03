using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCount : MonoBehaviour {
    public int roomnum;
    public string doorString;

    private GameObject[] doors;
    private GameObject[] enemies;
    private float storeSpeed;
    private bool firstopen;

    void Awake()
    {
        doors=GameObject.FindGameObjectsWithTag(doorString);
        enemies = new GameObject[transform.childCount];
        for (int i=0; i<transform.childCount; i++)
        {
            enemies[i] = transform.GetChild(i).gameObject;
            storeSpeed = enemies[i].GetComponent<AIPath>().speed;
            enemies[i].GetComponent<AIPath>().speed = 0;
        }
        firstopen = true;
    }
	// Update is called once per frame
	void Update () {
        if (this.gameObject.transform.childCount==0)
        {
            if (firstopen)
            {
                foreach (GameObject door in doors)
                    door.active = false;
                firstopen = false;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<AIPath>().speed = storeSpeed;
            }
        }
    }
}
