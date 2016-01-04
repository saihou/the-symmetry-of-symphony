using UnityEngine;
using System.Collections;

public class DiscMovement : MonoBehaviour {

	float speed = 0.03f;
	float defaultSpeed = 0.03f;
	
	// Update is called once per frame
	void Update () {
		//reached the bottom
		if (gameObject.transform.position.y < 0) {
			GameManager.instance.MissedOne();
			Handheld.Vibrate();
			DiscExplode explode = GetComponent<DiscExplode>();
			if (explode != null) {
				explode.ExplodeRed();
			}
			Destroy(gameObject);
			GameManager.instance.DiscDestroyed();
		}
		gameObject.transform.position = gameObject.transform.position + speed*Vector3.down;
	}

	// Between 0.025f to 0.25f
	public void SetSpeed(float newSpeed) {
		if (newSpeed < 0.03f) newSpeed = 0.03f;
		if (newSpeed > 0.25f) newSpeed = 0.25f;
		speed = newSpeed;
	}

	public void ResetSpeed() {
		speed = defaultSpeed;
	}
}
