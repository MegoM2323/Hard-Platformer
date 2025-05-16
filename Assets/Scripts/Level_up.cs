 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_up : MonoBehaviour
{
    public GameObject ButtonText;
    private int ActiveBlock = 1; //массив содержит блоки суровнями и их блокировками
    public GameObject[] LevelsBlocks; // Массив содержащий несколько блоков с уровнями
    public GameObject[] LevelsBlock_1;//Это не уровни, а их блокировка.
    public GameObject[] LevelsBlock_2;//Это не уровни, а их блокировка.
    public GameObject[] LevelsBlock_3;//Это не уровни, а их блокировка.
    public GameObject[] LevelsBlockCheckBoxs_1;
    public GameObject[] LevelsBlockCheckBoxs_2;
    public GameObject[] LevelsBlockCheckBoxs_3;
    //public GameObject[] Levels_Lock;

    private int LevelCompleteBlock_1;//Сохраненные значения
    private int LevelCompleteBlock_2;//Сохраненные значения
    private int LevelCompleteBlock_3;//Сохраненные значения
    /*
    public GameObject Level_1_checkbox;
    public GameObject Level_2_checkbox;
    public GameObject Level_3_checkbox;
    public GameObject Level_4_checkbox;
    public GameObject Level_5_checkbox;
    public GameObject Level_6_checkbox;
    public GameObject Level_7_checkbox;
    public GameObject Level_8_checkbox;
    public GameObject Level_9_checkbox;

    public GameObject Level_2_lock;
    public GameObject Level_3_lock;
    public GameObject Level_4_lock;
    public GameObject Level_5_lock;
    public GameObject Level_6_lock;
    public GameObject Level_7_lock;
    public GameObject Level_8_lock;
    public GameObject Level_9_lock;
    */

    private void Awake()
    {
        if (PlayerPrefs.HasKey("ActiveBlock"))
        {
            ActiveBlock = PlayerPrefs.GetInt("ActiveBlock");
        }
        else if (!PlayerPrefs.HasKey("ActiveBlock"))
        {
            ActiveBlock = 1;
        }
    }

    public void CLick()
    {
        if (ActiveBlock == 1)
        {
            ButtonText.GetComponent<UnityEngine.UI.Text>().text = "Normal";
            ActiveBlock = 2;
            LevelsBlocks[0].SetActive(false);
            LevelsBlocks[1].SetActive(false);
            LevelsBlocks[2].SetActive(true);
            LevelsBlocks[3].SetActive(true);
            LevelsBlocks[4].SetActive(false);
            LevelsBlocks[5].SetActive(false);
        }
        else if (ActiveBlock == 2)
        {
            ButtonText.GetComponent<UnityEngine.UI.Text>().text = "Hard";
            ActiveBlock = 3;
            LevelsBlocks[0].SetActive(false);
            LevelsBlocks[1].SetActive(false);
            LevelsBlocks[2].SetActive(false);
            LevelsBlocks[3].SetActive(false);
            LevelsBlocks[4].SetActive(true);
            LevelsBlocks[5].SetActive(true);
        }
        else if (ActiveBlock == 3)
        {
            ButtonText.GetComponent<UnityEngine.UI.Text>().text = "Easy";
            ActiveBlock = 1;
            LevelsBlocks[0].SetActive(true);
            LevelsBlocks[1].SetActive(true);
            LevelsBlocks[2].SetActive(false);
            LevelsBlocks[3].SetActive(false);
            LevelsBlocks[4].SetActive(false);
            LevelsBlocks[5].SetActive(false);
        }
        PlayerPrefs.SetInt("ActiveBlock" , ActiveBlock);
        AfterClick();
    }

    public void TransitionOnLevel(int Argument)
    {
        PlayerPrefs.SetInt("Argument", Argument);
    }
    void Start()
    {
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
        if (ActiveBlock == 2)
        {
            ButtonText.GetComponent<UnityEngine.UI.Text>().text = "Normal";
            LevelsBlocks[0].SetActive(false);
            LevelsBlocks[1].SetActive(false);
            LevelsBlocks[2].SetActive(true);
            LevelsBlocks[3].SetActive(true);
            LevelsBlocks[4].SetActive(false);
            LevelsBlocks[5].SetActive(false);
        }
        else if (ActiveBlock == 3)
        {
            ButtonText.GetComponent<UnityEngine.UI.Text>().text = "Hard";
            LevelsBlocks[0].SetActive(false);
            LevelsBlocks[1].SetActive(false);
            LevelsBlocks[2].SetActive(false);
            LevelsBlocks[3].SetActive(false);
            LevelsBlocks[4].SetActive(true);
            LevelsBlocks[5].SetActive(true);
        }
        else if (ActiveBlock == 1)
        {
            ButtonText.GetComponent<UnityEngine.UI.Text>().text = "Easy";
            LevelsBlocks[0].SetActive(true);
            LevelsBlocks[1].SetActive(true);
            LevelsBlocks[2].SetActive(false);
            LevelsBlocks[3].SetActive(false);
            LevelsBlocks[4].SetActive(false);
            LevelsBlocks[5].SetActive(false);
        }
        AfterClick();
    }

    public void AfterClick()
    {
        if (ActiveBlock == 1)
        {
            // 0 - 8
            for (int i = 0; i < 10; i++)
            {
                if (i > LevelCompleteBlock_1 - 1)
                {
                    LevelsBlock_1[i].SetActive(true);
                    LevelsBlockCheckBoxs_1[i].SetActive(false);
                }
                else if (i < LevelCompleteBlock_1 - 1)
                {
                    LevelsBlockCheckBoxs_1[i].SetActive(true);
                    LevelsBlock_1[i].SetActive(false);
                }
            }
        }
        else if (ActiveBlock == 2)
        {
            // 9 - 17
            for (int i = 0; i < 10; i++)
            {
                if (i > LevelCompleteBlock_2 - 1)
                {
                    LevelsBlock_2[i].SetActive(true);
                    LevelsBlockCheckBoxs_2[i].SetActive(false);
                }
                else if (i < LevelCompleteBlock_2 - 1)
                {
                    LevelsBlockCheckBoxs_2[i].SetActive(true);
                    LevelsBlock_2[i].SetActive(false);
                }
            }
        }
        else if (ActiveBlock == 3)
        {
            // 18 - 26
            for (int i = 0; i < 10; i++)
            {
                if (i > LevelCompleteBlock_3 - 1)
                {
                    LevelsBlock_3[i].SetActive(true);
                    LevelsBlockCheckBoxs_3[i].SetActive(false);
                }
                else if (i < LevelCompleteBlock_3 - 1)
                {
                    LevelsBlockCheckBoxs_3[i].SetActive(true);
                    LevelsBlock_3[i].SetActive(false);
                }
            }
        }
    }
}
