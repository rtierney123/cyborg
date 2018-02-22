using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour {

    public Dialog dialogue;

    private void Awake()
    {
        StartCoroutine(DelayConversaion());
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

        TriggerDialogue();
    }
}
