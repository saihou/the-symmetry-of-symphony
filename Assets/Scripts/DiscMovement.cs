using UnityEngine;
using System.Collections;

public class DiscMovement : MonoBehaviour {

	public float speed = 0.05f;
	float defaultSpeed = 0.05f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.y < 0) {
			GameManager.instance.MissedOne();
			Destroy(gameObject);
		}
		gameObject.transform.position = gameObject.transform.position + speed*Vector3.down;
	}

	// Between 0.05f to 0.25f
	public void SetSpeed(float newSpeed) {
		if (newSpeed < 0.05f) newSpeed = 0.05f;
		if (newSpeed > 0.25f) newSpeed = 0.25f;
		speed = newSpeed;
	}

	public void ResetSpeed() {
		speed = defaultSpeed;
	}
}
