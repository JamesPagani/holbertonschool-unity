using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    public void GoToLink(string socialMediaURL)
    {
        Application.OpenURL(socialMediaURL);
        Debug.Log("Boop");
    }
}
