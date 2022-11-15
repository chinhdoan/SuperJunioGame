using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLeftRight : MonoBehaviour
{
    public Transform checkLeftGround;
    public Transform checkRightGround;
    public float speed = 1f;
    float direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left*speed*Time.deltaTime*direction);
        if ( ((Physics2D.Raycast(checkLeftGround.position, Vector2.down, 2)) == false) || ((Physics2D.Raycast(checkRightGround.position, Vector2.down, 2)) == false)) {
            transform.eulerAngles = new Vector3(0f,180f,0f);
            direction *= -1;
        }
       
    }
}
