using UnityEngine;
using System.Collections;

public class BackgroundMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;

		pos.y -= 0.05f;

		if (pos.y < -149) 
		{
			pos.y = 149;
		}

		transform.position = pos;
	}
}
