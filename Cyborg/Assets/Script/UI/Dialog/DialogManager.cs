using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {
    public Text nameText;
    public Text dialogText;
    public Image dialogBackgroundImage;
    public Image dialogHeadImage;
    public Button dialogNextButton;

    private Pause_Game pause;

    public Queue<string> sentences;
	// Use this for initialization
	void Awake ()
    {
        sentences = new Queue<string>();
    }

    private void Start()
    {
        pause = FindObjectOfType<Pause_Game>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue (Dialog dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.name);

        pause.DialogPause = true;
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
           sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        ToggleAllDialogUI(true);


        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogText.text = sentence;
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation.");

        pause.DialogPause = false;
        ToggleAllDialogUI(false);
    }

    void ToggleAllDialogUI(bool status)
    {
        if (nameText != null) nameText.gameObject.SetActive(status);
        if (dialogText != null) dialogText.gameObject.SetActive(status);
        if (dialogBackgroundImage != null) dialogBackgroundImage.gameObject.SetActive(status);
        if (dialogHeadImage != null) dialogHeadImage.gameObject.SetActive(status);
        if (dialogNextButton != null) dialogNextButton.gameObject.SetActive(status);
    }
}
