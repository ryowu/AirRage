﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
	public class BaseEnemy : MonoBehaviour
	{
		public GameObject explosion;

		protected GameControllerScript gameController;

		public GameObject SmallBullet;

		//Enemy Property
		public int HP;

		public void Start()
		{
			gameController = GameObject.FindWithTag("GameController").GetComponent<GameControllerScript>();
			Initialize();
		}

		public virtual void Initialize()
		{
		}

		public void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.gameObject.CompareTag("Bullet"))
			{
				HP -= 1;
				Destroy(collision.gameObject);
				if (HP <= 0)
				{
					AudioManager.PlaySound(AudioManager.SoundEffect.Explode);
					gameController.AddScore(10);
					Instantiate(explosion, transform.position, transform.rotation);
					Destroy(gameObject);
				}
			}

			if (collision.gameObject.CompareTag("Player"))
			{
				AudioManager.PlaySound(AudioManager.SoundEffect.Explode);
				gameController.GameOver();
				Instantiate(explosion, transform.position, transform.rotation);
				Instantiate(explosion, collision.transform.position, collision.transform.rotation);
				Destroy(collision.gameObject);
				Destroy(gameObject);
			}
		}
	}
}