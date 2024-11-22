using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.Examples;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public ScoreManager scoreManager;
    public TMP_Text scoreText, coinText;
    // Start is called before the first frame update
    void Start()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowScreen()
    {
        scoreText.text = scoreManager.getScore().ToString();
        coinText.text = scoreManager.getCoinCount().ToString();
        gameOverScreen.SetActive(true);
    }
}
