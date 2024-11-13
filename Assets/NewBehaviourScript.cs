using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballcounter : MonoBehaviour
{

    private int numberOfBalls;
    public GameObject banner;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Balls")
        {
            numberOfBalls++;
            Debug.Log("Found A Ball");
            Debug.Log("Number 0f Balls = " + numberOfBalls);
            if (numberOfBalls > 2)
            {
                banner.SetActive(true);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Balls")
        {
            numberOfBalls--;
            Debug.Log("Found A Ball");
            Debug.Log("Number 0f Balls = " + numberOfBalls);

        }

    }


}
