using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    private Timer timer;
    private void OnTriggerExit(Collider other)
    {
        timer = other.GetComponent<Timer>();
        timer.enabled = true;
    }
}
