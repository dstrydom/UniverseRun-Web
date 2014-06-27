using UnityEngine;
using System.Collections;

public class ShipBehavior : MonoBehaviour {

	public int lives = 5;
	public float moveSpeed;
	public float rotationSpeed;
	//public float maxRotateAngleX = 7f;
	//public float maxRotateAngleZ = 2f;
	public GUIText livesText;
	Vector3 curRot;
	float maxRotX; float minRotX;
	float maxRotZ; float minRotZ;
	public bool doBarrelRoll = false;
	public float BRz = 0f;
	public float SlowTimeTime;
	public bool SlowTime;
	public float immunetime = 0f;
	//public Texture2D crosshairImage;

	//Line render variables
	//GameObject line;
	//LineRenderer lr;

	void Start() {
		//Line start options
		//line = new GameObject ();
		//lr = line.AddComponent<LineRenderer> ();
		//lr.SetWidth (.1f, .1f);
		//lr.SetColors(
	}
	
	// Update is called once per frame
	void Update () {
		// Get the horizontal and vertical axis.
		// By default they are mapped to the arrow keys.
		// The value is in the range -1 to 1
		float translationH = Input.GetAxis ("Horizontal") * moveSpeed;
		float translationV = Input.GetAxis ("Vertical") * moveSpeed;
		float rotationV = Input.GetAxis ("Vertical") * rotationSpeed;
		float rotationH = Input.GetAxis ("Horizontal") * rotationSpeed;

		
		// Make it move 10 meters per second instead of 10 meters per frame...
		translationH *= Time.deltaTime;
		translationV *= Time.deltaTime;
		rotationH *= Time.deltaTime;
		rotationV *= Time.deltaTime;

		//translate boundaries
		float minTransX = -17F; float maxTransX = 17F;
		float minTransY = -9F; float maxTransY = 9F;
		Vector3 pos = transform.position;
		pos.x = Mathf.Clamp (pos.x + translationH, minTransX, maxTransX);
		pos.y = Mathf.Clamp (pos.y + translationV, minTransY, maxTransY);
		pos.z = 0;
		//move ship
		transform.position = pos;


		//rotation boundaries
		//limit rotations
		//curRot.x += rotationH;
		//curRot.z += rotationV;
		//curRot.x = Mathf.Clamp (curRot.x, minRotX, maxRotX);
		//curRot.z = Mathf.Clamp (curRot.z, minRotZ, maxRotZ);
		//rotate ship
		//this.transform.eulerAngles = curRot;

		//Look at crosshair/mouse cursor
		Vector3 mousePos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 65f);
		mousePos = Camera.main.ScreenToWorldPoint (mousePos);
		transform.LookAt (mousePos);
		transform.Rotate (0f, 90f, 0f);

		//Line from ship to crosshair
		/*GameObject shootPoint = GameObject.Find ("shootPoint");
		lr.SetPosition (0, shootPoint.transform.position);
		lr.SetPosition (1, mousePos);*/

		displayLives ();

		//Power up
		if(SlowTimeTime <= Time.time)
		{
			SlowTime = false;
		}
		
		if (doBarrelRoll == true) 
		{
			if(BRz >= 360f)
			{
				BRz = 0f;
				doBarrelRoll = false;
			}
			else
			{
				BRz += 5f;
				transform.Rotate (BRz, 0f, 0f);
				
			}
		}

	}

	public void displayLives() {
		livesText.text = "Lives: " + lives;
	}
	

	void OnGUI() {
		//change mouse cursor image
		/*float xMin = Screen.width - (Screen.width - Input.mousePosition.x) - (crosshairImage.width / 2);
		float yMin = (Screen.height - Input.mousePosition.y) - (crosshairImage.height / 2);
		GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);*/
		//hide mouse cursor
		Screen.showCursor = false;
	}
}
