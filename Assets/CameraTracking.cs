using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{

    public Transform _rocket;
    public float _cameraZoom;

    private float _cameraZoomVectorZ; // hodnota Z vektoru pro _cameraZoomVectorZ
    private Vector3 _cameraZoomVector; // plovoucí vector3 hodnota pricitana k offsetu
    [SerializeField] Vector3 _cameraOffset; // preddefinovany offset pozice (vector3) camery
    public float _speed;

   
    
    void Start()
    {
        _cameraOffset = new Vector3(0, 4, -15);
        _cameraZoom = 1;
    
    }
   
    void Update()
    {




        _cameraZoomVectorZ = Mathf.Clamp(_cameraZoom, 0, 15);
        _cameraZoomVector = new Vector3 (0, 0, _cameraZoomVectorZ);
        transform.position = _rocket.position + _cameraOffset + _cameraZoomVector;

        Debug.Log("rychlost speed" + _speed);
    }
}
