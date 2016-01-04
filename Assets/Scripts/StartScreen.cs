using UnityEngine;
using System.Collections;

public class StartScreen : MonoBehaviour {

	public void OnBtnClickEasy() {
		DiscMovement.speed = 0.03f;
		Application.LoadLevel(1);
	}
	
	public void OnBtnClickMedium() {
		DiscMovement.speed = 0.1f;
		Application.LoadLevel(1);
	}
	
	public void OnBtnClickHard() {
		DiscMovement.speed = 0.2f;		
		Application.LoadLevel(1);
	}
}
