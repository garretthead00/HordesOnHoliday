using UnityEngine;
using System.Collections;

public class GameSceneGUI :  MonoBehaviour {


	public Texture barBack;
	public Texture healthBar;
	private float healthPercentage;
	public Texture powerBar;
	private float powerPercentage;
	public Texture pauseButton;


	public GUIText announcer;

	private string scoreBoard;

	private GUIStyle guiStyle;
	public Font textFont;



	private SpawnEnemy battle;
	public static int counter = 3; // This is the countdown that will initiate the spawning.

	private float left;
	private float top;
	private float barWidth;
	private float healthBarWidth;
	private float barHeight;
	private bool paused = false;


	void Start () {
	

		// INITIALIZE GUI POSITIONS
		left = Screen.width * 0.025f;
		top = Screen.height * 0.025f;
		barWidth = Screen.width * 0.1f;
		barHeight = 10;
		guiStyle = new GUIStyle ();
		guiStyle.font = textFont;
		guiStyle.fontSize = 25;
		guiStyle.normal.textColor = new Color (255.0f,200.0f,0.0f,255.0f);

		battle = new SpawnEnemy ();

		// Begin countdown
		StartCoroutine (countdown ());

	}

	void OnGUI(){

	
		healthPercentage = Player.health / Player.maxHealth;

		healthBarWidth = healthPercentage * barWidth;


			// Update Health Bar
			GUI.DrawTexture (new Rect (left, top, barWidth, barHeight), barBack, ScaleMode.StretchToFill, true, 10.0f); // Draw HealthBar back bar (black)
			GUI.DrawTexture (new Rect (left, top, healthBarWidth, barHeight), healthBar, ScaleMode.StretchToFill, true, 10.0f); // Draw Health Bar

			// Update Power Bar
			GUI.DrawTexture (new Rect (left, top + barHeight * 2, barWidth, barHeight), barBack, ScaleMode.StretchToFill, true, 10.0f); // Draw Power Bar back bar (black)
			GUI.DrawTexture (new Rect (left, top + barHeight * 2, barWidth, barHeight), powerBar, ScaleMode.StretchToFill, true, 10.0f); // Draw Power Bar


			// Update ScoreBoard
			scoreBoard = "Score: " + Player.points;
			GUI.TextField (new Rect (Screen.width * 0.75f, top, barWidth, barHeight), scoreBoard, guiStyle);
			

			// Pause Button
			if (GUI.Button (new Rect (Screen.width-Screen.width*0.045f,top,Screen.width*0.04f,Screen.width*0.04f), pauseButton,guiStyle)) {
			
				if (!paused) {
					paused = !paused;
					Time.timeScale= 0.0f;
				}
				else{
					paused = !paused;
					Time.timeScale= 1.0f;					
				}			
			}
	}



	IEnumerator countdown(){
		announcer.text = "Round " + battle.Round;

		yield return new WaitForSeconds (2);


		while(counter>0){
			announcer.text= " " + counter;

			yield return new WaitForSeconds (1);
			counter -= 1;

		}
		announcer.text = "ATTACK!!";
		yield return new WaitForSeconds (1);
		announcer.text = " ";

	}
}
