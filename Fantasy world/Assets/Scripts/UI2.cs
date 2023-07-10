using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI2 : MonoBehaviour
{

    public TMP_Text XP;
    public TMP_Text Slimes;
    public static int dSlimes = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        XP.text = $"XP: {PlayerMovement.XP}";
        Slimes.text = $"Slimes defeated: {dSlimes}";
    }

 
}
