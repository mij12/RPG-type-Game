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
    public bool isPan = false;
    public float timer = 0f;
    public GameObject UIElement;
    public GameObject stats;
    public GameObject inventory;
    public timerscript timerScript;

    // Start is called before the first frame update
    void Start()
    {
        //  flower = GameObject.Find("Flower");
       stats = GameObject.Find("Stats");
       inventory = GameObject.Find("Inventory");
        timerScript = GameObject.Find("Timer").GetComponent<timerscript>();
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

                
                //timerScript.timer2On = true;
                //timerScript.flower = flower;
                //flower.SetActive(false);
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
                stats.GetComponent<Stats>().xp.text = (int.Parse(stats.GetComponent<Stats>().xp.text) + 5).ToString();
                Destroy(this.gameObject);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isPan)
                {
                    inventory.GetComponent<Inventoryscript>().nPan += 1;
                    Destroy(flower);
                }
                else
                {
                    inventory.GetComponent<Inventoryscript>().nFlowers += 1;
                }
                
                Destroy(this.gameObject);
            }
        }
        if (inventory.GetComponent<Inventoryscript>().flowerEquipped == true)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
            {
                inventory.GetComponent<Inventoryscript>().flowerEquipped = false;
                inventory.GetComponent<Inventoryscript>().gFlower.SetActive(false);
                inventory.GetComponent<Inventoryscript>().nFlowers -= 1;
                stats.GetComponent<Stats>().xp.text = (int.Parse(stats.GetComponent<Stats>().xp.text) + 5).ToString();
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

