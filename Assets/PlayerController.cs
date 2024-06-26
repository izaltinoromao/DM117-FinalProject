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
    bool isJumping;
    bool isRunning;

    public GameObject aimCamera;
    public GameObject gunPoint;
    public GameObject bullet;
    public AudioSource shootAudio;

    private void Start()
    {
        rigidbody = GetComponentInChildren<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        shootAudio = GetComponentInChildren<AudioSource>();
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

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= 2;
            isRunning = true;
            animator.SetBool("isRunning", true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= 2;
            isRunning = false;
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            onGround = false;
            isJumping = true;
            animator.SetTrigger("jumped");
        }

        if (Input.GetMouseButton(1) && !isRunning)
        {
            aimCamera.SetActive(true);
            animator.SetBool("isAiming", true);

            if (Input.GetMouseButtonUp(0))
            {
                GameObject bulletTemp = Instantiate(bullet, gunPoint.transform.position, gunPoint.transform.rotation);
                shootAudio.Play();
                Destroy(bulletTemp, 3f);
            }
        }
        else
        {
            aimCamera.SetActive(false);
            animator.SetBool("isAiming", false);
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

        if (isJumping)
        {
            rigidbody.AddForce(Vector3.up * speed);
        }
    }

    void DetectGround()
    {
        RaycastHit hit;
        if(Physics.Raycast(this.transform.position, Vector3.down, out hit, 0.3f))
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
            isJumping = false;
        }
    }
}
