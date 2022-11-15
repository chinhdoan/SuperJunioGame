using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyForce : MonoBehaviour
{
    public Rigidbody2D rb;
    public float forceSpeed = 9f;
    int count=0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(addForce());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator addForce() {
        while (count == 0) {
            rb.velocity = new Vector2(forceSpeed , rb.velocity.y);
            count++;
            yield return new WaitForSeconds(7);
            count = 0;
        }
        
    }
    
}
