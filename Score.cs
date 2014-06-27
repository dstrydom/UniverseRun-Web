using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public GUIText scoreText;
	public bool isGameOver;
	//static score means that you need member functions to access it from other scripts
	private static float score;
	//Used for extra score besides time (ie. killing ships, score powerups)
	float extraScore = 0;

	void Start() {
		if (!isGameOver) {
			score = 0;
			UpdateScore ();
		}
	}

	void Update() {
		if (isGameOver) {
			Screen.showCursor = true;
			UpdateScore();
			return;
		}
		score = Time.timeSinceLevelLoad + extraScore;
		UpdateScore ();
	}

	//Use this function to add extra score
	public void AddScore(int newScoreValue) {
		extraScore += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore() {
		if (!isGameOver) { //display score on gamePlay scence
			scoreText.text = "Score: " + (int)score;
		}
		else { //display score on gameOver scene
			scoreText.text = "" + (int)score;
		}
	}
}
