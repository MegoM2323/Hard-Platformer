using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public float offset = 0.4f;
    public GameObject targetObj;
    private Transform target;
    void Start()
    {
        target = targetObj.GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y - offset , -500f);
    }
}
