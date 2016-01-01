using UnityEngine;
using System.Collections;

public class DestroyAfterXSeconds : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("SelfDestruct", 1.1f);
	}
	void SelfDestruct() {
		Destroy(gameObject);
	}
}
