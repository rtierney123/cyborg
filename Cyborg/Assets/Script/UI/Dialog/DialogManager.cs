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
    public Queue<GameObject> speakers;

    private SpeakerInfo speakerInfo;
    // Use this for initialization
    private int count;
	void Awake ()
    {
        sentences = new Queue<string>();
        speakers = new Queue<GameObject>();

    }

    private void Start()
    {
        pause = FindObjectOfType<Pause_Game>();
        if (pause == null)
        {
            Debug.Log("Cannot find pause gameobject");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            DisplayNextSentence();
        }
        if (Input.GetKeyDown("x"))
        {
            EndDialogue();
        }
    }

    public void StartDialogue (Dialog dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.name);
        pause.DialogPause = true;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (GameObject speaker in dialogue.speakers)
        {
            speakers.Enqueue(speaker);
        }

        
        //nameText.text = dialogue.name;
        

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

        speakerInfo = speakers.Dequeue().GetComponent<SpeakerInfo>();
        dialogHeadImage.sprite = speakerInfo.dialogHead.sprite;
        nameText.text = speakerInfo.speakerName.text;
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
