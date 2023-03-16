using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerExample : MonoBehaviour
{
    public GameObject obstacle;

    public float spawnTimer = 3;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(obstacle, transform.position, transform.rotation);
        // Use this to make object spawning repeating
        //Invoke("Spawn", 3);       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        Instantiate(obstacle, transform.position, transform.rotation);
        spawnTimer = Random.Range(3, 10);
        Invoke("Spawn", spawnTimer);
    }
}
