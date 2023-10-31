using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI2 : MonoBehaviour
{

    public TMP_Text XP;
    public TMP_Text Slimes;
    public TMP_Text quest2;
    public static int dSlimes = 0;
    public Inventoryscript inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.Find("Inventory").GetComponent<Inventoryscript>();
    }

    // Update is called once per frame
    void Update()
    {
        XP.text = $"Collect 10 flowers {inventory.nFlowers}/10";
        Slimes.text = $"Slimes defeated: {dSlimes}";
        quest2.text = $"Collect 3 red crystals {inventory.redCryst}/3";
        if (inventory.nFlowers >= 10 && inventory.redCryst >= 3)
        {
            SceneManager.LoadScene("WinScreen");
        }
    }

 
}
