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

	bool inPlay = true;
	bool clonesVisible = true;
	float clonesVisibleFor = 7.0f; //visible for first 7 seconds

	void Awake () {
		instance = this;
	}

	void Start() {
		lifeText.text = lives.ToString();
		scoreText.text = score.ToString();
		Invoke ("FadeAllDiscClones", clonesVisibleFor);
	}
	
	// Update is called once per frame
	void Update () {
		if (!inPlay) return;

		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began && touch.position.x < Screen.width/2) {
				DisplayInfoBox("Play only on the right side!");
			}
		}
	}

	public void MissedOne() {
		lives--;
		if (lives <= 0) {
			GameOver();
			lives = 0;
		}

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
		inPlay = false;

		infoBox.gameObject.SetActive(true);
		Text infoBoxText = infoBox.GetComponentInChildren<Text>();
		infoBoxText.text = "GAME OVER";

		//set all child to active
		foreach (Transform t in infoBox.gameObject.transform) {
			t.gameObject.SetActive(true);
		}
	}

	public void Restart() {
		Application.LoadLevel(0);
	}

	public void Quit() {
		Application.Quit();
	}

	void FadeAllDiscClones() {
		SlowlyFadeAway fadeScript = GetComponent<SlowlyFadeAway>();
		fadeScript.SlowlyFadeAllDiscClones();
	}

	public bool GetCloneVisibility() {
		return clonesVisible;
	}

	public void SetCloneVisibility(bool v) {
		clonesVisible = v;
	}

	public bool IsInPlay() {
		return inPlay;
	}
}
