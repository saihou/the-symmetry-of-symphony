using UnityEngine;
using System.Collections;

public class DiscTap : MonoBehaviour {

	GameObject original;

	void OnMouseDown() {
		GameManager.instance.KilledOne();

		Destroy(original);
		Destroy(gameObject);
	}

	public void SetOriginalDisc(GameObject orig) {
		original = orig;
	}
}
