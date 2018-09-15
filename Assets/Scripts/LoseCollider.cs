// Handle lose condition by placing colliders below the screen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
	private SceneLoader sceneLoader;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		sceneLoader = GameObject.FindObjectOfType<SceneLoader>();
		sceneLoader.LoadLevel("Game Over");
	}
}