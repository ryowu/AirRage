using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
	public GameObject stars1;
	public GameObject stars2;
	public GameObject spaceBack1;
	public GameObject spaceBack2;

	// Start is called before the first frame update
	void Start()
	{
		Instantiate(
			spaceBack1,
			new Vector3(0, 15.2f, 0),
			transform.rotation
		);

		Instantiate(
			spaceBack2,
			new Vector3(0, 56.14f, 0),
			transform.rotation
		);

		Instantiate(
			stars1,
			new Vector3(0, 15.2f, 0),
			transform.rotation
		);

		Instantiate(
			stars2,
			new Vector3(0, 56.14f, 0),
			transform.rotation
		);
	}

	// Update is called once per frame
	void Update()
	{
	}
}
