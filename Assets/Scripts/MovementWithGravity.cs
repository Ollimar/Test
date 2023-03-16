using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWithGravity : MonoBehaviour
{
    public Rigidbody myRB;
    public float speed = 5;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {   
            myRB.AddForce(Vector3.up * speed);
        }
    }

    private void FixedUpdate()
    {
        myRB.velocity = Vector3.up * speed;
    }
}
