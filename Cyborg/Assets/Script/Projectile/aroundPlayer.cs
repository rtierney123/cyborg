using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aroundPlayer : MonoBehaviour {
    public Vector3 position;
    public GameObject player;
    private Vector3 playerPosition;

    void Start()
    {
        playerPosition = player.transform.position;
    }
	
    void Update()
    {
        playerPosition = player.transform.position;
        transform.position = position+ playerPosition;
    }
}
