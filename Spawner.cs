using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
	public GameObject spaceship;
	public GameObject hazard;
	public GameObject hazard2;
	public GameObject hazard3;
	public GameObject powerupscore;
	public GameObject poweruplife;
	public GameObject poweruptime;
	public GameObject powerupshooting;
	
	
	public Vector3 spawnValues;
	float spawnWait = .25f;
	public float startWait;
	public float waveWait;
	float time;
	
	void Start ()
	{
		time = Time.time;
		StartCoroutine (SpawnWaves ());
	}
	
	IEnumerator SpawnWaves ()
	{

		yield return new WaitForSeconds (startWait);
		while (true)
		{
			//timemult is used to slowly increase spawning of asteroids over time
			float timemult = (Time.time-time)/60f;
			timemult = timemult/100f;
			//spawn wait is the time between spawning of objects
			spawnWait = .40f - timemult;
			if(spawnWait < .1f)
			{
				spawnWait = .1f;
			}
			//powerupchance decreases as the spawnwait increases
			float powerupchance = .2f*spawnWait;
			//spawns randomly
			Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
			float randomnum = Random.Range(0f, 1f);
			//randomly choose an asteroid or powerup also randomly choose a type of asteroid and type of power up
			if(randomnum > powerupchance)
			{
				float randomasteroidtype = Random.Range (0f,1f);
				if(randomasteroidtype > .67f)
				{
					Instantiate (hazard, spawnPosition, Quaternion.identity);
					hazard.gameObject.tag = "asteroid";
				}
				else if(randomasteroidtype > .33f)
				{
					Instantiate (hazard2, spawnPosition, Quaternion.identity);
					hazard2.gameObject.tag = "asteroid";
				}
				else
				{
					Instantiate (hazard3, spawnPosition, Quaternion.identity);
					hazard3.gameObject.tag = "asteroid";
				}
				
				
			}
			//else if(randomnum > .05f)
			//{
			//Instantiate (spaceship, spawnPosition, spawnRotation);
			//spaceship.gameObject.tag = "enemyspaceship";
			//}
			else
			{
				float randompowerup = Random.Range(0f, 1f);
				if(randompowerup > .75f)
				{
					Instantiate (powerupscore, spawnPosition, Quaternion.identity);
				}
				else if(randompowerup > .5f)
				{
					Instantiate (powerupshooting, spawnPosition, Quaternion.identity);
				}
				else if(randompowerup > .25f)
				{
					Instantiate (poweruptime, spawnPosition, Quaternion.identity);
				}
				else
				{
					Instantiate (poweruplife, spawnPosition, Quaternion.identity);
				}
				
				//powerup.gameObject.tag = "powerup";
			}
			yield return new WaitForSeconds (spawnWait);
		}
	}
}
