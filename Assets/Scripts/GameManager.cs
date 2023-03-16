using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int score;
    public static int hiScore = 1; 
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiScoreText;
    public Animator speedUpText;

    public GameObject[] asteroidFields;
    public GameObject[] asteroidFieldsHard;
    public GameObject player;

    public Animator fadeScreen;
    public float transitionTime = 2f;

    public float timer;
    public int level;
    public int speedUplevel;

    public AudioSource myAudio;
    public bool paused = false;

    private void Start()
    {
        hiScore = PlayerPrefs.GetInt("HiScore");
        hiScoreText.text = "Hi Score: " + hiScore.ToString();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        /*
        if(timer > 10f)
        {
            speedUpText.SetTrigger("SpeedUp");
            StartCoroutine(SpeedUp());
            timer = 0f;
        }
        */

        if(Input.GetKeyDown(KeyCode.P))
        {
            if(paused == false)
            {
                myAudio.Pause();
                paused = true;
            }
            else if (paused == true)
            {
                myAudio.UnPause();
                paused = false;
            }
        }

    }

    public void StartGame()
    {
        StartCoroutine(LoadLevel(1));
    }

    public void Retry()
    {
        StartCoroutine(LoadLevel(1));
    }

    public void Quit()
    {
        StartCoroutine(LoadLevel(0));
    }

    public IEnumerator LoadLevel(int levelToLoad)
    {
        fadeScreen.SetTrigger("FadeOut");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelToLoad);
    }

    public void AddScore()
    {
        score += 1;
        scoreText.text = score.ToString();

        if(score > hiScore)
        {
            hiScore = score;
            hiScoreText.text = "Hi Score: " + hiScore.ToString();
            PlayerPrefs.SetInt("HiScore", hiScore);
            PlayerPrefs.Save();           
        }
    }

    public void ClearData()
    {
        PlayerPrefs.SetInt("HiScore", 0);
        hiScore = PlayerPrefs.GetInt("HiScore");
        hiScoreText.text = "Hi Score: " + hiScore.ToString();
        PlayerPrefs.Save();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator SpeedUp()
    {
        speedUpText.SetTrigger("SpeedUp");
        yield return new WaitForSeconds(3f);
        Time.timeScale = Time.timeScale * 1.2f;
        SpawnAsteroidField();
        speedUplevel = 0;
    }

    public void SpawnAsteroidField()
    {
        int rnd = Random.Range(0,4);

        if(timer<30f)
        {
            Instantiate(asteroidFields[rnd], new Vector3(
                player.transform.position.x,
                player.transform.position.y + 8,
                player.transform.position.z), player.transform.rotation);
        }
        else
        {
            Instantiate(asteroidFieldsHard[rnd], new Vector3(
                player.transform.position.x,
                player.transform.position.y + 8,
                player.transform.position.z), player.transform.rotation);
        }


    }


}
