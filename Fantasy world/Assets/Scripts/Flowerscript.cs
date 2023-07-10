using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowerscript : MonoBehaviour
{

    public GameObject flower;
    public bool isBeingEaten = false;
    public bool isEaten = false;
    public float timer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
      //  flower = GameObject.Find("Flower");
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingEaten)
        {
            //play eating sound
            if (timer >= 3)
            {
                isBeingEaten = false;
                isEaten = true;
                patrolling.resetLocations = true;
                Destroy(this.gameObject);
                timer = 0;
            }
            else
            {
                patrolling.resetLocations = false;
            }
            timer += Time.deltaTime;
        }
    }
}
