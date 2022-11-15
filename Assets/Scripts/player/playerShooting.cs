using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShooting : MonoBehaviour
{
    public Animator anim;
    public GameObject bullet;
    public Transform bulletPos;
    public float forceBullet = 50000f;
    public bool isDashing;
    public static playerShooting instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Mouse0)) {
            anim.SetTrigger("shoot");
            GameObject bulletSpawn = Instantiate(bullet, bulletPos.position, bullet.transform.rotation);
            if (playerController.faceRightDirection)
            {
                bulletSpawn.GetComponent<Rigidbody2D>().AddForce(Vector2.right * forceBullet*Time.deltaTime);
            }
            else if (!playerController.faceRightDirection) {
                bulletSpawn.GetComponent<Rigidbody2D>().AddForce(Vector2.left * forceBullet*Time.deltaTime);
            }
            
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            anim.SetBool("isShooting",false); 
        }


        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.SetTrigger("slide");
        }
        if (isDashing == false)
        {
            anim.SetBool("isSliding", false);
        }


    }
}
