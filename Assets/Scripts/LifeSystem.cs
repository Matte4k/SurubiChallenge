using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public GameObject thePlayer, theCamera, playerHitbox, gameManager;
    public GameObject hitParticles, damage1, damage2, boatParticles;
    public Image life1, life2, life3;
    public Sprite fullLife, lostLife;
    private int hitCount;
    public AudioSource hits;
    public AudioClip hit, gameOver;
    private bool soundFlag;
    public GameOver gameOverClass;
    // Start is called before the first frame update
    void Start()
    {
        hitCount = 0;
        soundFlag = false;
        gameManager.GetComponent<SpawnSegment>().enabled = true;
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

        life1.sprite = fullLife;
        life2.sprite = fullLife;
        life3.sprite = fullLife;
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
                life3.sprite = lostLife;
                break;
            case 2:
                damage2.SetActive(true);
                if (soundFlag)
                {
                    hits.PlayOneShot(hit);
                }
                life2.sprite = lostLife;
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
                life1.sprite = lostLife;
                gameManager.GetComponent<IncreaseGameSpeed>().enabled = false;
                gameManager.GetComponent<SpawnSegment>().enabled = false;
                gameOverClass.ShowScreen();
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
