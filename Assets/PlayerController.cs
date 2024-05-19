using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float angleSpeed;

    float moveX, moveZ;
    Rigidbody rigidbody;
    Animator animator;

    bool onGround;

    private void Start()
    {
        rigidbody = GetComponentInChildren<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        if (moveZ != 0)
        {
            animator.SetBool("isWalking", true);
        } else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void FixedUpdate()
    {
        DetectGround();
        MovePlayer();
    }

    void MovePlayer()
    {
        if (!onGround) return;

        rigidbody.velocity = transform.forward * moveZ * speed;

        rigidbody.MoveRotation(rigidbody.rotation
            * Quaternion.Euler(0f, angleSpeed * moveX, 0f));
    }

    void DetectGround()
    {
        RaycastHit hit;
        if(Physics.Raycast(this.transform.position, Vector3.down, out hit, 1.3f))
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 1.3f);
    }
}
