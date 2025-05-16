using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulse : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool HardMode;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (HardMode)
        {
            rb.AddForce(transform.right * Random.Range(-0.9f, 1f), ForceMode2D.Impulse);
            HardMode = false;
        }
        if (!HardMode)
        {
            rb.AddForce(transform.right * Random.Range(-0.2f, 0.3f), ForceMode2D.Impulse);
            HardMode = true;
        }
    }
}
