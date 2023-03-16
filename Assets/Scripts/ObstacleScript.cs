using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public float speed = 2f;
    public float timer;
    public float timeToTurn = 3f;
    

    // Start is called before the first frame update
    void Start()
    {
        /*
        int dir = Random.Range(0, 2);
        
        if(dir == 0)
        {
            speed = -speed;
            //transform.position = new Vector3(transform.position.x+2, transform.position.y, transform.position.z);
        }

        else
        {
            speed = speed;
            //transform.position = new Vector3(transform.position.x-2, transform.position.y, transform.position.z);
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position = transform.position + Vector3.right * speed * Time.deltaTime;

        // Use this if you want obstacles to change direction with timer
        /*
        if(timer > timeToTurn)
        {
            speed = -speed;
            timer = 0f;
        }
        */
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("AsteroidArea"))
        {
            speed = -speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            speed = -speed;
        }
    }
}
