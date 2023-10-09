using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Flowerscript : MonoBehaviour
{

    public GameObject flower;
    public bool isBeingEaten = false;
    public bool isEaten = false;
    public bool isInRange = false;
    public float timer = 0f;
    public GameObject UIElement;
    public GameObject stats;
    public GameObject inventory;

    // Start is called before the first frame update
    void Start()
    {
        //  flower = GameObject.Find("Flower");
       stats = GameObject.Find("Stats");
       inventory = GameObject.Find("Inventory");
    }

    // Update is called once per frame
    void Update()
    {
        if (stats == null)
        {
            if (GameObject.Find("Stats") != null)
            {
                stats = GameObject.Find("Stats");
            }
        }
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

        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                stats.GetComponent<Stats>().xp.text = (int.Parse(stats.GetComponent<Stats>().xp.text) + 10).ToString();
                Destroy(this.gameObject);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                inventory.GetComponent<Inventoryscript>().nFlowers += 1;
                Destroy(this.gameObject);
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UIElement.SetActive(true);
            isInRange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            UIElement.SetActive(false);
            isInRange = false; 
        }
    }


}

