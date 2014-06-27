using UnityEngine;
using System.Collections;

public class destroyObjects : MonoBehaviour
{
	public GameObject explosion;
	//time of invulnerability after getting hit

	void OnTriggerEnter(Collider other) 
	{
		GameObject ship = GameObject.Find("ship");
		ShipBehavior shipbehavior = ship.GetComponent<ShipBehavior>();
		if (other.tag == "gameBoundary")
		{
			return;
		}

		if (other.tag == "bullet") 
		{
			GameObject spawner = GameObject.Find("Spawner");
			enemySpaceshipSpawner spawnerScript = spawner.GetComponent<enemySpaceshipSpawner>();

			Instantiate (explosion, transform.position, transform.rotation); //explosion will occur at collision
			if(gameObject.tag == "Enemy" || gameObject.tag == "ebullet") {
				Destroy (gameObject); //destroys enemy or enemy bullet(not sure if ebullet destroyed)
				spawnerScript.enemyAmount--;
			} 
			Destroy (other.gameObject); //destroys bullet
			//asteroid does not get destroyed
		}
		
		if (other.tag == "ship" && shipbehavior.immunetime < Time.time) 
		{
			shipbehavior.lives--;
			shipbehavior.immunetime = Time.time+3f;
			Destroy (gameObject); //destroys asteroid
			Instantiate (explosion, transform.position, transform.rotation); //explosion will occur at asteroid
			if(shipbehavior.lives <= 0) {
				Destroy (other.gameObject); //destroys ship
				Application.LoadLevel(2);
			}
		}
	}
}
