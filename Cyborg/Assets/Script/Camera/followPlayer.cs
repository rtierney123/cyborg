using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {

    void Update()
    {
        if (GameObject.Find("Player") != null)
        {
            int DistanceAway = 10;
            Vector3 PlayerPOS = GameObject.Find("Player").transform.transform.position;
            GameObject.Find("Main Camera").transform.position = new Vector3(PlayerPOS.x, PlayerPOS.y, PlayerPOS.z - DistanceAway);
        }
    }
}
