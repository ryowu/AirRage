using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class BulletScrpit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.PlaySound(AudioManager.SoundEffect.GunMagnum);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(
            0f, 15f * Time.deltaTime, 0f
        );
    }
}
