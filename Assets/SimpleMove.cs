using UnityEngine;
using System.Collections;

public class SimpleMove : MonoBehaviour
{
    Vector3 position;

    void Awake ()
    {
        position = transform.position;
    }

    void Update ()
    {
        transform.position = position + Vector3.forward * Mathf.Sin (Time.time * 0.9f) * 3.0f;
    }
}
