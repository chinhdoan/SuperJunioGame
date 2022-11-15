using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class playerController : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    float inputAD;
    public float speed = 8f;
    public float jumpForce = 15f;
    bool isGround;
    int coinNumbers;
    public Text coinNumbersText;
    public int hp;
    public static playerController instance;
    public static bool faceRightDirection = true;
    int characterIndex;

    public int countCoinsInMap;
    public int countGiftInMap;

    //Slider
    public float extraSpeed = 200f;
    /*bool isDashing = false;*/
    public float startDashing = 1f;
    float dashTime;
    public int randomGiftNumber;
    bool moveWhileGetGift;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
        else {

            DontDestroyOnLoad(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {

        coinNumbers = PlayerPrefs.GetInt("coins");
        coinNumbersText.text = coinNumbers.ToString();
        characterIndex = PlayerPrefs.GetInt("characterSelection", 0);
        switch (characterIndex)
        {
            default:
                hp = 3;
                healthPlayer.health = 3;
                PlayerPrefs.SetInt("characterSelection", 0);
                break;
            case (1):

                hp = 5;
                healthPlayer.health = 5;
                PlayerPrefs.SetInt("characterSelection", 1);
                break;
            case (2):

                hp = 8;
                healthPlayer.health = 8;
                PlayerPrefs.SetInt("characterSelection", 2);
                break;
            case (3):

                hp = 10;
                healthPlayer.health = 10;
                PlayerPrefs.SetInt("characterSelection", 3);
                break;

        }
        countCoinsInMap = 0;
        countGiftInMap = 0;
        randomGiftNumber = Random.Range(100, 500);
    }
    private void FixedUpdate()
    {
        inputAD = Input.GetAxisRaw("Horizontal");
        if (inputAD == 0) {
            rb.velocity = new Vector2(inputAD * -speed, rb.velocity.y);
            anim.SetFloat("moveAD", 0f);
        }

        if (inputAD != 0 && moveWhileGetGift == false) {
            if (inputAD > 0)
            {
                faceRightDirection = true;
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }

            if (inputAD < 0)
            {
                faceRightDirection = false;
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
            if (isGround)
            {
                anim.SetFloat("moveAD", Mathf.Abs(inputAD));
            }
            else if (!isGround)
            {
                anim.SetFloat("moveAD", 0f);
                anim.SetBool("isJumpping", true);
            }

            rb.velocity = new Vector2(inputAD * speed, rb.velocity.y);
        }


    }
    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            AudioManager.instance.Play("jumpSound");
            anim.SetBool("isJumpping", true);
            isGround = false;
        }



        //Chracter can Dashing , index = 2 , male character
        if (characterIndex == 2)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) && isGround && playerSlider.instance.isDashing == false)
            {
                speed += extraSpeed;
                playerSlider.instance.isDashing = true;
                dashTime = startDashing;
            }
            if ((dashTime <= 0 && playerSlider.instance.isDashing == true) || (dashTime <= 0 && playerShooting.instance.isDashing == true))
            {
                speed -= extraSpeed;
                playerSlider.instance.isDashing = false;
            }
            else
            {
                dashTime -= Time.deltaTime;
            }
        }

        if (characterIndex == 3)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl) && isGround && playerShooting.instance.isDashing == false)
            {


                speed += extraSpeed;
                playerShooting.instance.isDashing = true;
                dashTime = startDashing;



            }
            if (dashTime <= 0 && playerShooting.instance.isDashing == true)
            {


                speed -= extraSpeed;
                playerShooting.instance.isDashing = false;


            }
            else
            {
                dashTime -= Time.deltaTime;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            isGround = true;
            anim.SetBool("isJumpping", false);
        }
        if (other.gameObject.tag != "ground") {
            isGround = false;
        }
        if (other.gameObject.tag == "deadzone")
        {
            gameManager.instance.activeGameoverPanel();
            Destroy(gameObject);  
        }
        if (other.gameObject.tag == "gift") {
            countGiftInMap ++;
            coinNumbers += randomGiftNumber;
            PlayerPrefs.SetInt("coins", coinNumbers);
            moveWhileGetGift = true;
        }


    }
  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "reward")
        {
            coinNumbers += 1; //tang so tien nhat duoc 1 xu len 9999
            countCoinsInMap++;
            PlayerPrefs.SetInt("coins", coinNumbers);
            coinNumbersText.text = coinNumbers.ToString(); 
            AudioManager.instance.Play("coinPlusSound");
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "obstacle")
        {
            if (healthPlayer.health <= 0 || hp <= 0)
            {
                gameManager.instance.activeGameoverPanel();
                Destroy(gameObject);
            }
            else if (hp > 0)
            {
                hp--;
                StartCoroutine(waitForDamage());
                AudioManager.instance.Play("hurtSound");
            }
           
        }
    }

    public void takeDamage(int enemyDamage) {
        hp -= enemyDamage; //heart value
        healthPlayer.health -= enemyDamage; //heart display
        AudioManager.instance.Play("enemyDamageSound");
        StartCoroutine(waitForDamage());
    }
    IEnumerator waitForDamage() {
        Physics2D.IgnoreLayerCollision(6,7);
        GetComponent<Animator>().SetLayerWeight(1,1);
        yield return new WaitForSeconds(2);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
    void asd() { 
    }
 
}
