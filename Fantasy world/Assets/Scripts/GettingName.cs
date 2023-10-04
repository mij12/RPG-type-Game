using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GettingName : MonoBehaviour
{

    public TMP_InputField inputfield;
    public static string uName = "Unknown";

    void Update()
    {
        if (inputfield.text != "")
        {
            uName = inputfield.text;
        }
  
        Debug.Log($"Name: \"{uName}\"");
    }


}
