using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using TMPro.Examples;

public class Timer : MonoBehaviour
{
    public float timeRemaining;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI victoryText;
    public Button victory;
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = 120;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.GameOver)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = "Tiempo: " + timeRemaining.ToString("F0");
        }
        if (timeRemaining <= 0)
        {
            GameManager.Instance.GameOver = true;
            victoryText.gameObject.SetActive(true);
            victoryText.text = "Has Ganado!";
            victory.gameObject.SetActive(true);
        }
    }
    public void NextLevel()
    {
        victoryText.gameObject.SetActive(false);
        victory.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
