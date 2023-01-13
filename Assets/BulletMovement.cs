using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BulletMovement : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody rb;
    Vector3 rocketMovement;

    void Start()
    {
        rocketMovement = Movement.velocityStat;
        rb.AddForce(new Vector3 (rocketMovement.x, rocketMovement.y , rocketMovement.z) * 50f);
        rb.AddRelativeForce(new Vector3 ( 0f, bulletSpeed ,0f ));

    }
    private void OnCollisionEnter(Collision assCollision)
    {
        if (assCollision.gameObject.tag == "Ass")
        {

            
            Destroy(this.gameObject);


        }


    }

    private void Update()
    {
        Destroy(this.gameObject, 5);


        Debug.Log(rocketMovement);
    }

}