using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlaneManagerInfo : MonoBehaviour
{
    // Private fields.
    // The messages to display on the panel.
    private string[] _messages;

    // Public fields.
    ///<summary>The text field.</summary>
    [HideInInspector]public TextMeshProUGUI currentMessage;
    ///<summary>The panel which contains the text.</summary>
    [HideInInspector]public Image panel;

    
    void Start()
    {
        currentMessage = GetComponentInChildren<TextMeshProUGUI>();
        panel = GetComponent<Image>();
        _messages = new string[2]{"Searching for surfaces...", "Tap on a surface to begin!"};

        panel.color = new Color(0f, 0f, 0f, 0.5f);
        currentMessage.text = _messages[0];
        currentMessage.color = Color.white;
    }

    public void SurfaceFound()
    {
        panel.color = new Color(0f, 1f, 0f, 0.5f);
        currentMessage.text = _messages[1];
        currentMessage.color = Color.black;
    }

    public void PlaneSelected()
    {
        gameObject.SetActive(false);
    }
}
