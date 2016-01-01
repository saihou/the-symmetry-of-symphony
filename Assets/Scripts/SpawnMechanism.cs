using UnityEngine;
using System.Collections;

public class SpawnMechanism : MonoBehaviour {

	public GameObject disc;
	
	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnDiscs());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator SpawnDiscs() {
		while (true) {
			yield return new WaitForSeconds(Random.Range (0.2f, 0.6f));
			SpawnDiscInRandomPos();
		}
	}

	void SpawnDiscInRandomPos() {
		int rng = Random.Range(0,3);
		GameObject disc = (rng == 0) ? SpawnDiscInLeft() : (rng == 1) ? SpawnDiscInMid() : SpawnDiscInRight();
	}

	GameObject SpawnDiscInLeft() {
		return GameObject.Instantiate(disc, SpawnPositions.instance.GetPos(DiscSpawnPoints.LEFT), Quaternion.identity) as GameObject;
	}

	GameObject SpawnDiscInMid() {
		return GameObject.Instantiate(disc, SpawnPositions.instance.GetPos(DiscSpawnPoints.MID), Quaternion.identity) as GameObject;
	}

	GameObject SpawnDiscInRight() {
		return GameObject.Instantiate(disc, SpawnPositions.instance.GetPos(DiscSpawnPoints.RIGHT), Quaternion.identity) as GameObject;
	}
}
