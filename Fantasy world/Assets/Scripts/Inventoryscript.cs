using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Inventoryscript : MonoBehaviour
{
    public GameObject gPan;
    public GameObject gFlower;
    public GameObject gCore;

    public bool panEquipped = false;
    public bool flowerEquipped = false;
    public bool coreEquipped = false;
    
    public int nFlowers = 0;
    public int flowerO;
    public int nPan = 0;
    public int panO;
    public int nCores = 0;
    public int coreO;
    public TMP_Text pan;
    public TMP_Text flower;
    public TMP_Text core;
   
    // Start is called before the first frame update
    void Start()
    {
        flowerO = nFlowers;
        panO = nPan;
        coreO = nCores;
    }

    // Update is called once per frame
    void Update()
    {
        if (nPan != panO)
        {
            panO = nPan;
            pan.text = $"{nPan}";
        }
        if (nFlowers != flowerO)
        {
            flowerO = nFlowers;
            flower.text = $"{nFlowers}";
        }
        if (nCores != coreO)
        {
            coreO = nCores;
            core.text = $"{nCores}";
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //draw pan/sword for battle
            if (panEquipped == false)
            {
                if (nPan > 0)
                {
                    panEquipped = true;
                    gPan.SetActive(true);
                }
            }
            else
            {
                panEquipped = false;
                gPan.SetActive(false);
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //draw pan/sword for battle
            if (flowerEquipped == false)
            {
                if (nFlowers > 0)
                { 
                    flowerEquipped = true;
                    gFlower.SetActive(true); 
                }
            }
            else
            {
                flowerEquipped = false;
                gFlower.SetActive(false);
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //draw pan/sword for battle
            if (coreEquipped == false)
            {
                if (nCores > 0)
                {
                    coreEquipped = true;
                    gCore.SetActive(true);
                }
            }
            else
            {
                coreEquipped = false;
                gCore.SetActive(false);
            }

        }


    }

}
