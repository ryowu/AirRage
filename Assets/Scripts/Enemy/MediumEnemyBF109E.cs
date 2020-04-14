using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
	public class MediumEnemyBF109E : BaseEnemy
	{
		private float dx;
		private float dy;
		private float speed;
		private float direction;

		public override void Initialize()
		{
			direction = Random.Range(-1, 1);
			if (direction >= 0)
				direction = 1;
			else
				direction = -1;

			dx = 0;
			dy = 1f;
			speed = 2f;
			base.Initialize();
		}

		void Update()
		{
			if (transform.position.y > 4)
			{
				dx = 0;
				dy = speed * -1f * Time.deltaTime;
			}
			else
			{
				if (transform.rotation.z <= 0.7f || transform.rotation.z >= -0.7)
				{
					transform.Rotate(0, 0, 0.1f * direction);
					dy = speed * -1f * Time.deltaTime * Mathf.Cos(transform.rotation.z);
				}
				else
				{
					dy = 0;
				}

				dx = speed * Time.deltaTime * Mathf.Sin(transform.rotation.z);

			}

			transform.position += new Vector3(dx, dy);
		}
	}
}
