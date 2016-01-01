using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public Text lifeText;
	public Text scoreText;

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
			//Debug.Log ("Game Over!!!!");
		}
	}

	public void MissedOne() {
		lives--;		
		lifeText.text = "Lives left: " + lives;
	}

	public void KilledOne() {
		score = score + 2;
		scoreText.text = score.ToString();
	}
}
