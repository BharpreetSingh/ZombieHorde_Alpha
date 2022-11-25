using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed;
    public GameObject Gun;

    private void Start()
    {
        transform.position = Gun.transform.position;
        transform.parent = null;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
        Destroy(this, 2f);
    }
}
