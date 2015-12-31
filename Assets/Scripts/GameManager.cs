using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject disc;

	// Use this for initialization
	void Start () {
		GameObject d = GameObject.Instantiate(disc);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
