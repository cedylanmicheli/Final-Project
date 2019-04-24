using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public float speed;
    public Boolean winMusicOn;

    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    public Text hardText;

    public AudioSource mainMusic;
    public AudioSource loseMusic;
    public AudioSource winMusic;


    private bool gameOver;
    private bool restart;
    private int score;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        mainMusic.Play();
        speed = 1;
        hardText.text = "Press \"H\" to enter Hard Mode";
        winMusicOn = false;
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                SceneManager.LoadScene("Main"); 
            }
        }

        if (Input.GetKey("escape"))
            Application.Quit();

        if (Input.GetKey(KeyCode.H))
            HardMode();
        if (Input.GetKey(KeyCode.G))
            ExitHardMode();
    }



    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[UnityEngine.Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'P' for Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 150 && winMusicOn == false)
        {
            gameOverText.text = "Game created by Dylan Micheli";
            gameOver = true;
            restart = true;
            mainMusic.Stop();
            winMusic.Play();
            winMusicOn = true;
        }
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
        mainMusic.Stop();
        loseMusic.Play();
    }

    public void HardMode()
    {
            speed = 2.5f;
            hardText.text = "Press \"G\" to exit Hard Mode";
    }

    public void ExitHardMode()
    {
        hardText.text = "Press \"H\" to enter Hard Mode";
        speed = 1;
    }
}