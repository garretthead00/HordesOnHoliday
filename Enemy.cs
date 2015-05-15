using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	protected float speed = 7.5f; 
	protected float health = 1.0f;
	protected Vector3 target;





	void Start(){



		GetComponent<Animation>().wrapMode = WrapMode.Loop; // Loop animations
		GetComponent<Animation>()["death03"].wrapMode = WrapMode.Once; // Cue death animation only once, DONOT LOOP
		GetComponent<Animation>()["death03"].layer = 1; // will play once then continue on with the original loop
		GetComponent<Animation>()["creep up"].wrapMode = WrapMode.Once; 
		GetComponent<Animation>()["creep up"].layer = 1; 


		// Locate target
		// Locate target
		target = transform.position;
		target.z -= 50.0f;
		transform.LookAt (target); // Rotate towards the target
		GetComponent<Animation>().Play ("creep up");


		}





	/** This will detect an trigger in the collider set to this class.
	 * This is where the TakeDamage method will be called.
	 **/
	void OnTriggerEnter(Collider c) {


		if (c.gameObject.tag == "Projectile") {

			TakeDamage(1);
		
		}
		
	}

	public void TakeDamage(float dmg) {

			health -= dmg;		
		if (health <= 0) {
			GetComponent<Animation>().Play ("death03");

			Player.points+=1;
			PlayerData.data.score+=1;
			
			

			Destroy(this.gameObject, 1.0f);
		}
	}

}
