using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyUpDown : MonoBehaviour
{
    float startPosY;
    public float speed = 0.5f;
    public float range = 20f;
    float direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        startPosY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down *speed*Time.deltaTime * direction);
        if ((transform.position.y < startPosY - range) || transform.position.y > startPosY)
            direction *= -1;
    }
}
