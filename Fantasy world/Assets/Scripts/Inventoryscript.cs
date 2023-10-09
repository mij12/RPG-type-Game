using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Inventoryscript : MonoBehaviour
{

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
        }
    
        
    }

}
