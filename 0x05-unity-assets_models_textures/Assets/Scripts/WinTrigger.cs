using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    private Timer timer;
    private void OnTriggerEnter(Collider other)
    {
        // Stopping the timer.
        timer = other.GetComponent<Timer>();

        timer.enabled = false;

        // Updating the timer color and size.
        timer.timerText.color = Color.green;
        timer.timerText.fontSize = 69;
    }
}
