using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private int sceneIndex;
    private int LoaderToInt;
    public GameObject MenuObj;
    private bool Click = true;

    public GameObject LoadingScreenObj;

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (PlayerPrefs.HasKey("LevelComplete"))
        {
            LoaderToInt = PlayerPrefs.GetInt("LevelComplete");
        }
        else if (!PlayerPrefs.HasKey("LevelComplete"))
        {
            LoaderToInt = 1;
        }
    }
    public void ButtonPlay()
    {
        if(LoaderToInt < 9)
        {
            SceneManager.LoadScene(LoaderToInt + 1);
        }
        else if(LoaderToInt >= 9)
        {
            SceneManager.LoadScene(LoaderToInt);
        }
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Retry()
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void Next()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }
    public void Levels()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadingScreen()
    {
        LoadingScreenObj.SetActive(true);
    }

    public void MenuOnClick()
    {
        if(Click == true)
        {
            MenuObj.SetActive(true);
            Click = false;
        }
        else if (Click == false)
        {
            MenuObj.SetActive(false);
            Click = true;
        }
    }

    public void LoadToSceneInt(int IntLevel)
    {
        SceneManager.LoadScene(IntLevel);
    }

    public void YouTubeButton()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCU2XY0Q1jnLs7WmqdTEzv2Q");
    }
    public void VKButton()
    {
        Application.OpenURL("https://vk.com/public197254415");
    }
}
