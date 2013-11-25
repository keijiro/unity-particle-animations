using UnityEngine;
using System.Collections;

public class Turbulence : MonoBehaviour
{
    public float freq = 0.3f;
    public int octave = 3;
    public float omega = 900.0f;
    public float offset = 4.0f;
    ParticleSystem.Particle[] particles;

    void Start ()
    {
        particles = new ParticleSystem.Particle[particleSystem.maxParticles];
    }

    void Update ()
    {
        var number = particleSystem.GetParticles (particles);

        for (var i = 0; i < number; i++)
        {
//            var particle = particles[i];

            var r1 = Time.deltaTime * omega * Perlin.Fbm(particles[i].position * freq + Vector3.right * offset * Time.time, octave);
            var r2 = Time.deltaTime * omega * Perlin.Fbm(particles[i].position * freq + Vector3.right * offset * Time.time + Vector3.up * 19.333f, octave);

            var r = Quaternion.AngleAxis(r1, Vector3.up) * Quaternion.AngleAxis(r2, Vector3.right);

            particles[i].velocity = r * particles[i].velocity;
        }

        particleSystem.SetParticles (particles, number);
    }
}
