using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class StartButtonScript : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
    private bool withinRange;
    private DialogTrigger trigger;
    private void Start()
    {
        withinRange = true;
        trigger = GetComponent<DialogTrigger>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        trigger.NextSentence();
    }
    public void OnSelect(BaseEventData eventData)
    {
        //do your stuff when selected
        //SceneManager.LoadScene("Level1");
        trigger.NextSentence();

        StartCoroutine(DelayNextLevel());
    }

    void FixedUpdate()
    {
        if (((Input.mousePosition.x)<700 || (Input.mousePosition.x) > 300) && (((Input.mousePosition.y) < 200 || (Input.mousePosition.y) > 100)))
        {
            if (withinRange)
            {
                withinRange = false;
                trigger.NextSentence();
            }
        }
    }

    IEnumerator DelayNextLevel()
    {

        yield return 5;

        GoToLevel1();
    }

    void GoToLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
}