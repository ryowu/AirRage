using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class AudioManager : MonoBehaviour
	{
		public enum SoundEffect
		{
			Explode,
			GunMagnum
		}

		public static AudioSource source;

		public static AudioClip explodeSound;
		public static AudioClip gunMagnum;

		void Start()
		{
			explodeSound = Resources.Load<AudioClip>("Audio/audio_explode");
			gunMagnum = Resources.Load<AudioClip>("Audio/GunMagnum");
			source = GetComponent<AudioSource>();
		}

		public static void PlaySound(SoundEffect sound)
		{
			switch (sound)
			{
				case SoundEffect.Explode:
					{
						source.PlayOneShot(explodeSound);
						break;
					}
				case SoundEffect.GunMagnum:
					{
						source.PlayOneShot(gunMagnum);
						break;
					}
				default:
					{
						//
						break;
					}
			}
		}
	}
}
