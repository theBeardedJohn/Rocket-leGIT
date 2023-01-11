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
    public ParticleSystem _particleR;
    public ParticleSystem _particleL;


    // *** PROMENNE DEFINOVANE SCRIPTEM NA VYPOCET RYCHLOSTI ***   
    public float _speed; // _speed = výsledek metody pro výpoèet rychlosti - volany v jinem scriptu
    public float UpdateDelay; // promìnná pro zpoždìní aktualizace rychlosti
    // *** PROMENNE DEFINOVANE SCRIPTEM NA VYPOCET RYCHLOSTI ***
    public float angleZ;




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
        StartCoroutine(SpeedReckoner());// metoda pro výpoèet _speed
       
    }

    // metoda na výpoèet _speed
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
    // metoda na výpoèet _speed


    void ActivateSteerParticlesR()
    {
        if (!_particleR.isPlaying)
        {
            _particleR.Play();
            
        }
    }

    void ActivateSteerParticlesL()
    {
        if (!_particleL.isPlaying)
        {
            _particleL.Play();

        }
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
        _particleR.Stop();
        _particleL.Stop();
    }




    // Update is called once per frame
    void Update()
    {
        _steer = Input.GetAxis("Horizontal");
        _thrust = Input.GetAxis("Vertical");
        angleZ = transform.rotation.z;

        if (_thrust > 0)
        {
            _rb.AddRelativeForce(_directVector = new Vector3(0, _thrust * _thrustMultiplier, 0));
            _rb.AddRelativeTorque(_directRotation = new Vector3(0, 0, _steer * (-_steerSensitivity)));
            ActivateParticles();
        }

        else if (_steer < 0)
        {
            _rb.AddRelativeForce(_directVector = new Vector3(0, _thrust * _thrustMultiplier, 0));
            _rb.AddRelativeTorque(_directRotation = new Vector3(0, 0, _steer * (-_steerSensitivity)));
            ActivateSteerParticlesR();
        }
        else if (_steer > 0)
        {
            _rb.AddRelativeForce(_directVector = new Vector3(0, _thrust * _thrustMultiplier, 0));
            _rb.AddRelativeTorque(_directRotation = new Vector3(0, 0, _steer * (-_steerSensitivity)));
            ActivateSteerParticlesL();
        }



        else
        {
            DeactivateParticles();
        }
        

        //if (_steer > 0)
       // {
       //     transform.rotate(0, 3, 0);
      //  }


        //Debug.Log(angleZ);

    }


}