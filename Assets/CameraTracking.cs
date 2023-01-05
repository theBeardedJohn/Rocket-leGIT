using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraTracking : MonoBehaviour
{
    public Transform _rocket;
    public Vector3 _cameraOffset;
    private Vector3 _cameraOffMove;
    public Vector3 _cameraOffsetZ;
   
    public float _zoomZ;
    public float _speedZMultip;

    private Vector3 _currVel;


    public float _speedZ;
    public float _speed;
    public float UpdateDelay;
    public float _speedZoomLimit;


  

    void Start()
    {
        _speed= 0f;
        _speedZMultip = 1;
        _speedZ = 1f;
        StartCoroutine(SpeedReckoner());

    }
    // metoda na v�po�et SPEED
    private IEnumerator SpeedReckoner()
    {

        YieldInstruction timedWait = new WaitForSeconds(UpdateDelay);
        Vector3 lastPosition = transform.position;
        float lastTimestamp = Time.time;

        while (enabled)
        {
            yield return timedWait;

            var deltaPosition = (transform.position - lastPosition).magnitude;
            var deltaTime = Time.time - lastTimestamp;

            if (Mathf.Approximately(deltaPosition, 0f)) // Clean up "near-zero" displacement
                deltaPosition = 0f;

            _speed = deltaPosition / deltaTime;


            lastPosition = transform.position;
            lastTimestamp = Time.time;
        }
    }

    void Update()
    {
        if (_speed > _speedZoomLimit) 
        {
            _speedZ = (17f - Mathf.Abs(_speed));
        
        }





        //_speedZ = (Mathf.Abs( _currVel.x)+ Mathf.Abs( _currVel.z)+ Mathf.Abs( _currVel.y)) * _speedZMultip;
        _zoomZ = Mathf.Clamp(_speedZ, -7f, 17f);
        _cameraOffsetZ = new Vector3(0, 0, 0);
        //_cameraOffsetZ = new Vector3(0, 0, _zoomZ);
        
        _cameraOffMove = _cameraOffset - _cameraOffsetZ;
        
        transform.position = _rocket.position + _cameraOffMove;

        //Debug.Log("rychlost _speedz" + _speedZ);
        Debug.Log("rychlost speed" + _currVel);
    }
}
