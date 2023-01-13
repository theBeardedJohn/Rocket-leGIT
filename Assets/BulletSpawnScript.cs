using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;


    void Update()
    {

        if (Input.GetKeyDown("i"))
        {

            Shoot();
        
        
        }


    }

    void Shoot()
    {
        
        Instantiate(bullet, firePoint.position, firePoint.rotation);


    }




}
