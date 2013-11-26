using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour
{
    public GameObject prefab;
    public float velocity = 5.0f;
    public float rate = 20.0f;
    public float radius = 2.0f;
    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        while (timer > 0)
        {
            var position = transform.position + Random.insideUnitSphere * radius;
            var go = Instantiate (prefab, position, Random.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = transform.forward * velocity;
            timer -= 1.0f / rate;
        }
    }
}
