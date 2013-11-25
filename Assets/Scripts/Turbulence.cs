using UnityEngine;
using System.Collections;

public class Turbulence : MonoBehaviour
{
    ParticleSystem.Particle[] particles;

    void Start ()
    {
        particles = new ParticleSystem.Particle[particleSystem.maxParticles];
    }

    void Update ()
    {
        var number = particleSystem.GetParticles (particles);

        particleSystem.SetParticles (particles, number);
    }
}
