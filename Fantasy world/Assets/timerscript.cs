using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerscript : MonoBehaviour
{

    public float timer1 = 0f;
    public float timer2 = 0f;
    public bool timer1On = false;
    public bool timer2On = false;
    public GameObject slime;
    public GameObject flower = null;
    // Start is called before the first frame update
    void Start()
    {
        slime = GameObject.Find("Slime");
    }

    // Update is called once per frame
    void Update()
    {
        if (timer1 >= 10)
        {
            timer1On = false;
            timer1 = 0f;
            slime.SetActive(true);
        }
        if (timer1On)
        {
            timer1 += 1 * Time.deltaTime;

        }
        //if (timer2 >= 10)
        //{
        //    timer2On = false;
        //    timer2 = 0f;

        //    flower.SetActive(true);
        //}
        //if (timer1On)
        //{
        //    timer2 += 1 * Time.deltaTime;

        //}
    }
}
