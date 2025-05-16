using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private int sceneIndex;
    public GameObject[] Fruits;
    private SpriteRenderer SP;
    private int AdsCount = 0;

    public GameObject TimerCase;

    public GameObject timick_1;
    public GameObject timick_2;
    public GameObject timick_3;
    public GameObject timick_4;
    public GameObject timick_5;
    public GameObject timick_6;
    public GameObject timick_7;

    private float Timerclock;//время 1 полочки
    private float TimerclockRepository;
    private float TimerAll = 8f;

    public GameObject PauseMenu;
    public GameObject LevelUpPanel;
    public GameObject ContinionButton;
    public GameObject PauseBotton;

    public GameObject GameOverMenu;
    public GameObject Controller;

    public float speed = 5f;
    public float JumpForce = 8f;

    private bool Ground = false;

    public Joystick joystick;
    private Rigidbody2D rb;
    private Animator animator;
    private AudioSource AudioSource;

    public Sprite UpSprite;
    public Sprite DownSprite;
    public AudioClip JumpClip;
    public AudioClip DimondClip;
    public AudioClip Coin_Fruit;
    public GameObject GameOverSound; 

    private int Dimond;

    private void Awake()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        switch (PlayerPrefs.GetInt("Argument"))
        {
            case 2:
                TimerclockRepository = 3.15f;
                Timerclock = TimerclockRepository;
                break;
            case 3:
                TimerclockRepository = 2.5f;
                Timerclock = TimerclockRepository;
                break;
            default:
                break;
        }
        if (PlayerPrefs.HasKey("AdsCount"))
        {
            AdsCount = PlayerPrefs.GetInt("AdsCount");
        }
        else if (!PlayerPrefs.HasKey("AdsCount"))
        {
            AdsCount = 0;
        }

        if(AdsCount > 4)
        {
            AdsCount = 3; 
        }

        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("3888273", false);
        }
        if(PlayerPrefs.GetInt("Argument") == 1)
        {
            for (int i = 0; i < Fruits.Length; i++)
            {
                Destroy(Fruits[i]);
            }
        }
    }
    public void Start()
    {
        AnaliticsLevelStarted(sceneIndex , PlayerPrefs.GetInt("Argument"));
        SP = GetComponent <SpriteRenderer>();
        AudioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Dimond = 0;
    }
    void FixedUpdate()
    {
        if (Dimond >= 3)
        {
            LevelUpPanel.SetActive(true);
        }
        if(PlayerPrefs.GetInt("Argument") == 1)
        {
            TimerCase.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Argument") == 2 || PlayerPrefs.GetInt("Argument") == 3)
        {

            Timerclock = Timerclock - 1 * Time.deltaTime;
            if (Timerclock <= 0)
            {
                Timerclock = TimerclockRepository;
                TimerAll--;
                switch (TimerAll)
                {
                    case 1:
                        timick_1.SetActive(false);
                        break;
                    case 2:
                        timick_2.SetActive(false);
                        break;
                    case 3:
                        timick_3.SetActive(false);
                        break;
                    case 4:
                        timick_4.SetActive(false);
                        break;
                    case 5:
                        timick_5.SetActive(false);
                        break;
                    case 6:
                        timick_6.SetActive(false);
                        break;
                    case 7:
                        timick_7.SetActive(false);
                        break;
                }/*
            if (TimerAll == 7)
            {
                timick_7.SetActive(false);
            }
            if (TimerAll == 6)
            {
                timick_6.SetActive(false);
            }
            if (TimerAll == 5)
            {
                timick_5.SetActive(false);
            }
            else if (TimerAll == 4)
            {
                timick_4.SetActive(false);
            }
            else if (TimerAll == 3)
            {
                timick_3.SetActive(false);
            }
            else if (TimerAll == 2)
            {
                timick_2.SetActive(false);
            }
            else if (TimerAll == 1)
            {
                timick_1.SetActive(false);
            }*/
            }
            if (TimerAll == 1)
            {
                Die();
            }
        }

        float OneAndZeroHor_1 = Input.GetAxisRaw("Horizontal"); // PC controller
        Vector2 hor_1 = new Vector2(OneAndZeroHor_1 , 0);
        transform.Translate(hor_1.normalized * speed * Time.deltaTime);

        float OneAndZeroHor = joystick.Horizontal; //Mobile controller
        Vector2 hor = new Vector2(OneAndZeroHor, 0);
        transform.Translate(hor.normalized * speed * Time.deltaTime);


        if (OneAndZeroHor > 0f)
        {
            SP.flipX = true;
        }
        else if (OneAndZeroHor < 0f)
        {
            SP.flipX = false;
        }

        if (OneAndZeroHor != 0 && Ground == true)
        {
            animator.SetBool("IsRuning", true);
        }
        else
        {
            animator.SetBool("IsRuning", false);
        }

    }

    public void jump()
    {
        if (Ground == true)
        {
            animator.SetBool("jump", true);
            AudioSource.PlayOneShot(JumpClip);
            rb.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
            Ground = false;
        }

    }

    public void PauseMenuFun()
    {
        PauseMenu.SetActive(true);
        Controller.SetActive(false);
        gameObject.SetActive(false);
        ContinionButton.SetActive(true);
        PauseBotton.SetActive(false);
    }
    public void ContinionFun()
    {
        PauseMenu.SetActive(false);
        Controller.SetActive(true);
        gameObject.SetActive(true);
        PauseBotton.SetActive(true);
        ContinionButton.SetActive(false);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("jump", false);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("Fruit"))
        {
            Fruit(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
        }
        if (collision.gameObject.CompareTag("Fruit"))
        {
            Fruit(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Level_up"))
        {
            AudioSource.PlayOneShot(DimondClip);
            Dimond++;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Ground = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Ground = false;
        }
    }

    private void Die()
    {
        AnaliticsPlayerDead(sceneIndex , PlayerPrefs.GetInt("Argument"));
        Instantiate(GameOverSound, new Vector3(0, 0, 0), Quaternion.identity);
        Handheld.Vibrate();
        if (AdsCount == 4 && Advertisement.IsReady())
        {
            Advertisement.Show("video");
            AdsCount = 0;
            PlayerPrefs.SetInt("AdsCount", AdsCount);
        }
        AdsCount++;
        PlayerPrefs.SetInt("AdsCount", AdsCount);
        Dimond = 0;
        PauseBotton.SetActive(false);
        GameOverMenu.SetActive(true);
        Controller.SetActive(false);
        gameObject.SetActive(false);
    }

    private void Fruit(GameObject collision)
    {
        AudioSource.PlayOneShot(Coin_Fruit);
        TimerAll = 8;
        Destroy(collision);
        timick_1.SetActive(true);
        timick_2.SetActive(true);
        timick_3.SetActive(true);
        timick_4.SetActive(true);
        timick_5.SetActive(true);
        timick_6.SetActive(true);
        timick_7.SetActive(true);
    }

    public void AnaliticsPlayerDead(int levelInt , int GameMode)
    {
        if(GameMode == 1)
        {
            Analytics.CustomEvent(customEventName: "PlayerDeadModa_1", new Dictionary<string, object>()
            {
                {"Level" , levelInt},
            });
        }
        else if (GameMode == 2)
        {
            Analytics.CustomEvent(customEventName: "PlayerDeadModa_2", new Dictionary<string, object>()
            {
                {"Level" , levelInt},
            });
        }
        else if (GameMode == 3)
        {
            Analytics.CustomEvent(customEventName: "PlayerDeadModa_3", new Dictionary<string, object>()
            {
                {"Level" , levelInt},
            });
        }
    }
    public void AnaliticsLevelStarted(int levelInt , int GameMode)
    {
        if (GameMode == 1)
        {
            Analytics.CustomEvent(customEventName: "LevelStartedMode_1", new Dictionary<string, object>()
            {
                {"Level" , levelInt},
            });
        }
        else if (GameMode == 2)
        {
            Analytics.CustomEvent(customEventName: "LevelStartedMode_2", new Dictionary<string, object>()
            {
                {"Level" , levelInt},
            });
        }
        else if (GameMode == 3)
        {
            Analytics.CustomEvent(customEventName: "LevelStartedMode_3", new Dictionary<string, object>()
            {
                {"Level" , levelInt},
            });
        }
    }

}
