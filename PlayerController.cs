using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {

	// Handling
	public float rotationSpeed = 450;
	// System
	private Quaternion targetRotation;

	private Camera cam;
	public RaycastHit hit;




	// Use this for initialization
	void Start () {

		cam = Camera.main;

	}
	
	// Update is called once per frame
	void Update () {

		// Controls the player inputs
		//ControlMouse ();
					
		if (Input.GetMouseButtonDown (0)) {
			
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, 1000)&& (hit.collider.tag == "Ground"|| hit.collider.tag == "Enemy")) {
				
				transform.LookAt (hit.point);
			}

			
			
		}

	}



	/** ControlMouse()
	 * This will allow me to control my player with the mouse and keypad.
	 * The mouse position will control the rotation while the keypad controls
	 * the direction.
	 * */
	void ControlMouse() {
		
		Vector3 mousePos = Input.mousePosition;

		// This is what will constrain the turret to only rotate facing forward. IF I used cam.transform.position.y - transform.position.y, it would look backwards
		//mousePos = cam.ScreenToWorldPoint(new Vector3(mousePos.x,0,mousePos.y));//cam.transform.position.y + transform.position.y
	

			// This is what will constrain the turret to only rotate facing forward. IF I used cam.transform.position.y - transform.position.y, it would look backwards
			mousePos = cam.ScreenToWorldPoint(new Vector3(mousePos.x,mousePos.y,cam.transform.position.y + transform.position.y));//cam.transform.position.y + transform.position.y
			

			// This will keep the rotation of our player from the player's position (subtracting the new Vector 3)
			targetRotation = Quaternion.LookRotation(mousePos - new Vector3(transform.position.x,transform.position.y,transform.position.z)); 
			transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y,targetRotation.eulerAngles.y,rotationSpeed * Time.deltaTime);

	}


}
