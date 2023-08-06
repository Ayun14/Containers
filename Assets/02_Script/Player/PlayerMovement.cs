using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.5f;
    [SerializeField] private GameObject explosionPrefab;

    private int count = 0;

    private PlayerFire playerFire;

    private void Start()
    {
        playerFire = GetComponent<PlayerFire>();
    }
    private void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;

        if (transform.position.x >= 11)
        {
            playerFire.bulletCount = 3;
            count++;
            transform.position = new Vector2(-11, transform.position.y);
            switch (count)
            {
                case 2:
                    transform.position = new Vector2(-11, 2f);
                    break;
                case 4:
                    transform.position = new Vector2(-11, 0f);
                    break;
                case 6:
                    transform.position = new Vector2(-11, -2f);
                    break;
                case 8:
                    transform.position = new Vector2(-11, -4f);
                    break;
                case 9:
                    SceneManager.LoadScene(2);
                    Debug.Log("----------------Clear----------------");
                    break;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 1f);

            Destroy(gameObject);
            Debug.Log("---------------Game Over---------------");
        }
    }
}
