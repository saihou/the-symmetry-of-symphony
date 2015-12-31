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
		gameObject.transform.position = gameObject.transform.position + speed*Vector3.down;
	}

	public void SetSpeed(float newSpeed) {
		speed = newSpeed;
	}

	public void ResetSpeed() {
		speed = defaultSpeed;
	}
}
