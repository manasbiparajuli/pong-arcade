// Handle Paddle behavior
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
	// configuration parameters
	[SerializeField] float minX;
	[SerializeField] float maxX;
	[SerializeField] float screenWidthInUnits;

	public bool autoPlay = false;

	private Ball ball;

	// Use this for initialization
	void Start ()
	{
		ball = GameObject.FindObjectOfType<Ball>();	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!autoPlay)
		{
			MoveWithMouse();
		}
		else
		{
			AutoPlay();
		}
	}

	// Make the paddle move according to the position of the ball in the game
	void AutoPlay()
	{
		Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
		Vector2 ballPos = ball.transform.position;

		// Clamp the paddle in x-axis
		paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
		transform.position = paddlePos;
	}

	// Move the paddle based on user input
	void MoveWithMouse()
	{
		float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
		Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
		paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);
		transform.position = paddlePos;
	}
}