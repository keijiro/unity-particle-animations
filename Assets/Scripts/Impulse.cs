using UnityEngine;
using System.Collections;

public class Impulse : MonoBehaviour
{
    public float gravity = 8.0f;
    public float random = 10.0f;
    public float bounciness = 0.2f;
    public float knockback = 0.2f;
    public float interval = 3.0f;
    ParticleSystem.Particle[] particles;
    float timer;

    void Start ()
    {
        particles = new ParticleSystem.Particle[particleSystem.maxParticles];
    }

    void Update ()
    {
        var number = particleSystem.GetParticles (particles);

        timer += Time.deltaTime;

        if (timer > interval || Input.GetMouseButtonDown (0))
        {
            for (var i = 0; i < number; i++)
            {
                particles [i].position -= particles [i].velocity * knockback; 
                particles [i].velocity = Random.onUnitSphere * random - particles [i].velocity * bounciness;
            }
            timer = 0.0f;
        }
        else
        {
            for (var i = 0; i < number; i++)
            {
                particles[i].velocity += Vector3.right * gravity * Time.deltaTime;
            }
        }

        particleSystem.SetParticles (particles, number);
    }
}
