using UnityEngine;
using System.Collections;

public class ExternalControl : MonoBehaviour
{
    public float acceleration = 5.0f;
    public float decay = 0.99f;
    public float impulse = 5.0f;
    public float impulseInterval = 3.0f;
    ParticleSystem.Particle[] particles;
    float timer;

    void Start ()
    {
        particles = new ParticleSystem.Particle[particleSystem.maxParticles];
    }

    void Update ()
    {
        var number = particleSystem.GetParticles (particles);

        if (Input.GetMouseButtonDown (0) || timer > impulseInterval)
        {
            for (var i = 0; i < number; i++)
            {
                var position = particles [i].position;
                particles [i].velocity += (position.normalized + Random.insideUnitSphere) * impulse;
            }
            timer = 0.0f;
        }
        else
        {
            timer += Time.deltaTime;
        }

        for (var i = 0; i < number; i++)
        {
            var position = particles [i].position;

            particles [i].velocity += position * -acceleration;
            particles [i].velocity *= decay;
        }

        particleSystem.SetParticles (particles, number);
    
    }
}
