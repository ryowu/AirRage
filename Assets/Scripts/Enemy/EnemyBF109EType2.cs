using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
	public class EnemyBF109EType2 : BaseEnemy
	{
		private bool hasHalted;
		private bool shouldFire;


		public GameObject CrystalPower;
		public GameObject Player;
		private float spawnBulletPeriod;

		public override void Initialize()
		{
			shouldFire = true;
			spawnBulletPeriod = 0;
			hasHalted = false;
			Speed = 2f;
			base.Initialize();
		}

		void Update()
		{
			if (transform.position.y < 3.5f && !hasHalted)
			{
				hasHalted = true;
				StartCoroutine("Halt");
				Speed = 0.5f;
			}

			if (transform.position.y < -2)
			{
				shouldFire = false;
			}

			if (shouldFire)
			{
				spawnBulletPeriod += 1f * Time.deltaTime;
				if (spawnBulletPeriod >= 3.5f)
				{
					spawnBulletPeriod = 0;
					Player = GameObject.Find("Player");
					GameObject objBullet = Instantiate(SmallBullet, new Vector3(transform.position.x, transform.position.y), transform.rotation);
					Vector3 v = Player.transform.position - transform.position;
					objBullet.GetComponent<SmallBullet>().dx = v.x * 4f / v.magnitude;
					objBullet.GetComponent<SmallBullet>().dy = v.y * 4f / v.magnitude;
				}
			}

			transform.position += new Vector3(0, -1f * Speed * Time.deltaTime);
		}

		IEnumerator Halt()
		{
			yield return new WaitForSeconds(3f);
		}

		public override void EnemyDestroied()
		{
			Instantiate(CrystalPower, transform.position, transform.rotation);
			base.EnemyDestroied();
		}
	}
}
