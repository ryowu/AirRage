using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class Cloud : MonoBehaviour
	{
		void Update()
		{
			transform.position += new Vector3(0, -1f * Time.deltaTime);
		}
	}
}
