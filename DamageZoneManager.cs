using UnityEngine;
using System.Collections;

public class DamageZoneManager : MonoBehaviour {


	void OnTriggerEnter(Collider c) {
		
		if (c.gameObject.tag == "Enemy") {
			Player.health-=1;
			
		}
	}

}
