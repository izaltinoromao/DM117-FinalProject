using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform playerTrasnform
        ;

    Vector3 offset;

    private void Start()
    {
        offset = playerTrasnform.position - transform.position;
    }

    private void Update()
    {
        transform.position = playerTrasnform.position - offset;
    }
}
