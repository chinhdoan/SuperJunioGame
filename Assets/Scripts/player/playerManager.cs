using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using TMPro;
public class playerManager : MonoBehaviour
{
    public static Vector2 lastCheckPoint = new Vector2(-36.885f, -83.39f);
    public GameObject[] players;
    public Text getCoinText;
    public static playerManager instance;
    public CinemachineVirtualCamera vitrualCam;
    public GameObject gameOverPanel;
    public int characterSelecterIndex;
    public GameObject[] healthDisplayPanel;
    public TextMeshProUGUI coinsCountText;
    public TextMeshProUGUI giftCountText;
    public TextMeshProUGUI giftValueText;
    public TextMeshProUGUI slideShortcutText;
    public TextMeshProUGUI fireShortcutText;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        /*GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPoint;*/
        characterSelecterIndex = PlayerPrefs.GetInt("characterSelection", 0);
        Instantiate(players[characterSelecterIndex], lastCheckPoint, Quaternion.identity);
        switch (characterSelecterIndex)
        {
            default:
                healthPlayer.health = 3;

                Instantiate(players[0], lastCheckPoint, Quaternion.identity);
                break;
            case (0):
                healthPlayer.health = 3;
                Instantiate(players[0], lastCheckPoint, Quaternion.identity);
                break;
            case (1):
                healthPlayer.health = 5;
                Instantiate(players[1], lastCheckPoint, Quaternion.identity);
                for (int i = 0; i < 2; i++)
                {
                    healthDisplayPanel[i].SetActive(true);
                }
                break;
            case (2):
                healthPlayer.health = 8;
                Instantiate(players[2], lastCheckPoint, Quaternion.identity);
                for (int i = 0; i < 5; i++)
                {
                    healthDisplayPanel[i].SetActive(true);
                }

                slideShortcutText.text = "Slider = { Ctrl };";
                break;
            case (3):
                healthPlayer.health = 10;
                Instantiate(players[3], lastCheckPoint, Quaternion.identity);
                for (int i = 0; i < 7; i++)
                {
                    healthDisplayPanel[i].SetActive(true);
                }
                slideShortcutText.text = "Slider = { Ctrl };";
                fireShortcutText.text = "Fire = { Left Mouse Click };";
                break;

        }

        getCoinText.text = PlayerPrefs.GetInt("coins").ToString();
        vitrualCam.Follow = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        giftCountText.text = playerController.instance.countGiftInMap.ToString();
        if (playerController.instance.countGiftInMap == 1)
        {
            giftCountText.color = new Color(126f, 100f, 100f, 100f);
        }
        coinsCountText.text = playerController.instance.countCoinsInMap.ToString();
        if (playerController.instance.countCoinsInMap == 251)
        {
            coinsCountText.color = new Color(126f, 100f, 100f, 100f);
        }
        if (playerController.instance.randomGiftNumber != 0) {
            for (i = 0; i < playerController.instance.randomGiftNumber; i++) { 
                giftValueText.text = "+ " + i + " from gift.";
            }
            
        }
    }
}
