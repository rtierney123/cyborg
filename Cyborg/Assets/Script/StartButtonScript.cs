using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        //do your stuff when highlighted
    }
    public void OnSelect(BaseEventData eventData)
    {
        //do your stuff when selected
        SceneManager.LoadScene("Level1");
    }
}