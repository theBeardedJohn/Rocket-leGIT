using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{

    public Transform _rocket;
    public float _cameraZoom;
    [SerializeField] float _cameraZoomSensitivity;
    private float _cameraZoomVectorZ; // hodnota Z vektoru pro _cameraZoomVectorZ
    private Vector3 _cameraZoomVector; // plovoucí vector3 hodnota pricitana k offsetu
    [SerializeField] Vector3 _cameraOffset; // preddefinovany offset pozice (vector3) camery




    //pristup k _speed z jineho scriptu
    public GameObject _rocketEmpty; //definované PUBLIC pole pro pøiøazení GameObjektu 
    private Movement _movementScript;
    public float _localSpeed;
    public float _speed;
    //pristup k _speed z jineho scriptu
    



    void Start()
    {
        _cameraZoomSensitivity = 3f;
        _movementScript = _rocketEmpty.GetComponent<Movement>();

        _cameraOffset = new Vector3(0, 4, -15);
        _cameraZoom = -1;
      

    }
   
    void Update()
    {



        _localSpeed = _movementScript._speed;

        if (_localSpeed < 10)
        {
            _cameraZoom += (_cameraZoomSensitivity/100);
            _cameraZoom = Mathf.Clamp(_cameraZoom, -20, 0);
        }

        else
        {
            _cameraZoom -= (_cameraZoomSensitivity / 100);
            _cameraZoom = Mathf.Clamp(_cameraZoom, -20, 0);
        }



        _cameraZoomVectorZ = _cameraZoom;
        _cameraZoomVector = new Vector3 (0, 0, _cameraZoomVectorZ);
        transform.position = _rocket.position + _cameraOffset + _cameraZoomVector;

    }
}
