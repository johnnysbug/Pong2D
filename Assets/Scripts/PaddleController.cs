using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
	public float speed = 15;
	public string axis = "LeftPaddle";

	void FixedUpdate()
	{
		var vertical = Input.GetAxisRaw(axis);
		GetComponent<Rigidbody2D>().velocity = new Vector2(0, vertical) * speed;
	}

    void Reset()
    {
        var position = gameObject.transform.position;
        position.y = 0;
        gameObject.transform.position = position;
    }
}