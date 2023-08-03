using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    private int count = 0;

    private void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;

        if (transform.position.x >= 11)
        {
            Debug.Log("11됨");
            count++;
            transform.position = new Vector2(-11, transform.position.y);
            switch (count)
            {
                case 2:
                    transform.position = new Vector2(-11, 3);
                    break;
                case 4:
                    transform.position = new Vector2(-11, 1.5f);
                    break;
                case 6:
                    transform.position = new Vector2(-11, 0f);
                    break;
                case 8:
                    transform.position = new Vector2(-11, -1.5f);
                    break;
                case 10:
                    transform.position = new Vector2(-11, -3);
                    break;
                case 12:
                    transform.position = new Vector2(-11, -4.5f);
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            // 애니메이터 작용
            // 시간 정지
            Destroy(gameObject);
            Debug.Log("---------------Game Over---------------");
        }
    }
}
