using UnityEngine;
using System.Collections;

public class SlowlyFadeAway : MonoBehaviour {
	GameObject[] allDiscClones = null;
	float alpha = 0.0f;
	bool stop = false;
	float duration = 7.0f;

	public void SlowlyFadeAllDiscClones() {
		allDiscClones = GameObject.FindGameObjectsWithTag("DiscClone");
		Invoke ("StopFading", duration);
	}

	void Update() {
		if (allDiscClones != null) {
			allDiscClones = GameObject.FindGameObjectsWithTag("DiscClone");
			foreach (GameObject clone in allDiscClones) {
				if (clone != null) {
					LerpAlpha(clone);
				}
			}
		}
	}

	void LerpAlpha(GameObject g) {
		float lerp = Mathf.PingPong(Time.time, 1.0f);

		alpha = Mathf.Lerp (0.0f, 1.0f, lerp);

		Renderer renderer = g.GetComponentInChildren<Renderer>();
		Color color = renderer.material.color;
		color.a = alpha;
		renderer.material.color = color;

		if (alpha < 0.1 && stop) {
			color.a = 0.0f;
			renderer.material.color = color;

			GameManager.instance.SetCloneVisibility(false);
			Destroy (this);
		}
	}

	void StopFading() {
		stop = true;
	}
}
