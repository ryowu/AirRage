using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class CrystalPowerCell : MonoBehaviour
	{
		void Update()
		{
			transform.position += new Vector3(0, -0.2f * Time.deltaTime);
		}

		public void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.gameObject.CompareTag("Player"))
			{
				collision.gameObject.GetComponent<PlayerScript>().BulletPowerUp();
				Destroy(gameObject);
			}
		}
	}
}
