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
    //float _inHorizontal;
    
    float _thrust;
    

    [SerializeField] float _thrustMultiplier = 50.0f;
    //[SerializeField] float _horizontalSensitivity = 1f;


    // Start is called before the first frame update
    void Start()
    {
        _rb= GetComponent<Rigidbody>();
    
    }

    void ActivateParticles()
    {
        _particle.Play();
        _particle2.Play();
        _particle3.Play();
        _particle4.Play();



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
        //_inHorizontal = Input.GetAxis("Horizontal");
        _thrust = Input.GetAxis("Vertical");


        if (_thrust > 0 && !_particle.isPlaying)
        {
            _rb.AddForce(new Vector3(0, _thrust * _thrustMultiplier, 0));
            ActivateParticles();
        }

        else if (_thrust > 0 )
        {
            _rb.AddForce(new Vector3(0, _thrust * _thrustMultiplier, 0));
           
        }




        else if (_thrust < 0)
        {
            
            ActivateParticles();
        }

        else if (_thrust == 0 )
        {
            DeactivateParticles();
        }
        

        Debug.Log(_thrust);

    }


}