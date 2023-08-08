using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameManager.Instance.bulletCount <= 0)
            {
                return;
            }
            Instantiate(bullet, transform.position, Quaternion.identity);
            GameManager.Instance.bulletCount--;
            GameManager.Instance.BulletTextUpdate();
        }
    }
}
