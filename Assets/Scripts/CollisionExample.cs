using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionExample : MonoBehaviour
{
    public GameObject retryButton;
    public GameObject quitButton;
    public GameObject explosion;
    public GameObject explosion2;
    public Animator cameraAnim;
    public Animator catAnimation;

    public GameObject record;

    private AudioSource myAudio;

    public AudioClip hurtAudio;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
        retryButton = GameObject.Find("RetryButton");
        retryButton.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            catAnimation.SetTrigger("Crash");
            StartCoroutine(HitStop());
        }
    }

    public IEnumerator HitStop()
    {
        myAudio.volume = 1f;
        myAudio.PlayOneShot(hurtAudio);
        Instantiate(explosion2, transform.position, transform.rotation);
        yield return new WaitForSecondsRealtime(0.1f);        
        GetComponent<Collider>().enabled = false;
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 1f;
        Instantiate(explosion, transform.position, transform.rotation);
        cameraAnim.SetTrigger("Shake");
        GameObject.Find("Rocket").SetActive(false);
        GameObject.Find("ThrusterEffect").SetActive(false);
        yield return new WaitForSeconds(2f);
        retryButton.SetActive(true);
        //quitButton.SetActive(true);
        Instantiate(record, new Vector3
            (Random.Range(transform.position.x - 5f, transform.position.x + 5f),
            Random.Range(transform.position.y - 5f, transform.position.y + 5f),
            Random.Range(transform.position.z + 5f, transform.position.z + 15f)), transform.rotation);
        Destroy(gameObject);
    }
}
