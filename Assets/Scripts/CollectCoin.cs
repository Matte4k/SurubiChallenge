using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public AudioSource coinFX;
    public AudioClip coinCollect;

    void OnTriggerEnter(Collider other)
    {
        if (coinFX != null)
        {
            coinFX.PlayOneShot(coinCollect);
        }
        this.gameObject.SetActive(false);
    }
}
