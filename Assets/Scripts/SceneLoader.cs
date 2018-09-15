// Handle Game Manager
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	// load level based on level names
	public void LoadLevel (string name)
	{
		SceneManager.LoadScene(name);
		Brick.breakableCount = 0;
	}

	public void LoadNextScene()
	{
		// Load next scene based on current scene index
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		Brick.breakableCount = 0;
		SceneManager.LoadScene(currentSceneIndex + 1);
	}

	// Load Welcome screen
	public void LoadStartScene()
	{
		SceneManager.LoadScene(0);
	}

	public void QuitGame()
	{
		Application.Quit();
	}

	public void BrickDestroyed()
	{
		// Load next screen when all the breakable bricks are destroyed
		if (Brick.breakableCount <= 0)
		{
			LoadNextScene();
		}
	}
}