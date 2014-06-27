using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	public Transform objectToFollow;
	public Vector2 movementRatio = Vector2.one;

	// Update is called once per frame
	void LateUpdate ()
	{
		if (objectToFollow != null) { //Check if camera still exists in current scene
			Vector3 newPosition = objectToFollow.position;
			newPosition.x *= movementRatio.x;
			newPosition.y *= movementRatio.y;
			newPosition.z = transform.position.z;
			transform.position = newPosition;
		}
	}
}
