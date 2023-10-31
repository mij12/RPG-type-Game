using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimeanimations : MonoBehaviour
{
    public bool sHasHit = false;
    public bool slHasHit = false;
    public bool sAnimActive = false;
    public static bool attack = false;
    public static Animation anim;
    public GameObject slimeMesh;
    public GameObject slime;
    public GameObject sword;

    // Start is called before the first frame update
    void Start()
    {
        anim = slimeMesh.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attack)
        {


            if (anim.isPlaying == false)
            {
                anim.Play("Attack");
              sAnimActive = true;
            }
            else
            {
                sAnimActive=false;
            }
           
            
            attack = false;
        }

        if (sword.GetComponent<Animationswing>().animIsPlaying == false && sHasHit == true)
        {
            sHasHit = false;
        }

        if (anim.isPlaying == false && slHasHit == true)
        {
            slHasHit = false;
        }

    }


    void OnTriggerEnter(Collider other)
    {
       
        if (other.name == "Pan2")
        {

            if (sword.GetComponent<Animationswing>().animIsPlaying == true && sHasHit == false)
            {
                sHasHit = true;


                ////if slime is eating stop the eating
                //if (locations[locationIndex].GetComponent<Flowerscript>().isBeingEaten == true)
                //{
                //    locations[locationIndex].GetComponent<Flowerscript>().isBeingEaten = false;
                //}
                slime.GetComponent<patrolling>().HP -= PlayerMovement.attackDMG;
                //  agent.destination = player.position;
                slime.GetComponent<patrolling>().sDestination = "Player";
            }


        }
        if (other.name == "Trigger")
        {
            Debug.Log("hit trigger");
            if ((anim.isPlaying == true || sAnimActive == true) && slHasHit == false)
            {
                slHasHit = true;



                PlayerMovement.HP -= slime.GetComponent<patrolling>().attackDMG;
                Debug.Log(PlayerMovement.HP);
                if (PlayerMovement.HP <= 0)
                {
                    slime.GetComponent<patrolling>().HP = 10;
                }

            }


        }
    }
}
