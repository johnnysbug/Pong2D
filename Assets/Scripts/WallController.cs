using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour 
{
	public Wall side = Wall.Left;

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.CompareTag("Ball"))
		{
			GameController.IncrementScore(side);
			collider.gameObject.SendMessage("Restart", null, SendMessageOptions.RequireReceiver);
		}
	}
}