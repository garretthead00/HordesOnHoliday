using UnityEngine;
using System.Collections;

public class PlayerMenuGUI : MonoBehaviour {

	private float menuWidth;
	private float menuHeight;
	private float menuTop;
	private float menuLeft;
	private GUIStyle guiStyle;
	public Font textFont;
	public Texture exitButton;


	// Use this for initialization
	void Start () {
	
		// INITIALIZE GUI POSITION and Dimmensions
		menuWidth = Screen.width * 0.5f;
		menuHeight = Screen.height * 0.5f;
		menuLeft = menuWidth - (menuWidth/2);
		menuTop = menuHeight - (menuHeight/2);
		guiStyle = new GUIStyle ();
		guiStyle.font = textFont;
		guiStyle.fontSize = (int) (menuWidth * 0.04f);
		guiStyle.normal.textColor = new Color (255.0f,200.0f,0.0f,255.0f);


	}
	



	void OnGUI() {

		// This group will contain all of the GUIs and position them relative to this group location
		GUI.BeginGroup (new Rect(menuLeft,menuTop,menuWidth,menuHeight));


		// Player Menu Box
		GUI.Box(new Rect(0,0,menuWidth,menuHeight), "");

		// Exit Button
		if (GUI.Button (new Rect (menuWidth * 0.925f, 0, menuWidth * 0.075f, menuWidth * 0.075f), exitButton, guiStyle)) {
			Application.LoadLevel("StartMenu");
		}

		GUI.BeginGroup (new Rect(menuWidth*0.125f,menuHeight*0.1f,menuWidth*0.75f,menuHeight*0.6f));
		// Player Stat box
		GUI.color = new Color (1.0f, 1.0f, 1.0f, 0.01f);
		GUI.Box(new Rect(0,0,menuWidth*0.75f,menuHeight*0.6f), "");

		GUI.TextField (new Rect (menuWidth*0.125f ,menuHeight*0.1f,menuWidth * 0.3f, menuHeight * 0.15f), "Score: " + PlayerData.data.score, guiStyle);
		GUI.TextField (new Rect (menuWidth*0.125f ,menuHeight*0.4f,menuWidth * 0.3f, menuHeight * 0.15f), "XP: " + PlayerData.data.XP, guiStyle);

		GUI.EndGroup ();
		if (GUI.Button(new Rect (menuWidth * 0.46f, menuHeight * 0.8f, menuWidth * 0.3f, menuHeight * 0.15f), "Play", guiStyle)) {

						Application.LoadLevel ("HordesOnHoliday");
				}



		GUI.EndGroup ();
	}
}
