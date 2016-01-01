using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	protected int lives = 3;

	void Awake () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (lives <= 0) {
			//Debug.Log ("Game Over!!!!");
		}
	}

	public void MissedOne() {
		lives--;
	}
}
