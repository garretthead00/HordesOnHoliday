using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {

	public static PlayerData data;

	public float score;
	public float XP;


	void Awake () {

		// using the singleton method to keep only one instance at all times
		if (data == null) {

						DontDestroyOnLoad (gameObject);
						data = this;
				} else if (data != null) {
						Destroy (gameObject);
				}
	
	}
	

}
