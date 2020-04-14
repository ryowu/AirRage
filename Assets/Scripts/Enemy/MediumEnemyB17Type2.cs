using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
	public class MediumEnemyB17Type2 : BaseEnemy
	{
		private int bulletCountGap;



		public override void Initialize()
		{
			StartCoroutine("SpawnSmallBullet");
			base.Initialize();
		}

		IEnumerator SpawnSmallBullet()
		{
			bulletCountGap = 3;
			while (true)
			{
				Instantiate(
					SmallBullet,
					new Vector3(transform.position.x - 0.7f, transform.position.y - 0.3f, 0f),
					transform.rotation
				);

				Instantiate(
							SmallBullet,
							new Vector3(transform.position.x + 0.7f, transform.position.y - 0.3f, 0f),
							transform.rotation
						);

				bulletCountGap--;
				if (bulletCountGap <= 0)
				{
					bulletCountGap = 3;
					yield return new WaitForSeconds(3f);
				}
				else
				{
					yield return new WaitForSeconds(0.2f);
				}
			}
		}

		// Update is called once per frame
		void Update()
		{
			transform.position += new Vector3(0, -1f * Time.deltaTime);
		}
	}
}
