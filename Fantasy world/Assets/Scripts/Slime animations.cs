using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimeanimations : MonoBehaviour
{
    public static bool attack = false;
    public static Animation anim;
    public GameObject slime;
  
    // Start is called before the first frame update
    void Start()
    {
        anim = slime.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attack)
        {


            if (anim.isPlaying == false)
            {
                anim.Play("Attack");
             
            }
           
            
            attack = false;
        }

    }
}
