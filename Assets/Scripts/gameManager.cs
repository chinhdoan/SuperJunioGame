using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
public class gameManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject settingPanel;
    public GameObject mainMenuPanel;
    public GameObject gameOverPanel;
    public Slider volumeSilder;
    public AudioMixer mixer;
    public static gameManager instance;
    public Button pauseBtn;
    public TextMeshProUGUI levelSelectText;
    public GameObject levelPanel;
    float mixerValue;

    private void Awake()
    {
        if (instance == null) {
            instance = this;
        }
        if (mixerValue != 0)
        {
             mixer.GetFloat("volume", out mixerValue);
             volumeSilder.value = mixerValue;

        }


    }
    public void setVolume() {
        mixer.SetFloat("volume", volumeSilder.value);
    }
    public void activeMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    public void playGame() {
        if (levelSelectText == null)
        {
           
            levelPanel.SetActive(true);
            mainMenuPanel.SetActive(false);
        }
        else { 
          SceneManager.LoadScene("Level" + levelSelectText.text);
        }
       
    }
    public void quitGame() {
        Application.Quit();
    }
    public void reloadGame() {
        /*settingPanel.SetActive(false);*/
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    public void pauseGame() {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    public void resumeGameSetting() {
        Time.timeScale = 1;
        if (settingPanel != null)
        {
          settingPanel.SetActive(false);
        }
        

    }

    public void resumePauseSetting()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);

    }
    public void activeSettingPanel()
    {

        if (pausePanel != null ) { 
            pausePanel.SetActive(false);
        }
        settingPanel.SetActive(true); 
    }
    public void activeGameoverPanel() 
    {
        AudioManager.instance.Play("gameOverSound");
        gameOverPanel.SetActive(true);
        pauseBtn.interactable = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
