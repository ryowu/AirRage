using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("Shoot");
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
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
