using UnityEngine;
using System.Collections;

public class DiscExplode : MonoBehaviour {
	public GameObject explosionBluePrefab;
	public GameObject explosionRedPrefab;

	public void ExplodeBlue() {
		GameObject.Instantiate(explosionBluePrefab, gameObject.transform.position, gameObject.transform.rotation);
	}

	public void ExplodeRed() {
		GameObject.Instantiate(explosionRedPrefab, gameObject.transform.position, gameObject.transform.rotation);
	}
}
