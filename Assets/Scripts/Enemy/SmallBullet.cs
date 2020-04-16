using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
	public class SmallBullet : MonoBehaviour
	{
		public GameObject explosion;

		private GameControllerScript gameController;

		public float dx;
		public float dy;

		private void Start()
		{
			gameController = GameObject.FindWithTag("GameController").GetComponent<GameControllerScript>();
		}

		void Update()
		{
			transform.position += new Vector3(dx * Time.deltaTime, dy * Time.deltaTime);
		}

		public void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.gameObject.CompareTag("Player"))
			{
				if (collision.gameObject.GetComponent<PlayerScript>().GetHit())
				{
					Destroy(gameObject);
				}

				if(collision.gameObject.GetComponent<PlayerScript>().HP <= 0)
				{
					AudioManager.PlaySound(AudioManager.SoundEffect.Explode);
					gameController.GameOver();
					Instantiate(explosion, collision.transform.position, collision.transform.rotation);
					Destroy(collision.gameObject);
				}
			}
		}
	}
}
