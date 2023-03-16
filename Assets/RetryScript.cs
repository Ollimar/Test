using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryScript : MonoBehaviour
{
    private Animator myAnim;
    private AudioSource myAudio;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponentInParent<Animator>();
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            myAnim.SetTrigger("Clicked");
            myAudio.Play();
            GameObject.Find("GM").GetComponent<GameManager>().Retry();
        }
    }
}
