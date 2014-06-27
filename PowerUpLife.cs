using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PowerUpLife : MonoBehaviour {

	public AudioClip soundfile;

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
			GameObject ship = GameObject.Find("ship");
			ShipBehavior shipbehavior = ship.GetComponent<ShipBehavior>();
			shipbehavior.doBarrelRoll = true;
			if(shipbehavior.lives < 9) 
			{
				shipbehavior.lives++;
			}

			//play sound
			//audio.PlayOneShot(soundfile);
			//audio.Play();
			audio.Play();
			Destroy (gameObject); //destroys power up object
		}
	}	
}
