using UnityEngine;
using System.Collections;

public class DestroyAfterXSeconds : MonoBehaviour {
	public float delay = 1.1f;

	// Use this for initialization
	void Start () {
		Invoke ("SelfDestruct", delay);
	}
	void SelfDestruct() {
		Destroy(gameObject);
	}
}
