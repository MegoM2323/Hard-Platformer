using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUpPanel : MonoBehaviour
{
    public GameObject WinnerMenu;
    public GameObject Player;
    public GameObject PauseBotton;
    public GameObject Controller;

    static private int sceneIndex;

    static private int LevelCompleteBlock_1;
    static private int LevelCompleteBlock_2;
    static private int LevelCompleteBlock_3;

    private AudioSource AudioSource;
    public AudioClip WinClip;

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (PlayerPrefs.HasKey("LevelCompleteBlock_1"))
        {
            LevelCompleteBlock_1 = PlayerPrefs.GetInt("LevelCompleteBlock_1");
        }
        else if (!PlayerPrefs.HasKey("LevelCompleteBlock_1"))
        {
            LevelCompleteBlock_1 = 1;
        }
        if (PlayerPrefs.HasKey("LevelCompleteBlock_2"))
        {
            LevelCompleteBlock_2 = PlayerPrefs.GetInt("LevelCompleteBlock_2");
        }
        else if (!PlayerPrefs.HasKey("LevelCompleteBlock_2"))
        {
            LevelCompleteBlock_2 = 1;
        }
        if (PlayerPrefs.HasKey("LevelCompleteBlock_3"))
        {
            LevelCompleteBlock_3 = PlayerPrefs.GetInt("LevelCompleteBlock_3");
        }
        else if (!PlayerPrefs.HasKey("LevelCompleteBlock_3"))
        {
            LevelCompleteBlock_3 = 1;
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayOneShot(WinClip);
            WinnerMenu.SetActive(true);
            Player.SetActive(false);
            PauseBotton.SetActive(false);
            switch (PlayerPrefs.GetInt("Argument"))
            {
                case 1:
                    if (sceneIndex > LevelCompleteBlock_1)
                    {
                        PlayerPrefs.SetInt("LevelCompleteBlock_" + PlayerPrefs.GetInt("Argument"), sceneIndex);
                    }
                    break;
                case 2:
                    if (sceneIndex > LevelCompleteBlock_2)
                    {
                        PlayerPrefs.SetInt("LevelCompleteBlock_" + PlayerPrefs.GetInt("Argument"), sceneIndex);
                    }
                    break;
                case 3:
                    if (sceneIndex > LevelCompleteBlock_3)
                    {
                        PlayerPrefs.SetInt("LevelCompleteBlock_" + PlayerPrefs.GetInt("Argument"), sceneIndex);
                    }
                    break;
                default:
                    if (sceneIndex > LevelCompleteBlock_1)
                    {
                        PlayerPrefs.SetInt("LevelCompleteBlock_" + PlayerPrefs.GetInt("Argument"), sceneIndex);
                    }
                    break;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayOneShot(WinClip);
            WinnerMenu.SetActive(true);
            Player.SetActive(false);
            PauseBotton.SetActive(false);
            Controller.SetActive(false);
            switch (PlayerPrefs.GetInt("Argument"))
            {
                case 1:
                    if (sceneIndex > LevelCompleteBlock_1)
                    {
                        PlayerPrefs.SetInt("LevelCompleteBlock_" + PlayerPrefs.GetInt("Argument"), sceneIndex);
                    }
                    break;
                case 2:
                    if (sceneIndex > LevelCompleteBlock_2)
                    {
                        PlayerPrefs.SetInt("LevelCompleteBlock_" + PlayerPrefs.GetInt("Argument"), sceneIndex);
                    }
                    break;
                case 3:
                    if (sceneIndex > LevelCompleteBlock_3)
                    {
                        PlayerPrefs.SetInt("LevelCompleteBlock_" + PlayerPrefs.GetInt("Argument"), sceneIndex);
                    }
                    break;
                default:
                    if (sceneIndex > LevelCompleteBlock_1)
                    {
                        PlayerPrefs.SetInt("LevelCompleteBlock_" + PlayerPrefs.GetInt("Argument"), sceneIndex);
                    }
                    break;
            }

        }
    }
}
