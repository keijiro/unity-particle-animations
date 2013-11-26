using UnityEngine;
using System.Collections;

public class AutoDestructor : MonoBehaviour
{
    public float boundary = 100.0f;
    public float time = 5.0f;

    void Start ()
    {
        boundary *= boundary;
    }

    void Update ()
    {
        time -= Time.deltaTime;

        if (time < 0.0f || transform.position.sqrMagnitude > boundary)
        {
            Destroy (gameObject);
        }
    }
}
