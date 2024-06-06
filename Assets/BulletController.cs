using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    float speed = 0.5f;

    void Update()
    {
        transform.position += transform.forward * speed;
    }

}
