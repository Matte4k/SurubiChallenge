using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseGameSpeed : MonoBehaviour
{
    public float initialTimeScale = 1.0f;   // Escala de tiempo inicial
    public float maxTimeScale = 3.0f;       // Límite máximo para el Time.timeScale
    public float timeScaleIncrement = 0.1f; // Cantidad de incremento de timeScale por intervalo
    public float interval = 5.0f;           // Intervalo en segundos entre cada aumento de timeScale

    private float timer;                    // Temporizador para controlar los intervalos

    void Start()
    {
        // Establece el Time.timeScale inicial y el temporizador
        ResetTimeScale();
        Time.timeScale = initialTimeScale;
        timer = interval;
    }

    void Update()
    {
        // Disminuye el temporizador
        timer -= Time.deltaTime;

        // Cuando el temporizador llega a 0, incrementa Time.timeScale
        if (timer <= 0f)
        {
            // Incrementa el Time.timeScale, sin sobrepasar el límite máximo
            Time.timeScale = Mathf.Min(Time.timeScale + timeScaleIncrement, maxTimeScale);

            // Reinicia el temporizador
            timer = interval;
        }
    }

    // Método opcional para restablecer el Time.timeScale al valor inicial
    public void ResetTimeScale()
    {
        Time.timeScale = initialTimeScale;
    }
}
