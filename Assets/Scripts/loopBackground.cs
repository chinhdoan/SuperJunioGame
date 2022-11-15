using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopBackground : MonoBehaviour
{
    public Transform cam;
    public Transform firstBG;
    public Transform secondBG;
    Transform temp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.position.x > secondBG.position.x) {
            firstBG.position = secondBG.position + Vector3.right * 58.7f;
        }
        if (cam.position.x < secondBG.position.x)
        {
            firstBG.position = secondBG.position + Vector3.right * -58.7f;
        }
        if (cam.position.x > firstBG.position.x || cam.position.x < firstBG.position.x)
        {
            temp = firstBG;
            firstBG = secondBG;
            secondBG = temp;
        }
    }
}
