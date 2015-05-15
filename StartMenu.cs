using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {


	public bool quitGame = false;

	void OnMouseEnter(){
		GetComponent<Renderer>().material.color = Color.red;
	}



	void OnMouseExit(){
		GetComponent<Renderer>().material.color = Color.white;
	}


	void OnMouseDown(){
		if(quitGame){
			Application.Quit();
		}
		else{
			Application.LoadLevel("PlayerMenu");
		}

	}
}
