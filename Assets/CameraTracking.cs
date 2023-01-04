using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraTracking : MonoBehaviour
{
    public Transform _rocket;
    public Vector3 _cameraOffset;
    private Vector3 _cameraOffMove;
    private Vector3 _cameraOffsetZ;
    float _speedZ;
    float _zoomZ;
    public float _speedZMultip;

    private Vector3 _prevPos;
    private Vector3 _currVel;

        void Start()
    {

        StartCoroutine(CalcVelocity());

    }

    IEnumerator CalcVelocity()
    {
        while (Application.isPlaying)
        {
            // Position at frame start
            _prevPos = transform.position;
            // Wait till it the end of the frame
            yield return new WaitForEndOfFrame();
            // Calculate velocity: Velocity = DeltaPosition / DeltaTime
            _currVel = (_prevPos - transform.position);
            // _currVel = _prevPos - transform.position;
            

        }
    }

    void Update()
    {
        
        _speedZ = (Mathf.Abs( _currVel.x)+ Mathf.Abs( _currVel.z)+ Mathf.Abs( _currVel.y)) * _speedZMultip;
        _zoomZ = Mathf.Clamp(_speedZ, -24f, -40f);
        _cameraOffsetZ = new Vector3 (0, 0, _zoomZ);
;
        _cameraOffMove = _cameraOffset + _cameraOffsetZ;
        
        transform.position = _rocket.position + _cameraOffMove;

        Debug.Log("rychlost _speedz" + _speedZ);

    }
}
