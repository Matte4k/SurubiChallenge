using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectCoin : MonoBehaviour
{
    public AudioSource coinFX;
    public AudioClip coinCollect;
    public ScoreManager scoreManager;

    private void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (coinFX != null)
        {
            coinFX.PlayOneShot(coinCollect);
        }
        scoreManager.coinScore();
        this.gameObject.SetActive(false);
    }
}
