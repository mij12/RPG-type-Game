using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    
    public TMP_Text HP1;
    public TMP_Text HPplayer;
    public GameObject slime1;

    public GameObject player1;

    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);
        HP1.text = $"HP: {Mathf.Round(slime1.GetComponent<patrolling>().HP)}";
        HPplayer.text = $"HP: {Mathf.Round(PlayerMovement.HP)}";
    }
}
