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
			print ("Game Over!!!!");
		}
	}

	public void MissedOne() {
		lives--;
	}
}
