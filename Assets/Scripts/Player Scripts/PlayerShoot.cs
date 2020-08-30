using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject fireBullet;

   void Update()
    {
        ShootBullet();
    }
    void ShootBullet()
    {
        if (Input.GetKeyDown(KeyCode.X)){
            GameObject bullet = Instantiate(fireBullet, transform.position, Quaternion.identity);
            bullet.GetComponent<FireBullet>().Speed *= transform.localScale.x;
        }
    }

}// class
