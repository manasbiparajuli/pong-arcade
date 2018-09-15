// Audio Manager
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	static MusicPlayer instance = null;

	private void Awake()
	{
		if (instance != null)
		{
			// Avoid duplicate music playing on the background
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			// Keep the background music until the user quits from the game
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
}
