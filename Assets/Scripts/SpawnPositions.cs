using UnityEngine;
using System.Collections;

public class SpawnPositions : MonoBehaviour {

	public static SpawnPositions instance;
	Vector3 left = new Vector3 (-8.0f, 10.0f, 0.0f);
	Vector3 mid = new Vector3 (-5.0f, 10.0f, 0.0f);
	Vector3 right = new Vector3 (-2.0f, 10.0f, 0.0f);

	void Awake() {
		instance = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Vector3 GetPos(DiscSpawnPoints dsp) {
		switch (dsp) {
			case DiscSpawnPoints.LEFT: return left;
			case DiscSpawnPoints.MID: return mid;
			case DiscSpawnPoints.RIGHT: return right;
		}
		return Vector3.zero;
	}
}

public enum DiscSpawnPoints { LEFT, MID, RIGHT };
