using UnityEngine;
using System.Collections;

public class enemySpaceshipSpawner : MonoBehaviour
{
	public GameObject spaceship;			//enemy spaceship object
	float waitTimebetweenEnemyWaves = 25f;	//time to wait before spawning next wave of enemy ships
	private float AImenuCases = 4;					//
	public int formation = 0; //shared in enemyShipBehavior.cs
	public int waypointSize = 0; //shared in enemyShipBehavior.cs
	public int enemyAmount = 0;
	private int enemySpawnAmount = 0;
	public int randomStart = 0;

	IEnumerator AImenu(int choice){		//had to store as this, so I could run as coroutine. Can't have wait stmts in regular fxns
		switch (choice)					//so had to use IEnumerator instead.
		{
		case 0:
			//SQUARE FORMATION
			waypointSize = 9;
			enemySpawnAmount = 10;
			randomStart = Random.Range (0,3);
			switch(randomStart)
			{
			case 0:
				for(int i = 0; i < enemySpawnAmount; i++) {
					Instantiate (spaceship, new Vector3 (-20, 10, 65), Quaternion.identity);	//top left
					enemyAmount++;
					yield return new WaitForSeconds (1.5f);
				}
				break;
			case 1:
				for(int i = 0; i < enemySpawnAmount; i++) {
					Instantiate (spaceship, new Vector3 (20, 10, 65), Quaternion.identity);	//top right
					enemyAmount++;
					yield return new WaitForSeconds (1.5f);
				}
				break;
			case 2:
				for(int i = 0; i < enemySpawnAmount; i++) {
					Instantiate (spaceship, new Vector3 (-20, -10, 65), Quaternion.identity);	//bottom left
					enemyAmount++;
					yield return new WaitForSeconds (1.5f);
				}
				break;
			default:
				break;
			}
			break;

		case 1:
			//SPIRAL
			waypointSize = 13;
			enemySpawnAmount = 12;
			randomStart = Random.Range (0,3);
			switch(randomStart)
			{
			case 0:
				for(int i = 0; i < enemySpawnAmount; i++) {
					Instantiate (spaceship, new Vector3 (0, 15, 65),Quaternion.identity); //top
					enemyAmount++;
					yield return new WaitForSeconds (1f);
				}
				break;
			case 1:
				for(int i = 0; i < enemySpawnAmount; i++) {
					Instantiate (spaceship, new Vector3 (0, -15, 65),Quaternion.identity); //bottom
					enemyAmount++;
					yield return new WaitForSeconds (1f);
				}
				break;
			case 2:
				for(int i = 0; i < enemySpawnAmount; i++) {
					Instantiate (spaceship, new Vector3 (15, 0, 65),Quaternion.identity); //right
					enemyAmount++;
					yield return new WaitForSeconds (1f);
				}
				break;
			}
			break;

		case 2:
			//BOWTIE
			waypointSize = 19;
			enemySpawnAmount = 12;
			for(int i = 0; i < enemySpawnAmount; i++) {
				Instantiate (spaceship, new Vector3 (-15, -15, 65),Quaternion.identity); //bottom left
				enemyAmount++;
				yield return new WaitForSeconds (1.5f);
			}
			break;

		case 3:
			//SQUAREBIG FORMATION 
			waypointSize = 17;
			enemySpawnAmount = 12;
			waitTimebetweenEnemyWaves = 24f;
			for(int i = 0; i < enemySpawnAmount; i++) {
				Instantiate (spaceship, new Vector3 (-30, 15, 65), Quaternion.identity);	//top left
				enemyAmount++;
				yield return new WaitForSeconds (2f);
			}
			break;

		default:
		    break;
		}
	}

	void Start ()
	{
		StartCoroutine (SpawnWaves ()); //SpawnWaves is a coroutine because it has wait times that happen during gameplay, but shouldn't affect 
	}

	IEnumerator SpawnWaves ()
	{
		while (true) //continuously called from start of game
		{	
			formation = Random.Range (0,4); 	//random value from 0 - 3 (range returns 1 less than 2nd arg)
			if(GameObject.FindWithTag("Enemy") == null && enemyAmount == 0)
			{
				//formation = 2; //hard code for testing
				StartCoroutine(AImenu( formation ));	//starts AImenu
			}
			yield return new WaitForSeconds (waitTimebetweenEnemyWaves); 
			//set a waypoint behind the screen and destroy them after a few seconds

		}
	}
}
