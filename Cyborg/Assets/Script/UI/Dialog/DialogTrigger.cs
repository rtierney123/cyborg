using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DialogTrigger : MonoBehaviour {

    private enum TRIGGER_TYPE
    {
        IMMEDIATE,
        ON_PLAYER_ENTER
    };


    //All DialogTriggers
    [SerializeField]
    private TRIGGER_TYPE triggerType = TRIGGER_TYPE.IMMEDIATE;
    public Dialog dialogue;

    //Only for ON_PLAYER_ENTER DialogTriggers
    Collider2D dialogCollider;
    [SerializeField]
    GameObject dialogUI;


    private void Awake()
    {
        StartCoroutine(DelayConversaion());
    }

    private void Start()
    {
        if (triggerType == TRIGGER_TYPE.ON_PLAYER_ENTER)
        {
            dialogCollider = this.gameObject.GetComponent<BoxCollider2D>();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogManager>().StartDialogue(dialogue);
    }

    public void NextSentence()
    {
        FindObjectOfType<DialogManager>().DisplayNextSentence();
    }

 
    IEnumerator DelayConversaion()
    {
       
         yield return 5;

        if (triggerType == TRIGGER_TYPE.IMMEDIATE)
        {
            TriggerDialogue();
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (triggerType == TRIGGER_TYPE.ON_PLAYER_ENTER)
        {
            if (coll.gameObject.tag == "Player")
            {
                if (!dialogUI.activeSelf)
                {
                    dialogUI.SetActive(true);
                }
                Debug.Log("Player Entered dialog zone.");
                dialogCollider.enabled = false;

                TriggerDialogue();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (triggerType == TRIGGER_TYPE.ON_PLAYER_ENTER)
        {
            if (coll.gameObject.tag == "Player")
            {
                if (!dialogUI.activeSelf)
                {
                    dialogUI.SetActive(true);
                }
                Debug.Log("Player Entered dialog zone.");
                dialogCollider.enabled = false;

                TriggerDialogue();
            }
        }
    }
}
