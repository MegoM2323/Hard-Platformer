using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamerBombs : MonoBehaviour
{
    public float flagXOne;
    public float flagXTwo;
    public float flagY;

    public float DimondflagXOne;
    public float DimondflagXTwo; 
    public float DimondflagYOne;
    public float DimondflagYTwo;
    
    public GameObject[] bombs;
    public GameObject[] dimond;
    public GameObject[] Fruit;

    private int StopInt = 0;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Argument") != 1)
        {
            StartCoroutine(Fruits());
        }
        StartCoroutine(spawnBombs());
        StartCoroutine(Dimonds());
    }

    IEnumerator spawnBombs()
    {
        while (true)
        {
            Instantiate(bombs[Random.Range(1, bombs.Length)], new Vector2(Random.Range(flagXOne, flagXTwo), flagY), Quaternion.identity);
            yield return new WaitForSeconds(0.15f);
        }
    }

    IEnumerator Dimonds()
    {
        while (true)
        {
            if (StopInt <= 3)
            {
                Instantiate(dimond[StopInt], new Vector2(Random.Range(DimondflagXOne, DimondflagXTwo), Random.Range(DimondflagYOne, DimondflagYTwo)), Quaternion.identity);
                yield return new WaitForSeconds(13f);
                StopInt++;
            }
            if(StopInt > 3)
            {
                StopCoroutine(Dimonds());
            }
        }
    }
    IEnumerator Fruits()
    {
        while (true)
        {
            Instantiate(Fruit[Random.Range(1, Fruit.Length)], new Vector2(Random.Range(DimondflagXOne, DimondflagXTwo), Random.Range(DimondflagYOne, DimondflagYTwo)), Quaternion.identity);
            yield return new WaitForSeconds(5.5f);
        }
    }
}
