using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("No hay un GameManager en la escena");
            }
            return instance;
        }
    }

    public bool GameOver;
    public float timeUntilNewObstacle = 5;

    public GameObject obstacle;
    public PlayerController player;
    public EnemySpawner enemySpawner;
    public Timer timer;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //every 5 seconds, spawn a new obstacle
        timeUntilNewObstacle -= Time.deltaTime;
        if (timeUntilNewObstacle <= 0)
        {
            timeUntilNewObstacle = 5;
            SpawnObstacle();
        }
        //If the game is over, press R to restart
        if (GameOver)
        {
            gameOverText.gameObject.SetActive(true);
            gameOverText.text = "Has perdido!";
            restartButton.gameObject.SetActive(true);
        }
        //Every time 30 seconds pass, modify the player's gravity
        if (timer.timeRemaining <= 90)
        {
            player.gravity = -2.45f;
        }
        if (timer.timeRemaining <= 60)
        {
            player.gravity = -50f;
        }
        if (timer.timeRemaining <= 30)
        {
            player.gravity = -24.79f;
        }

    }
    public void SpawnObstacle()
    {
        if(!GameOver)
        {
            enemySpawner.SpawnObstacle();
        }
    }
    public void RestartGame()
    {
        GameOver = false;
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        timer.timeRemaining = 120;
    }
}
