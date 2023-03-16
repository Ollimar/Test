using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerScript : MonoBehaviour
{

    private MusicPlayerScript me;

    // Start is called before the first frame update
    void Awake()
    {
        if(me == null)
        {
            me = this;
        }
        else if(me != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
