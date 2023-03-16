using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioExample : MonoBehaviour
{

    public AudioSource myAudio;

    public float minVolume = 0.1f;
    public float maxVolume = 1f;
    public float soundTransitionTime = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        myAudio.volume = minVolume;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Jump"))
        {
            myAudio.volume = Mathf.Lerp(myAudio.volume, maxVolume, soundTransitionTime*Time.deltaTime);
        }

        else 
        {
            myAudio.volume = Mathf.Lerp(myAudio.volume, minVolume, soundTransitionTime * Time.deltaTime);
        }
    }
}
