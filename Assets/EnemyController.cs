using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Animator animator;

    private int count = 0;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            count++;
            Destroy(other.gameObject);
        }

        if (count >= 3)
        {
            animator.SetBool("isDead", true);
            Destroy(this.gameObject, 7f);
        }
    }
}
