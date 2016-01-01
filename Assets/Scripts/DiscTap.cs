using UnityEngine;
using System.Collections;

public class DiscTap : MonoBehaviour {

	GameObject original;

	void OnMouseDown() {
		if (GameManager.instance.IsInPlay()) {
			GameManager.instance.KilledOne();

			DiscExplode explodeBlue = original.GetComponent<DiscExplode>();
			explodeBlue.ExplodeBlue();
			Destroy(original);

			DiscExplode explodeYellow = gameObject.GetComponent<DiscExplode>();
			explodeYellow.ExplodeYellow();
			Destroy(gameObject);
		}
	}

	public void SetOriginalDisc(GameObject orig) {
		original = orig;
	}
}
