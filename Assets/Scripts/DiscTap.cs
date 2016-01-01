﻿using UnityEngine;
using System.Collections;

public class DiscTap : MonoBehaviour {

	GameObject original;

	void OnMouseDown() {
		if (GameManager.instance.IsInPlay()) {
			GameManager.instance.KilledOne();

			DiscExplode explode = original.GetComponent<DiscExplode>();
			explode.ExplodeBlue();

			Destroy(original);
			Destroy(gameObject);
		}
	}

	public void SetOriginalDisc(GameObject orig) {
		original = orig;
	}
}
