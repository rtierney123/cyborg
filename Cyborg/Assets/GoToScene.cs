
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour {
    //button to trigger start level
    public Button button;
    //string of scene to start
    public string level;

	// Use this for initialization
	void Start () {
        button.onClick.AddListener(TaskOnClick);
    }
	

    void TaskOnClick()
    {
        if (level == null)
        {
            Debug.Log("Need to add scene name");
        }
      
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }
}
