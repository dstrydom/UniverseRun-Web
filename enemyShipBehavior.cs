using UnityEngine;
using System.Collections;

public class enemyShipBehavior : MonoBehaviour {

	GameObject[] waypoints = new GameObject[30]; //contains all waypoints
	float moveSpeed = 7.5f;
	private int node = 0; //current waypoint node
	float starttime;

	// Use this for initialization
	void Start () {
		//Get enemySpaceshipSpawner script
		GameObject spawner = GameObject.Find("Spawner");
		enemySpaceshipSpawner spawnerScript = spawner.GetComponent<enemySpaceshipSpawner>();
		GameObject[] waypointsTemp = new GameObject[spawnerScript.waypointSize];
		starttime = Time.time;
		//Rotate ship to face player
		transform.Rotate (0f, 180f, 0f);

		//--------------Square Formation----------------
		if (spawnerScript.formation == 0) {
			waypointsTemp [0] = GameObject.Find ("waypoint0_0");
			waypointsTemp [1] = GameObject.Find ("waypoint0_1");
			waypointsTemp [2] = GameObject.Find ("waypoint0_2");
			waypointsTemp [3] = GameObject.Find ("waypoint0_3");
			waypointsTemp [4] = GameObject.Find ("waypoint0_4");
			waypointsTemp [5] = GameObject.Find ("waypoint0_5");
			waypointsTemp [6] = GameObject.Find ("waypoint0_6");
			waypointsTemp [7] = GameObject.Find ("waypoint0_7");
			waypointsTemp [8] = GameObject.Find ("waypointfinal");
			if (spawnerScript.randomStart == 0) {node = 0;} //top left
			else if (spawnerScript.randomStart == 1) {node = 2;} //top right
			else {node = 6;} //bottom left
		}

		//--------------Sprial Formation----------------
		if( spawnerScript.formation == 1) {
			waypointsTemp [0] = GameObject.Find ("waypoint1_0");
			waypointsTemp [1] = GameObject.Find ("waypoint1_1");
			waypointsTemp [2] = GameObject.Find ("waypoint1_2");
			waypointsTemp [3] = GameObject.Find ("waypoint1_3");
			waypointsTemp [4] = GameObject.Find ("waypoint1_4");
			waypointsTemp [5] = GameObject.Find ("waypoint1_5");
			waypointsTemp [6] = GameObject.Find ("waypoint1_6");
			waypointsTemp [7] = GameObject.Find ("waypoint1_7");
			waypointsTemp [8] = GameObject.Find ("waypoint1_8");
			waypointsTemp [9] = GameObject.Find ("waypoint1_9");
			waypointsTemp [10] = GameObject.Find ("waypoint1_10");
			waypointsTemp [11] = GameObject.Find ("waypoint1_11");
			waypointsTemp [12] = GameObject.Find ("waypointfinal");
			if (spawnerScript.randomStart == 0) {node = 0;} //top
			else if (spawnerScript.randomStart == 1) {node = 6;} //bottom
			else {node = 3;} //right
		}

		//--------------Bowtie Formation----------------
		if( spawnerScript.formation == 2) {
			waypointsTemp [0] = GameObject.Find ("waypoint2_0");
			waypointsTemp [1] = GameObject.Find ("waypoint2_1");
			waypointsTemp [2] = GameObject.Find ("waypoint2_2");
			waypointsTemp [3] = GameObject.Find ("waypoint2_3");
			waypointsTemp [4] = GameObject.Find ("waypoint2_4");
			waypointsTemp [5] = GameObject.Find ("waypoint2_5");
			waypointsTemp [6] = GameObject.Find ("waypoint2_6");
			waypointsTemp [7] = GameObject.Find ("waypoint2_7");
			waypointsTemp [8] = GameObject.Find ("waypoint2_8");
			waypointsTemp [9] = GameObject.Find ("waypoint2_9");
			waypointsTemp [10] = GameObject.Find ("waypoint2_10");
			waypointsTemp [11] = GameObject.Find ("waypoint2_11");
			waypointsTemp [12] = GameObject.Find ("waypoint2_12");
			waypointsTemp [13] = GameObject.Find ("waypoint2_13");
			waypointsTemp [14] = GameObject.Find ("waypoint2_14");
			waypointsTemp [15] = GameObject.Find ("waypoint2_15");
			waypointsTemp [16] = GameObject.Find ("waypoint2_16");
			waypointsTemp [17] = GameObject.Find ("waypoint2_17");
			waypointsTemp [18] = GameObject.Find ("waypointfinal");
		}

		//--------------SquareBig Formation----------------
		if (spawnerScript.formation == 3) {
			waypointsTemp [0] = GameObject.Find ("waypoint3_0");
			waypointsTemp [1] = GameObject.Find ("waypoint3_1");
			waypointsTemp [2] = GameObject.Find ("waypoint3_2");
			waypointsTemp [3] = GameObject.Find ("waypoint3_3");
			waypointsTemp [4] = GameObject.Find ("waypoint3_4");
			waypointsTemp [5] = GameObject.Find ("waypoint3_5");
			waypointsTemp [6] = GameObject.Find ("waypoint3_6");
			waypointsTemp [7] = GameObject.Find ("waypoint3_7");
			waypointsTemp [8] = GameObject.Find ("waypoint3_8");
			waypointsTemp [9] = GameObject.Find ("waypoint3_9");
			waypointsTemp [10] = GameObject.Find ("waypoint3_10");
			waypointsTemp [11] = GameObject.Find ("waypoint3_11");
			waypointsTemp [12] = GameObject.Find ("waypoint3_12");
			waypointsTemp [13] = GameObject.Find ("waypoint3_13");
			waypointsTemp [14] = GameObject.Find ("waypoint3_14");
			waypointsTemp [15] = GameObject.Find ("waypoint3_15");
			waypointsTemp [16] = GameObject.Find ("waypointfinal");
		}

		waypoints = waypointsTemp;
		//Debug.Log ("WAYPOINT LENGTH:" + waypoints.Length);
	}

