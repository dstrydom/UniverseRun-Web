using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public float min;

	// Update is called once per frame
	void Update () {
		min = 60; //Nothing in front

		RaycastHit hitInfo, hitInfo2, hitInfo3, hitInfo4, hitInfo5;
		//Raycasting for Ship (Attached to ship->front1)
		GameObject shipFront = GameObject.Find ("front1");
		Vector3 currentPos = new Vector3(shipFront.transform.position.x, shipFront.transform.position.y, shipFront.transform.position.z );
		float rayLength = 59f;
		//---------Raycast from center of ship--------------------------
		if( Physics.Raycast( currentPos, Vector3.forward, out hitInfo, rayLength ) ) {
			//Debug.Log( "There is something in front!" + hitInfo.distance );
		}
		//---------Raycast from left and right wings of ship--------------
		Vector3 currentPos2 = currentPos;
		currentPos2.x += 4;
		if( Physics.Raycast( currentPos2, Vector3.forward, out hitInfo2, rayLength ) ) {
			//Debug.Log( "There is something in front (right)!" + hitInfo2.distance );
			min = Mathf.Min( hitInfo.distance, hitInfo2.distance );
		}
		Vector3 currentPos3 = currentPos;
		currentPos3.x -= 4;
		if( Physics.Raycast( currentPos3, Vector3.forward, out hitInfo3, rayLength ) ) {
			//Debug.Log( "There is something in front (left)!" + hitInfo3.distance );
			min = Mathf.Min( min, hitInfo3.distance );
		}
		//---------Raycast from top and bottom of ship--------------
		Vector3 currentPos4 = currentPos;
		currentPos4.y += 1;
		if( Physics.Raycast( currentPos4, Vector3.forward, out hitInfo4, rayLength ) ) {
			//Debug.Log( "There is something in front (top)!" + hitInfo4.distance );
			min = Mathf.Min( min, hitInfo4.distance );
		}
		Vector3 currentPos5 = currentPos;
		currentPos5.y -= 1;
		if( Physics.Raycast( currentPos5, Vector3.forward, out hitInfo5, rayLength ) ) {
			//Debug.Log( "There is something in front! (bottom)" + hitInfo5.distance );
			min = Mathf.Min( min, hitInfo5.distance );
		}
		//Debug.Log ("Min distance: " + min);
	}
}
