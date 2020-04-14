using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
	public class SmallBullet : MonoBehaviour
	{
		public GameObject explosion;

		private GameControllerScript gameController;

		private void Start()
		{
			gameController = GameObject.FindWithTag("GameController").GetComponent<GameControllerScript>();
		}

		void Update()
		{
			transform.position += new Vector3(0, -4f * Time.deltaTime);
		}

		public void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.gameObject.CompareTag("Player"))
			{
				AudioManager.PlaySound(AudioManager.SoundEffect.Explode);
				gameController.GameOver();
				Instantiate(explosion, collision.transform.position, collision.transform.rotation);
				Destroy(collision.gameObject);
				Destroy(gameObject);
			}
		}
	}
}
