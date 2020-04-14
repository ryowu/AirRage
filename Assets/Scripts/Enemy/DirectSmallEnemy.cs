using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
	public class DirectSmallEnemy : BaseEnemy
	{
		public override void Initialize()
		{
			base.Initialize();
		}

		// Update is called once per frame
		void Update()
		{
			transform.position += new Vector3(0, -3f * Time.deltaTime);
		}
	}
}
