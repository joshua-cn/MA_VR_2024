using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallCounter : MonoBehaviour
{

    private int numberOfBalls;
    public TextMeshPro ballCounterText;
    public AudioSource scoreSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Balls")
        {
            numberOfBalls++;
            Destroy(other.gameObject);
            Debug.Log("Ball Entered total balls=" + numberOfBalls);
            ballCounterText.text = "Balls : " + numberOfBalls;
            ballCounterText.color = new Color(
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f));

            PlayScoreSound();
        }
    }
    private void PlayScoreSound()
    {
        if (scoreSound != null)
        {
            scoreSound.Play();
        }

    }
}