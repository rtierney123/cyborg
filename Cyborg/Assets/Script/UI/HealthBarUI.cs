using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUI : MonoBehaviour {

	// Use this for initialization
	public int startingLives = 3;
	private int lives = 0;
	private float UIwidth;
	public GameObject LifeUI;
	void Start () {
		UIwidth = LifeUI.GetComponent<RectTransform>().rect.width;
		for (int i = 0; i < startingLives; i++){
			AddLife();
		}
	}

	public void AddLife() {
		Vector2 UIpos = new Vector2((UIwidth * lives) + (lives + 1)*20, 20);

		GameObject newLife = Instantiate(LifeUI);
		newLife.transform.SetParent(transform);
		newLife.transform.SetAsLastSibling();
		newLife.GetComponent<RectTransform>().anchoredPosition = UIpos;
		newLife.GetComponent<RectTransform>().localScale = new Vector2(1,1);

		lives++;
	}

	public void RemoveLife() {
		Destroy(transform.GetChild(transform.childCount - 1).gameObject);
		lives--;
	}
}
