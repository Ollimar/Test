using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTest : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = "pallo";
        transform.position = new Vector3(0.2f, 2.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // This line moves the sphere forward
        // transform.position = transform.position + Vector3.forward * speed * Time.deltaTime;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
