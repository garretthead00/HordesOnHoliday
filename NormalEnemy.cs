using UnityEngine;
using System.Collections;

public class NormalEnemy : Enemy {

	public GameObject enemy;
	
	void Update() {
		
		if (!GetComponent<Animation>().IsPlaying ("creep up") && !GetComponent<Animation>().IsPlaying ("death03") ) {
			GetComponent<Animation>().Play ("walk03");
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}
		
		
		
	}
}
