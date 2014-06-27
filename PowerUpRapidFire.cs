using UnityEngine;
using System.Collections;

public class PowerUpRapidFire : MonoBehaviour {

	public AudioClip soundfile;
	//Shooting shooting = GameObject.Find ("shootpoint").GetComponent<Shooting>();
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "gameBoundary")
		{
			return;
		}
		
		if (other.tag == "bullet") 
		{
			return;
		}
		
		if (other.tag == "ship") 
		{
			//Instantiate (explosion, transform.position, transform.rotation); //explosion will occur at asteroid
			//Destroy (other.gameObject); //destroys ship
			Destroy (gameObject); //destroys power up object
			
			GameObject shooter = GameObject.Find("shootPoint");
			Shooting shootscript = shooter.GetComponent<Shooting>();
			GameObject ship = GameObject.Find("ship");
			ShipBehavior shipScript = ship.GetComponent<ShipBehavior>();
			shipScript.doBarrelRoll = true;
			shootscript.Rapidfire = true;
			shootscript.poweruptime = Time.time + 30f;

			//play sound
			audio.clip = soundfile;
			audio.Play();
		}
	}	
}
