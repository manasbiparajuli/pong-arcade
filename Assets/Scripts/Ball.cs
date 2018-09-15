// Add behavior to the ball
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start ()
	{
		// Get the position of the ball relative to the paddle
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Ball rests on the paddle until user clicks on the button
		if (!hasStarted)
		{
			// Lock the ball relative to the paddle
			transform.position = paddle.transform.position + paddleToBallVector;

			// Wait for mouse press to launch
			if (Input.GetMouseButtonDown(0))
			{
				hasStarted = true;
				GetComponent<Rigidbody2D>().velocity = new Vector2(3f, 10f);
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		// Increment the ball's velocity to avoid boring loops
		Vector2 tweak = new Vector2(Random.Range(0f, 0.4f), Random.Range(0f, 0.4f));

		if (hasStarted)
		{
			GetComponent<AudioSource>().Play();
			GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}