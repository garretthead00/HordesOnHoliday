using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	
	
	
	public float radius;  //provides a radius at which the explosive will effect rigidbodies
	public float power; //provides explosive power
	public float explosiveLift; //determines how the explosion reacts. A higher value means rigidbodies will fly upward
	public float explosiveDelay; //adds a delay in seconds to our explosive object


	void OnTriggerEnter(Collider c) {


		Destroy (this.gameObject);
	}


	/*This is where the blast radius function will go.
		* Although I beleive the current method is not excatly what I'm looking for because it creates a 3D blast radius
		* where as I need a 2D raduis that spans the area on the ground exclusively.
		* */
	/**
	 * Vector3 explosionPos = this.transform.position;
		Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
		foreach (Collider hit in colliders) {
			
			if (hit.rigidbody){
				hit.rigidbody.AddExplosionForce (power, explosionPos, radius, explosiveLift);
			}
			hit.rigidbody.AddForceAtPosition(radius*Vector3.forward, explosionPos);
			
			
		}
		*/
	


	
	
}
