using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    public int bulletCount = 3;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bulletCount <= 0)
            {
                return;
            }
            Instantiate(bullet, transform.position, Quaternion.identity);
            bulletCount--;
        }
    }
}
