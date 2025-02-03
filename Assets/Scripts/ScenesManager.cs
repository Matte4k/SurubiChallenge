using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public GameObject fadeIn, fadeOut;
    public LifeSystem lifeSystem;
    // Start is called before the first frame update
    void Start()
    {
        fadeIn.SetActive(false);
        fadeOut.SetActive(false);
        fadeOut.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeSystem.getHitCount() == 3)
        {
            fadeOut.SetActive(false);
        }
    }

    public void Reset()
    {
        StartCoroutine(ResetCoroutine());
    }

    public void GoMainMenu()
    {
        StartCoroutine(GoMainMenuCoroutine());
    }

    public void Play()
    {
        StartCoroutine(ResetCoroutine());
    }

    IEnumerator ResetCoroutine()
    {
        fadeIn.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameScene");
    }

    IEnumerator GoMainMenuCoroutine()
    {
        fadeIn.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MainMenuScene");
    }
}
