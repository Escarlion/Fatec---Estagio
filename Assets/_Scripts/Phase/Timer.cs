using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    [SerializeField] private float duration = 60f; // Duração do timer em segundos
    private bool isRunning = false;
    float timeStamp;
    float timeRemaining;

    IEnumerator RunTimer()
    {
        isRunning = true;
        float startTime = Time.time;

        while (isRunning)
        {
            float currentTime = Time.time - startTime;
            timeRemaining = Mathf.Max(duration - currentTime, 0f);

            // Convertendo o tempo restante para minutos, segundos e milissegundos
            string minutes = "";
            if (duration > 60f) minutes = Mathf.FloorToInt(timeRemaining / 60).ToString("00") + ":";
            string seconds = Mathf.FloorToInt(timeRemaining % 60).ToString("00");
            string milliseconds = Mathf.FloorToInt((timeRemaining * 1000) % 1000).ToString("00");

            // Atualizando o texto do timer
            timerText.text = minutes + seconds + ":" + milliseconds;

            if (timeRemaining <= 0f) isRunning = false;
            if (timeRemaining <= 10f) timerText.color = Color.red;

            yield return null;
        }

        if (timeRemaining <= 0f) GetComponent<PhaseManager>().EndPhase(false);
    }

    public float GetDuration()
    {
        return duration;
    }

    public string GetTimeLeft()
    {
        return timerText.text;
    }

    // Método para pausar o timer
    public void PauseTimer()
    {
        isRunning = false;
    }

    // Método para retomar o timer
    public void ResumeTimer()
    {
        StartCoroutine(RunTimer());
    }

    // Método para reiniciar o timer
    public void ResetTimer()
    {
        StopCoroutine(RunTimer());
        StartCoroutine(RunTimer());
    }

    public void StartTimer()
    {
        StartCoroutine(RunTimer());
    }

    public void StopTimer()
    {
        isRunning = false;
        StopCoroutine(RunTimer());
    }
}
