using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class SpawnEnemy : MonoBehaviour {



	public GameObject[] enemies;
	[HideInInspector]
	public FastEnemy fast;
	[HideInInspector]
	public ArmoredEnemy armored;
	[HideInInspector]
	public Vector3[] spawnPositions;
	private int hazardCount = 10;
	public float Round = 1;

	// Wait Times
	private float spawnWait = 2.0f;
	private float startWait = 6.5f;
	private float waveWait = 5;
	

	

	void Start(){


	
		StartCoroutine (SpawnWave());

	
	}




	IEnumerator SpawnWave(){


		// Initiate the beginning eof the round wait sequence. (3-5 seconds)
		yield return new WaitForSeconds (startWait);

		// Counts the current round. 3 per Battle
		while (Round <=8) {
				getSpawnPositions (Random.Range (1, 4)); // Randomly select a spawn pattern


			
				for (int i = 0; i < hazardCount; i++) {
				int x = Random.Range(0,3);
				GameObject enemy = Instantiate (enemies[x], spawnPositions [i], Quaternion.identity) as GameObject;
						yield return new WaitForSeconds (spawnWait);
				}

				// Insert hold here and wait until all boars of the previous wave are destroyed before spawning next pattern
				yield return new WaitForSeconds (waveWait);
				Round += 1;

		}
		PlayerData.data.XP += 1;


	}



	/** This Function will take in the patternID as a parameter and generate a list of positions for the Boars
	 * to be spawned.
	 * */
	public void getSpawnPositions(int x){

		// Depending on the patternID will determine the positions in the list.
		spawnPositions = new Vector3[10];
		int Xpos = Random.Range (-5, 5); // Randomly select an x position
		int Zpos = 90;
		int shift = 5;
		int Ypos = 0;
		for (int i = 0; i < 10; i++) {

			if(Xpos >= 10 || Xpos <= -10){ Xpos = Random.Range (-5, 5);}

			switch(x){

			case 1: spawnPositions[i] = new Vector3(Xpos+=5, Ypos, Zpos);break;
			case 2: spawnPositions[i] = new Vector3(Xpos-=5, Ypos, Zpos);break;
			case 3: spawnPositions[i] = new Vector3(Random.Range (-20, 20), Ypos, Zpos);break;
			case 4: spawnPositions[i] = new Vector3(Xpos+=shift, Ypos, Zpos);shift*=-1;break;

			}

		}

	}








}
