using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;

public class Aim : MonoBehaviour
{



    float rotationZ;
   
    

    bool fixedAim;
    [SerializeField] float aimSensitivity;
    [SerializeField] float fixedRotationZ;


    private void Start()
    {
        fixedRotationZ = 1f;
       
    }

    public void FixBool(bool sw)
    {
        fixedAim = sw;

    }


    // pøepínaè FixedAim true/false
    void FixedAimChecker()
    {
    
        if (Input.GetKey("p"))
        {
            fixedAim = !fixedAim;
        }

    }

    void FixedAimOff()
    {
        if (Input.GetKey("j"))
        {
            rotationZ += aimSensitivity;

        }

        else if (Input.GetKey("l"))
        {
            rotationZ -= aimSensitivity;

        }

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }
    void FixedAimOn()
    {
        if (Input.GetKey("j"))
        {
            transform.Rotate(0f, 0f, +(fixedRotationZ * aimSensitivity));

        }

        else if (Input.GetKey("l"))
        {
            transform.Rotate(0f, 0f, -(fixedRotationZ * aimSensitivity));

        }

        
    }


    private void Update()
    {
       FixedAimChecker(); 
    }

    void FixedUpdate()
    {
       

        

        if (fixedAim == true)
        {
            FixedAimOn();
        }

        else if (fixedAim == false)
        {
            FixedAimOff();

        }


        

      
       









    }
}

// ve  void FixedUpdate()
//Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition); //- transform.position;
//difference.Normalize();
//float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
//transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);