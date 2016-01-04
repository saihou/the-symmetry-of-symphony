using UnityEngine;
using System.Collections;

public class DiscTap : MonoBehaviour {

	GameObject original;
	int id;

	void OnMouseDown() {
		if (GameManager.instance.IsInPlay() && GameManager.instance.CanDestroy(id)) {
			GameManager.instance.KilledOne();

			DiscExplode explodeBlue = original.GetComponent<DiscExplode>();
			explodeBlue.ExplodeBlue();
			Destroy(original);

			DiscExplode explodeYellow = gameObject.GetComponent<DiscExplode>();
			explodeYellow.ExplodeYellow();
			Destroy(gameObject);

			GameManager.instance.DiscDestroyed();
		}
	}

	public void SetOriginalDisc(GameObject orig) {
		original = orig;
	}

	public void SetDiscId(int newId) {
		id = newId;
	}
}
