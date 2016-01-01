using UnityEngine;
using System.Collections;

public class SpawnMechanism : MonoBehaviour {

	public GameObject disc;
	public GameObject discClone;
	
	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnDiscs());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator SpawnDiscs() {
		while (GameManager.instance.IsInPlay()) {
			yield return new WaitForSeconds(Random.Range (0.2f, 0.6f));
			SpawnDiscInRandomPos();
		}
	}

	GameObject SpawnDiscInRandomPos() {
		int rng = Random.Range(0,3);
		GameObject disc = (rng == 0) ? SpawnDiscInLeft() : (rng == 1) ? SpawnDiscInMid() : SpawnDiscInRight();
		return disc;
	}

	GameObject SpawnDiscInLeft() {
		GameObject a = GameObject.Instantiate(disc, SpawnPositions.instance.GetPos(DiscSpawnPoints.LEFT), Quaternion.identity) as GameObject;
		GameObject b = GameObject.Instantiate(discClone, SpawnPositions.instance.GetClonePos(DiscSpawnPoints.LEFT), Quaternion.identity) as GameObject;
		b.GetComponent<DiscTap>().SetOriginalDisc(a);
		b.GetComponent<Renderer>().enabled = GameManager.instance.GetCloneVisibility();
		return b;
	}

	GameObject SpawnDiscInMid() {
		GameObject a = GameObject.Instantiate(disc, SpawnPositions.instance.GetPos(DiscSpawnPoints.MID), Quaternion.identity) as GameObject;
		GameObject b =  GameObject.Instantiate(discClone, SpawnPositions.instance.GetClonePos(DiscSpawnPoints.MID), Quaternion.identity) as GameObject;
		b.GetComponent<DiscTap>().SetOriginalDisc(a);
		b.GetComponent<Renderer>().enabled = GameManager.instance.GetCloneVisibility();
		return b;
	}

	GameObject SpawnDiscInRight() {
		GameObject a = GameObject.Instantiate(disc, SpawnPositions.instance.GetPos(DiscSpawnPoints.RIGHT), Quaternion.identity) as GameObject;
		GameObject b =  GameObject.Instantiate(discClone, SpawnPositions.instance.GetClonePos(DiscSpawnPoints.RIGHT), Quaternion.identity) as GameObject;
		b.GetComponent<DiscTap>().SetOriginalDisc(a);
		b.GetComponent<Renderer>().enabled = GameManager.instance.GetCloneVisibility();
		return b;
	}
}
