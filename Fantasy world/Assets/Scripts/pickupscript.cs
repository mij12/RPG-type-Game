using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class pickupscript : MonoBehaviour
{
    public bool isInRange = false;
    public GameObject UIElement;
    public GameObject stats;
    public GameObject inventory;
    public GameObject redCrystal;
    // Start is called before the first frame update
    void Start()
    {
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

        if (isInRange)
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                //if (isPan)
                //{
                    inventory.GetComponent<Inventoryscript>().redCryst += 1;
                    Destroy(redCrystal);
                //}
                //else
                //{
                //    inventory.GetComponent<Inventoryscript>().nFlowers += 1;
                //}

                //Destroy(this.gameObject);
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
