using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool FaceRight = false;
    public float speed = 3.5f;

    private void FixedUpdate()
    {
        if(FaceRight == true)
        {
            transform.Translate(new Vector2(1 , 0) * speed * Time.deltaTime);
        }
        if (FaceRight == false)
        {
            transform.Translate(new Vector2(1, 0) * -speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("flag_1"))
        {
            flip();
        }
        if (collision.gameObject.CompareTag("flag_2"))
        {
            flip();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("flag_1"))
        {
            flip();
        }
        if (collision.gameObject.CompareTag("flag_2"))
        {
            flip();
        }
    }
    private void flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        FaceRight = !FaceRight;
    }
}
