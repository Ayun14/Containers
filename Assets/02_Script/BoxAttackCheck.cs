using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAttackCheck : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 0.9f);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
