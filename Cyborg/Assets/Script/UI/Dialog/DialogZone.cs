using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogZone : MonoBehaviour
{

    Collider2D dialogCollider;
    DialogTrigger dialogTrigger;
    [SerializeField]
    GameObject dialogUI;

    public void Start()
    {
        dialogCollider = this.gameObject.GetComponent<BoxCollider2D>();
        dialogTrigger = this.gameObject.GetComponent<DialogTrigger>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (!dialogUI.activeSelf)
            {
                dialogUI.SetActive(true);
            }
            Debug.Log("Player Entered");
            dialogCollider.enabled = false;

            dialogTrigger.TriggerDialogue();
        }
    }
}