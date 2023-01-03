using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Searcher.SearcherWindow.Alignment;
using static UnityEngine.ParticleSystem;

public class Movement : MonoBehaviour
{

    public ParticleSystem _particle;
    public ParticleSystem _particle2;
    public ParticleSystem _particle4;
    public ParticleSystem _particle3;

    Rigidbody _rb;
    float _steer;
    
    float _thrust;
    Vector3 _directVector;
    Vector3 _directRotation;

    [SerializeField] float _thrustMultiplier = 50.0f;
    [SerializeField] float _steerSensitivity = 1f;


    // Start is called before the first frame update
    void Start()
    {
        _rb= GetComponent<Rigidbody>();
    
    }

    void ActivateParticles()
    {
        if (!_particle.isPlaying)
        { 
        _particle.Play();
        _particle2.Play();
        _particle3.Play();
        _particle4.Play();
    }
    }

    void DeactivateParticles()
    {
        _particle.Stop();
        _particle2.Stop();
        _particle3.Stop();
        _particle4.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        _steer = Input.GetAxis("Horizontal");
        _thrust = Input.GetAxis("Vertical");


        if (_thrust > 0)
        {
            _rb.AddRelativeForce(_directVector = new Vector3(0, _thrust * _thrustMultiplier, 0));
            _rb.AddRelativeTorque(_directRotation = new Vector3(0, 0, _steer * (-_steerSensitivity)));
            ActivateParticles();
        }

        else if (_steer != 0)
        {
            _rb.AddRelativeForce(_directVector = new Vector3(0, _thrust * _thrustMultiplier, 0));
            _rb.AddRelativeTorque(_directRotation = new Vector3(0, 0, _steer * (-_steerSensitivity)));
        }

        else
        {
            DeactivateParticles();
        }
        

        //if (_steer > 0)
       // {
       //     transform.rotate(0, 3, 0);
      //  }


        Debug.Log(_thrust);

    }


}