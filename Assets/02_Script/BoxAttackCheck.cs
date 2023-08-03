using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAttackCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            // 스케일 값 조절하기
        }
    }
}
