using UnityEngine;
using System.Collections;

public class ArmoredEnemy : Enemy {

	public GameObject armoredEnemy;



	// ArmoredBoar constructor
	public ArmoredEnemy (){
		
		speed -= 2.0f; // this speed should be double the speed of the normal class boar.
		health *=2;

	}

	void Update() {
		
		
		if (!GetComponent<Animation>().IsPlaying ("creep up") && !GetComponent<Animation>().IsPlaying("death03")) {
			GetComponent<Animation>().Play ("walk04");
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}
		
	}




		

}
