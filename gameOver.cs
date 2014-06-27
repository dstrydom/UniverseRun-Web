using UnityEngine;
using System.Collections;

public class gameOver : MonoBehaviour {

	//---------------Play Again/Quit Game---------------------
	public bool isQuit = false;
	
	void OnMouseEnter() {
		renderer.material.color = Color.red;
	}
	
	void OnMouseExit() {
		Screen.showCursor = true;
		renderer.material.color = Color.white;
	}
	
	void OnMouseDown() {
		if(isQuit) {
			//Application.Quit();
			Application.ExternalEval("window.close()"); //added for web
		}
		else {
			Screen.showCursor = false;
			Application.LoadLevel(1);
		}
	}

	//----------------------Display Score-------------------------------
	void OnGUI() {
		Screen.showCursor = true;
	}
}
