using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float DestroyPosition;

    private void FixedUpdate()
    {
        if(transform.position.y <= DestroyPosition)
        {
            Destroy(gameObject);
        }
    }
}
