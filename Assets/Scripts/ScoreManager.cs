using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.Examples;

public class ScoreManager : MonoBehaviour
{
    public GameObject thePlayer;
    private int score, coinCount;
    public TMP_Text scoreText, coinText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        coinCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (thePlayer.GetComponent<PlayerMovement>().enabled != false)
        {
            StartCoroutine(scoreDelay());
        }
        
        scoreText.text = score.ToString("D11");
        coinText.text = coinCount.ToString("D4");
    }

    IEnumerator scoreDelay()
    {
        score += 2;
        yield return new WaitForSeconds(0.2f);
    }

    public void coinScore()
    {
        score += 10;
        coinCount++;
    }
}
