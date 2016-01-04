using UnityEngine;
using System.Collections;

public class SpawnMechanism : MonoBehaviour {

	public GameObject disc;
	public GameObject discClone;

	float minDelay = 0.6f;
	float maxDelay = 0.8f;
	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnDiscs());
	}
	
	IEnumerator SpawnDiscs() {
		while (GameManager.instance.IsInPlay()) {
			yield return new WaitForSeconds(Random.Range (minDelay, maxDelay));
			SpawnDiscInRandomPos();
		}
	}

	GameObject SpawnDiscInRandomPos() {
		int rng = Random.Range(0,3);
		// the disc that is returned is the clone (tappable discs on right)
		GameObject disc = (rng == 0) ? SpawnDiscInLeft() : (rng == 1) ? SpawnDiscInMid() : SpawnDiscInRight();
		disc.GetComponent<Renderer>().enabled = GameManager.instance.GetCloneVisibility();
		disc.GetComponent<DiscTap>().SetDiscId(GameManager.instance.GetDiscId());
		return disc;
	}

	GameObject SpawnDiscInLeft() {
		GameObject a = GameObject.Instantiate(disc, SpawnPositions.instance.GetPos(DiscSpawnPoints.LEFT), Quaternion.identity) as GameObject;
		GameObject b = GameObject.Instantiate(discClone, SpawnPositions.instance.GetClonePos(DiscSpawnPoints.LEFT), Quaternion.identity) as GameObject;
		b.GetComponent<DiscTap>().SetOriginalDisc(a);
		return b;
	}

	GameObject SpawnDiscInMid() {
		GameObject a = GameObject.Instantiate(disc, SpawnPositions.instance.GetPos(DiscSpawnPoints.MID), Quaternion.identity) as GameObject;
		GameObject b =  GameObject.Instantiate(discClone, SpawnPositions.instance.GetClonePos(DiscSpawnPoints.MID), Quaternion.identity) as GameObject;
		b.GetComponent<DiscTap>().SetOriginalDisc(a);
		return b;
	}

	GameObject SpawnDiscInRight() {
		GameObject a = GameObject.Instantiate(disc, SpawnPositions.instance.GetPos(DiscSpawnPoints.RIGHT), Quaternion.identity) as GameObject;
		GameObject b =  GameObject.Instantiate(discClone, SpawnPositions.instance.GetClonePos(DiscSpawnPoints.RIGHT), Quaternion.identity) as GameObject;
		b.GetComponent<DiscTap>().SetOriginalDisc(a);
		return b;
	}

	void SetDiscSpeed(GameObject disc, float speed) {
		disc.GetComponent<DiscMovement>().SetSpeed(speed);
	}

	public void SetMinDelay(float d) {
		minDelay = d;
	}

	public void SetMaxDelay(float d) {
		maxDelay = d;
	}
}
