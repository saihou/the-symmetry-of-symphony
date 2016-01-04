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

	SpawnMechanism spawnBoss;

	bool inPlay = true;
	bool clonesVisible = true;
	float clonesVisibleFor = 7.0f; //visible for first 7 seconds


	int currentId = 0;
	int latestId = 0;

	void Awake () {
		instance = this;
	}

	void Start() {
		lifeText.text = lives.ToString();
		scoreText.text = score.ToString();
		spawnBoss = GetComponent<SpawnMechanism>();
		Invoke ("FadeAllDiscClones", clonesVisibleFor);
	}
	
	// Update is called once per frame
	void Update () {
		if (!inPlay) {
			if (Application.platform == RuntimePlatform.Android && Input.GetKey(KeyCode.Escape))
			{
				Application.LoadLevel(0);
			}
			return;
		}

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

		if (score < 50) {
			//default starting values
			spawnBoss.SetMinDelay(0.6f);
			spawnBoss.SetMaxDelay(0.8f);
		} else if (score < 100) {
			spawnBoss.SetMinDelay(0.5f);
		} else if (score < 200) {
			spawnBoss.SetMinDelay(0.35f);
			spawnBoss.SetMaxDelay(0.6f);
		} else if (score < 300) {
			spawnBoss.SetMinDelay(0.2f);
			spawnBoss.SetMaxDelay(0.4f);
		} else {
			spawnBoss.SetMaxDelay(0.3f);
		}
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

	/*public bool CanDestroy(int discId) {
		if (currentId == discId) {
			return true;
		} else if (currentId < discId && justLostLife) {
			currentId = discId;
			return true;
		} else {
			return false;
		}
	}*/

	public void DiscDestroyed() {
		currentId++;
	}

	public int GetDiscId() {
		return latestId++;
	}

	/*void ResetJustLostLife() {
		if (justLostLife) {
			justLostLife = false;
		}
	}*/
}
