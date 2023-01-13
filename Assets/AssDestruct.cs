using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssDestruct : MonoBehaviour
{
    public GameObject assDestro;


    private void OnCollisionEnter(Collision assCollision)
    {
       if (assCollision.gameObject.tag == "Bullet")
       {
     
        Instantiate(assDestro, transform.position, transform.rotation);
        Destroy(gameObject);
            
        

    }      


    }
   
    




}
