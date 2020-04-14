using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
	public class CurveSmallEnemy : BaseEnemy
	{
		private float phase;
		private float amplitude;

		// Start is called before the first frame update
		public override void Initialize()
		{
			phase = Random.Range(0f, Mathf.PI * 2);
			amplitude = Random.Range(0.03f, 0.05f);
			base.Initialize();
		}

		// Update is called once per frame
		void Update()
		{
			transform.position += new Vector3(
				Mathf.Sin(Time.frameCount * 0.05f + phase) * amplitude,
				-2f * Time.deltaTime,
				0f
			);
		}
	}
}
