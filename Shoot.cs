using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
	//public Transform Target;
	public float firingAngle;
	public float projectileSpeed;

	private Vector3 target;
	public GameObject Projectile;   
	 
	private Transform myTransform;
	private RaycastHit hit;




	void Start()
	{
		myTransform = transform;      
	}



	void Update()
	{     
		// Calculates the MouseClick, target position relative to the ground.
		if(Input.GetMouseButtonDown(0)){
			

				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				// If the selected target is a valid target
				if(Physics.Raycast(ray,out hit, 1000) && (hit.collider.tag == "Ground"|| hit.collider.tag == "Enemy")){

				//Debug.Log("Hit point: " + hit.point + " At Distance: " + hit.distance);
				StartCoroutine(SimulateProjectile(hit.point));

			}
			

		}

	}
	

	/** This is the meat and potatoes of the game. This function will take in the target position from the mouse click position
	 * and firing the projectile along the trajectory path according to the firing angle (45 degrees is the best angle) and the 
	 * gravity parameter that can be manipulated for increase the speed of the projectile.
	 */
	IEnumerator SimulateProjectile(Vector3 targetSelect)
	{
		target = targetSelect;
		// Short delay added before Projectile is thrown
		yield return new WaitForSeconds(0.26f);
		GameObject newProjectile= Instantiate(Projectile,transform.position, transform.rotation)as GameObject;
		
		// Move projectile to the position of throwing object + add some offset if needed.
		newProjectile.transform.position = myTransform.position + new Vector3(0, 0.0f, 0);
		
		// Calculate distance to target
		float target_Distance = Vector3.Distance(newProjectile.transform.position, target);
		
		// Calculate the velocity needed to throw the object to the target at specified angle.
		float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / projectileSpeed);
		
		// Extract the X  Y component of the velocity
		float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
		float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);
		
		// Calculate flight time.
		float flightDuration = target_Distance / Vx;
		
		// Rotate projectile to face the target.
		newProjectile.transform.rotation = Quaternion.LookRotation(target - newProjectile.transform.position);
		
		float elapse_time = 0;
		
		while (elapse_time < flightDuration)
		{
			newProjectile.transform.Translate(0, (Vy - (projectileSpeed * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);
			
			elapse_time += Time.deltaTime;
			
			yield return null;
		}
	}


}

