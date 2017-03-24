using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Wall
{
	Left,
	Right
}

public class GameController : MonoBehaviour 
{
	public static int LeftScore = 0;
	public static int RightScore = 0;
	public GUISkin gui;

	void Start () 
	{

	}

	void OnGUI()
	{
		var ratio = Screen.currentResolution.width / Screen.currentResolution.height;
		var quarter = Screen.width / 4;
		var yPadding = 200f;
		GUI.skin = gui;
		GUI.Label(new Rect(quarter + (100 * ratio), yPadding, 100, 100), LeftScore.ToString().PadLeft(2, '0'));
		GUI.Label(new Rect(quarter * 3 - (200 * ratio), yPadding, 100, 100), RightScore.ToString().PadLeft(2, '0'));

		if (LeftScore == 10 || RightScore == 10)
		{
			var side = LeftScore == 10 ? "Left" : "Right";

			var rect = new Rect(0, 0, 1000, 300);
			rect.center = new Vector2(Screen.width / 2, 100);
			GUI.Label(rect, string.Format("{0} SIDE WINS!", side));
			GameObject.FindGameObjectWithTag("Ball").transform.gameObject.SendMessage("Reset", null, SendMessageOptions.RequireReceiver);

			var buttonRect = new Rect(0, 0, 400, 200);
			buttonRect.center = new Vector2(Screen.width / 2, 300);
			if (GUI.Button(buttonRect, "PLAY AGAIN?"))
			{
				Restart();
			}
		}
	}

	public static void IncrementScore(Wall wall)
	{
		if (wall == Wall.Left)
		{
			RightScore++;
		}
		else
		{
			LeftScore++;
		}
	}

	public static void Restart()
	{
		LeftScore = RightScore = 0;
		GameObject.FindGameObjectWithTag("Ball").transform.gameObject.SendMessage("Restart", null, SendMessageOptions.RequireReceiver);
	}
}
