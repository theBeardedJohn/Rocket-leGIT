using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;

public class Aim : MonoBehaviour
{

    public GameObject _rocketEmpty;
    public Movement _movementScript;

    
    float rotationZ;
    float rocketRotationZ;
    bool fixedAim;
   
    [SerializeField] float aimSensitivity;



    private void Start()
    {
    fixedAim = false;
    _movementScript = _rocketEmpty.GetComponent<Movement>();



    }





    // Update is called once per frame

   

    void FixedUpdate()
    {
       rocketRotationZ = _movementScript.angleZ;


        


        if (Input.GetKey("p"))
        {
            fixedAim = !fixedAim;

            
        }  


       if (fixedAim = true && Input.GetKey("j"))
        {
            rotationZ += aimSensitivity;
            
        }

        else if (fixedAim = true && Input.GetKey("l"))
        {
            rotationZ -= aimSensitivity;
            
        }


        if (fixedAim = false && Input.GetKey("j"))
        {
            rotationZ += aimSensitivity + (rocketRotationZ*100f);

        }

        else if (fixedAim = false && Input.GetKey("l"))
        {
            rotationZ -= aimSensitivity + (rocketRotationZ*100f);

        }

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);



       Debug.Log(rocketRotationZ);
        Debug.Log(fixedAim);









    }
}

// ve  void FixedUpdate()
//Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition); //- transform.position;
//difference.Normalize();
//float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
//transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);