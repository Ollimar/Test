using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    public float speed = 5;
    public float originalSpeed;
    public float boostSpeed = 10f;

    public float distanceTraveled;
    public float startPos;

    public GameObject heightText;

    public ParticleSystem boostEffect;

    public float timer;
    public float startTimer;
    [Range(0.1f,5f)]
    public float igniteTime = 0.6f;
    public bool started = false;

    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = speed;
        speed = 0f;
        startPos = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        if(!started)
        {
            if(Input.GetButton("Jump"))
            {
                
                startTimer += Time.deltaTime;
                if(startTimer > igniteTime)
                {
                    started = true;
                }
            }
        }

        if(started)
        {
            if (Input.GetButton("Jump"))
            {
                speed = boostSpeed;
                timer += Time.deltaTime;
                if (timer > 1f)
                {
                    //boostEffect.gameObject.SetActive(true);
                }
            }

            else
            {
                speed = originalSpeed;
                //boostEffect.gameObject.SetActive(false);
            }
        }

        transform.position = transform.position + Vector3.up * speed * Time.deltaTime;
        distanceTraveled = startPos + transform.position.y;
        heightText.GetComponent<TextMeshProUGUI>().text = distanceTraveled.ToString("f0");
        print(distanceTraveled);
    }
}
