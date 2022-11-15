using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthPlayer : MonoBehaviour
{
    public static int health = 5;
    public Image[] hearts;
    public Sprite emptyHeart;
    public Sprite filledHeart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Image img in hearts) {
            img.sprite = emptyHeart;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = filledHeart;
        }
    }
}
