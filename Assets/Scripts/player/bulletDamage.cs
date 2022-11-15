using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "obstacle") {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

    }
}
