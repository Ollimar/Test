using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationExample : MonoBehaviour
{

    public Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Jump"))
        {
            myAnim.SetBool("Boost", true);
        }
        else 
        {
            myAnim.SetBool("Boost", false);
        }
    }
}
