using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public Text lifeText;
	public Text scoreText;
	public Image fadeWhenHit;
	public RectTransform infoBox; 

	protected int lives = 10;
	protected int score = 0;

	void Awake () {
		instance = this;
	}

	void Start() {
		lifeText.text = lives.ToString();
		scoreText.text = score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (lives <= 0) {
			Debug.Log ("Game Over!!!!");
		}
	}

	public void MissedOne() {
		lives--;		
		lifeText.text = lives.ToString();
		StartCoroutine(FlashGameObject(fadeWhenHit.gameObject, 0.05f));
	}

	public void KilledOne() {
		score = score + 2;
		scoreText.text = score.ToString();
	}

	IEnumerator FlashGameObject(GameObject go, float duration) {
		go.SetActive(true);
		yield return new WaitForSeconds(duration);
		go.SetActive(false);
	}

	public void DisplayInfoBox(string text) {
		StartCoroutine(FlashGameObject(infoBox.gameObject, 1.0f));
		Text infoBoxText = infoBox.GetComponentInChildren<Text>();
		infoBoxText.text = text;
	}

	void GameOver() {
		Text infoBoxText = infoBox.GetComponentInChildren<Text>();
		infoBoxText.text = "GAME OVER";
	}
}
