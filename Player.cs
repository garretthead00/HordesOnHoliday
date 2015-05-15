using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {


	
	public static int points;
	public static float health;
	public static float maxHealth;


	// Use this for initialization
	void Start () {
	
		maxHealth = 4;
		points = 0;
		health = maxHealth;


	}

	void Update(){


		// Constrains the player health from exceeding the max health
		if (health > maxHealth) {
			health = maxHealth;
		}

	}




	public void TakeDamage(float dmg) {
				
		health -= dmg;
		
		if (health <= 0) {

			Destroy(gameObject);	
		}
	}




}
