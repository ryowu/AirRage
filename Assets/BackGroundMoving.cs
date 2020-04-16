using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMoving : MonoBehaviour
{
	public float speed;

	private float dy;

	// Start is called before the first frame update
	void Start()
	{
		dy = -1f * speed * Time.deltaTime;
	}

	// Update is called once per frame
	void Update()
	{
		transform.position += new Vector3(0, dy);

		if (transform.position.y < -27.5f)
		{
			transform.position = new Vector3(0, 54.3f, 0);
		}
	}
}
