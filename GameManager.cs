using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		// If player is dead then end the battle
		if (Player.health <= 0) {
			Application.LoadLevel("PlayerMenu");
		}

	}
}
