using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

	public bool isPause = false;
	private Rect windowRect = new Rect(400f, 175f, 500f, Screen.height/3); //in unity
	//private Rect windowRect = new Rect(700f, 250f, 500f, Screen.height/2.75f); //on pc

	GameObject player;
	public Font font;
	public Color color;
	public Color color2;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown(KeyCode.Escape))
		{
			isPause = !isPause;
			if(isPause == true)
			{
				Time.timeScale = 0;
				player = GameObject.FindWithTag("ship");
				player.transform.GetComponent<ShipBehavior>().enabled = false;
				OnGUI();
			}
			else
			{
				Time.timeScale = 1;
				player = GameObject.FindWithTag("ship");
				player.transform.GetComponent<ShipBehavior>().enabled = true;
			}
		}
	}

	void OnGUI() {

		if (isPause) {
			GUI.skin.font = font;
			GUI.skin.window.fontSize = 55;
			GUI.skin.button.fontSize = 30;
			GUI.color = color2;


			Screen.showCursor = true;
			windowRect = GUILayout.Window (0, windowRect, DrawButtons, "Game Paused:");
		}
	}

	private void DrawButtons(int windowID)
	{
		GUI.color = color;

		GUILayout.BeginVertical();
		GUILayout.Space (100);
		if (GUILayout.Button ("Resume")) {
			isPause = false;
			Time.timeScale = 1;
			player = GameObject.FindWithTag("ship");
			player.transform.GetComponent<ShipBehavior>().enabled = true;
		}
		GUILayout.Space (25);
		if (GUILayout.Button ("Restart")) {
			Application.LoadLevel(1);
			isPause = false;
			Time.timeScale = 1;
			player = GameObject.FindWithTag("ship");
			player.transform.GetComponent<ShipBehavior>().enabled = true;
		}
		GUILayout.Space (25);
		if (GUILayout.Button ("Quit")) {
			//Application.Quit();
			Application.ExternalEval("window.close()"); //added for web

		}
		GUILayout.Space (25);
		GUILayout.EndVertical();
	}
}
