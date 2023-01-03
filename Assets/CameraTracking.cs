using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraTracking : MonoBehaviour
{
    public Transform _rocket;
    public Vector3 _cameraOffset;
  

    void Update()
    {
        
        
        transform.position = _rocket.position + _cameraOffset;


    }
}
