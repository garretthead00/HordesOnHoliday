using UnityEngine;
using System.Collections;



/** This class will be a child class of the Boar class. This class will inherit the Boar class.
 * This class will define a type of Enemy class in the game
 * which will have the ability to run faster.
 **/
public class FastEnemy : Enemy {

	public GameObject fastEnemy;





	// FastBoar constructor
	public FastEnemy (){

		speed+=3.0f; // this speed should be double the speed of the normal class boar.

	}


	void Update() {
		
		
		if (!GetComponent<Animation>().IsPlaying ("creep up") && !GetComponent<Animation>().IsPlaying ("death03")) {
			GetComponent<Animation>().Play ("run02");
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}
		
	}








}
