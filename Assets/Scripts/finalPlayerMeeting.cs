using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class finalPlayerMeeting : MonoBehaviour
{
    public Animator anim;
    public GameObject finishPanel;
    public TextMeshProUGUI setPlayerText;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("isTouching", true);
            if (playerController.instance.countCoinsInMap == 0)
            {
                setPlayerText.text = "{ 666 };";
                finishPanel.SetActive(true);
            }
            if (playerController.instance.countCoinsInMap > 0 && playerController.instance.countCoinsInMap < 50) {
                setPlayerText.text = "{ Bad };";
                finishPanel.SetActive(true);
            }
            if (playerController.instance.countCoinsInMap >= 50 && playerController.instance.countCoinsInMap < 100)
            {
                setPlayerText.text = "{ Good };";
                finishPanel.SetActive(true);
            }
            if (playerController.instance.countCoinsInMap >= 100 && playerController.instance.countCoinsInMap < 200)
            {
                setPlayerText.text = "{ Excellent };";
                finishPanel.SetActive(true);
            }
            if (playerController.instance.countCoinsInMap >= 200 && playerController.instance.countCoinsInMap < 250)
            {
                setPlayerText.text = "{ Dominant };";
                finishPanel.SetActive(true);
            }
            if (playerController.instance.countCoinsInMap == 251 || playerController.instance.countCoinsInMap == 50)
            {
                setPlayerText.text = "{ God!!! };";
                finishPanel.SetActive(true);
            }
        }
    }
}
