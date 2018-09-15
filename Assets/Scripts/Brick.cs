// Behavior for the brick
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
	public Sprite[] hitSprites;
	public AudioClip crack;
	public static int breakableCount = 0;	// count of breakable bricks
	public GameObject smoke;

	private int timesHit;
	private SceneLoader sceneLoader;
	private bool isBreakable;

	// Use this for initialization
	void Start ()
	{
		isBreakable = (tag == "Breakable");

		// keep track of breakable bricks
		if (isBreakable)
		{
			breakableCount++;
		}
		
		timesHit = 0;
		sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
	}
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		AudioSource.PlayClipAtPoint(crack, transform.position, 0.25f);

		if (isBreakable)
		{
			HandleHits();
		}
	}

	private void HandleHits()
	{
		timesHit++;

		int maxHits = hitSprites.Length + 1;
		
		// Decrease the count of breakable bricks in the level and destroy bricks
		// Also, check if all the bricks have been destroyed as we load new level 
		// if this is the case
		if (timesHit >= maxHits)
		{
			breakableCount--;
			sceneLoader.BrickDestroyed();

			// Initialize particle effect when bricks are destroyed
			PuffSmoke();

			// Destroy bricks
			Destroy(gameObject);
		}
		else
		{
			// Load Sprites based on damage level
			LoadSprites();
		}
	}

	public void PuffSmoke()
	{
		// Create particle effect when the bricks are destroyed and ensure the color of the particles 
		// match that of the destroyed brick's color
		GameObject puff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
		ParticleSystem.MainModule mainSettings = puff.GetComponent<ParticleSystem>().main;
		mainSettings.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}

	private void LoadSprites()
	{
		int spritesIndex = timesHit - 1;

		// Check if we have sprites for the damaged brick
		if (hitSprites[spritesIndex] != null)
		{
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spritesIndex];
		}
		else
		{
			Debug.LogError("Brick sprite missing!");
		}
	}
}