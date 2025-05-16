using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float speed = 5;
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0 , 0 , speed));
    }
}