	// Update is called once per frame
	void Update () {
		GameObject ship = GameObject.Find("ship");
		ShipBehavior ship2 = ship.GetComponent<ShipBehavior>();
		if (Time.time > starttime + 80f) {
			Destroy (gameObject);
			GameObject spawner = GameObject.Find("Spawner");
			enemySpaceshipSpawner spawnerScript = spawner.GetComponent<enemySpaceshipSpawner>();
			spawnerScript.enemyAmount--;
			Debug.Log ("1");
		}
		else if (Time.time > starttime + 60f) {
			Vector3 currentPos = this.transform.position;
			Vector3 target = waypoints [waypoints.Length].transform.position;
			Vector3 moveDirection = (target - currentPos);
			Vector3 velocity = rigidbody.velocity;
			if(ship2 != null)
			{
				if(ship2.SlowTime)
				{
					moveSpeed = 5f; 
				}
				else
				{
					moveSpeed = 7.5f; 
				}
			}
		}
		else if ( node < waypoints.Length-1 ) {
			Vector3 currentPos = this.transform.position;
			Vector3 target = waypoints [node].transform.position;
			Vector3 moveDirection = (target - currentPos);
			Vector3 velocity = rigidbody.velocity;
			if(ship2 != null)
			{
				if(ship2.SlowTime)
				{
					moveSpeed = 5f; 
				}
				else
				{
					moveSpeed = 7.5f; 
				}
			}
			if (moveDirection.magnitude < 1) {
				node++; //move to next waypoint
				//Debug.Log("INCREASING NODE: " + node);
			} else {
				velocity = moveDirection.normalized * moveSpeed;
				//Debug.Log("VELOCITY: " + velocity);
			}
			rigidbody.velocity = velocity;
		} else {
			node = 0; //reset to cycle formation
		}
	}
}
