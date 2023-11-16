using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class timer : MonoBehaviour
{

    public float Timer1 = 0f;
    public float TimerLength= 25f;
    public bool toCut2 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Timer1 += 1 * Time.deltaTime;
        if (toCut2 == false)
        {
            if (Timer1 >= TimerLength)
            {
                SceneManager.LoadScene("SampleScene");

            }
        }
        if (toCut2)
        {

            if (Timer1 >= TimerLength)
            {
                SceneManager.LoadScene("Cutscene2");

            }
        }
    }
}
