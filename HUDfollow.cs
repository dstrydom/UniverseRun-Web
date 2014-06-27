using UnityEngine;
using System.Collections;

public class HUDfollow : MonoBehaviour
{
	public Transform objectToFollow;
	public Vector2 movementRatio = Vector2.one;
	
	// Update is called once per frame
	void LateUpdate ()
	{
		if (objectToFollow != null) { //Check if camera still exists in current scene
			Vector3 otherposition = objectToFollow.position;
			Vector3 newPosition = this.transform.position;
			newPosition.x *= movementRatio.x*otherposition.x;
			newPosition.y *= movementRatio.y*otherposition.y;
			newPosition.z = transform.position.z*otherposition.z;
			transform.position = newPosition;
		}
	}
}
