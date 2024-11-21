using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    public GameObject thePlayer, theCamera, playerHitbox, gameManager;
    public GameObject hitParticles, damage1, damage2, boatParticles;
    private int hitCount;
    public AudioSource hits;
    public AudioClip hit, gameOver;
    private bool soundFlag;
    // Start is called before the first frame update
    void Start()
    {
        hitCount = 0;
        soundFlag = false;
        gameManager.GetComponent<IncreaseGameSpeed>().enabled = true;
        if (damage1 != null)
        {
            damage1.SetActive(false);
        }

        if (damage2 != null)
        {
            damage2.SetActive(false);
        }

        if (boatParticles != null)
        {
            boatParticles.SetActive(true);
        }

        if (hitParticles != null)
        {
            hitParticles.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (hitCount){
            case 1:
                damage1.SetActive(true);
                if (soundFlag)
                {
                    hits.PlayOneShot(hit);
                }
                break;
            case 2:
                damage1.SetActive(false);
                damage2.SetActive(true);
                if (soundFlag)
                {
                    hits.PlayOneShot(hit);
                }
                break;
            case 3:
                thePlayer.GetComponent<PlayerMovement>().enabled = false;
                theCamera.GetComponent<CameraMovement>().enabled = false;
                boatParticles.SetActive(false);
                hitParticles.SetActive(false);
                if (soundFlag)
                {
                    hits.PlayOneShot(gameOver);
                }
                Time.timeScale = 0;
                gameManager.GetComponent<IncreaseGameSpeed>().enabled = false;
                break;
            default:
                break;
        }
        soundFlag = false;
    }

    public void hitRegister()
    {
        hitCount++;
        if (hitParticles != null)
        {
            hitParticles.SetActive(false);
            hitParticles.SetActive(true);
        }
        soundFlag = true;
        StartCoroutine(disableHitbox());
    }

    IEnumerator disableHitbox()
    {
        playerHitbox.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        playerHitbox.SetActive(true);
    }
}
