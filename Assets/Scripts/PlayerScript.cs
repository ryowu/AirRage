using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	public GameObject bullet;

	public int BulletLevel;

	public int HP;

	public bool IsImmune;

	// Start is called before the first frame update
	void Start()
	{
		IsImmune = false;
		HP = 3;
		BulletLevel = 1;
	}

	// Update is called once per frame
	void Update()
	{
		float dx = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 6f;
		float dy = Input.GetAxisRaw("Vertical") * Time.deltaTime * 6f;

		dx = Mathf.Clamp(transform.position.x + dx, -6f, 6f);
		dy = Mathf.Clamp(transform.position.y + dy, -4.4f, 4.2f);

		transform.position = new Vector3(dx, dy);

		if (Input.GetButtonDown("Jump"))
		{
			AudioManager.PlaySound(AudioManager.SoundEffect.GunMagnum);
			InitBullets();
		}
	}

	public bool GetHit()
	{
		if (!IsImmune)
		{
			HP -= 1;
			if (HP > 0)
				StartCoroutine(Immune());
			return true;
		}
		else
		{
			return false;
		}
	}

	IEnumerator Immune()
	{
		IsImmune = true;
		GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f);
		yield return new WaitForSeconds(3f);
		GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
		IsImmune = false;
	}

	void InitBullets()
	{
		switch (BulletLevel)
		{
			case 1:
				{
					Instantiate(bullet, transform.position, transform.rotation);
					break;
				}
			case 2:
				{
					Instantiate(bullet, new Vector3(transform.position.x - 0.15f, transform.position.y), transform.rotation);
					Instantiate(bullet, new Vector3(transform.position.x + 0.15f, transform.position.y), transform.rotation);
					break;
				}
			case 3:
				{
					GameObject obj = Instantiate(bullet, new Vector3(transform.position.x - 0.15f, transform.position.y), transform.rotation);
					obj.GetComponent<BulletScrpit>().dx = -2f;
					obj = Instantiate(bullet, new Vector3(transform.position.x + 0.15f, transform.position.y), transform.rotation);
					obj.GetComponent<BulletScrpit>().dx = 2f;
					obj = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y), transform.rotation);
					obj.GetComponent<BulletScrpit>().dx = 0;
					break;
				}
			case 4:
				{
					GameObject obj = Instantiate(bullet, new Vector3(transform.position.x - 0.1f, transform.position.y), transform.rotation);
					obj.GetComponent<BulletScrpit>().dx = -2f;
					obj = Instantiate(bullet, new Vector3(transform.position.x + 0.1f, transform.position.y), transform.rotation);
					obj.GetComponent<BulletScrpit>().dx = 2f;
					obj = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y), transform.rotation);
					obj.GetComponent<BulletScrpit>().dx = 0;
					obj = Instantiate(bullet, new Vector3(transform.position.x - 0.15f, transform.position.y), transform.rotation);
					obj.GetComponent<BulletScrpit>().dx = -4f;
					obj = Instantiate(bullet, new Vector3(transform.position.x + 0.15f, transform.position.y), transform.rotation);
					obj.GetComponent<BulletScrpit>().dx = 4f;
					break;
				}
		}
	}
}
