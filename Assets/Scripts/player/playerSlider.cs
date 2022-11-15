using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSlider : MonoBehaviour
{
    public Animator anim;
    /*    public Rigidbody2D rb;
    public float speed = 2f;
    public float extraSpeed = 200f;
    bool isDashing = false;
    public float startDashing = 0.1f;
    float dashTime;*/
    public bool  isDashing = false;
    public static playerSlider instance;
    int checkPlayerIndex;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            anim.SetTrigger("slide");
        }
        if (isDashing == false)
        {
            anim.SetBool("isSliding", false);
        }

    }
}
