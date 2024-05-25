using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int count = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            count++;
        }

        if (count >= 3)
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
