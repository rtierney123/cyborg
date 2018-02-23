using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ElevatorController : MonoBehaviour
{
    public int nextLevel;

    private Rigidbody2D rb;
    private GameObject player;
    private Rigidbody2D playerRB;
    private bool rise;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rise = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rise)
        {
            rb.velocity = 5 * new Vector2(0, 1);
        }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log(coll.gameObject.tag);
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("PLayer going up");
            playerRB.gravityScale = 1;
            Physics2D.gravity = new Vector2(0, 0);
            StartCoroutine(goUpElevator());
        }
    }


    private IEnumerator goUpElevator()
    {
        startRise();
        yield return new WaitForSeconds(5);
        goToNextLevel();
    }



    private void startRise()
    {
        rise = true;
    }

    private void goToNextLevel()
    {
        SceneManager.LoadScene("Level" + nextLevel);
    }
}