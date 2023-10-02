using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class patrolling : MonoBehaviour
{
    public bool sHasHit = false;
    public bool slHasHit = false;
    
    public static bool resetLocations = false;
    public int HP = 5;
    public float timer = 0f;
    public int attackDMG = 3;
    
    public Transform player;
    public Transform patrolRoute;
    public GameObject slime;
    public List<Transform> locations;

    private int locationIndex = 0;
    public static NavMeshAgent agent;
    private string sDestination = "Flower";
   // private Animation anim;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        patrolRoute = GameObject.Find("Flowers").transform;
        //  anim = slime.GetComponent<Animation>();
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }

    void Update()
    {

        if (resetLocations == true || locations[0] == null)
        {
            
            Debug.Log("resetting locations");
               resetLocations = false;
            locations.Clear();
            InitializePatrolRoute();
            MoveToNextPatrolLocation();
        }
        if (locations.Count == 0)
        {
            if (PlayerMovement.XP >= 4)
            {


                SceneManager.LoadScene("WinScreen");
            }
            else
            {
                SceneManager.LoadScene("LoseScreen1");
            }
        }
        if (agent.remainingDistance < 3f && !agent.pathPending) //if on destination ----- flower is eaten or player out of sight
        {
            if (sDestination == "Flower")
            {
                if (locations.Count != 0)
                {

                    locations[locationIndex].GetComponent<Flowerscript>().isBeingEaten = true;
                }


            }
        }
            if (agent.remainingDistance < 5f && !agent.pathPending) //if on destination ----- flower is eaten or player out of sight
            {

                if (sDestination == "Player")
            {
            //    agent.isStopped = true;
                //attack player or something
                if (timer > 1)
                {
                    Slimeanimations.attack = true;
                    timer = 0;
                }
                timer += Time.deltaTime;
                            
            }
           
           
            
            
       //     MoveToNextPatrolLocation();
        }
        

        if (sDestination == "Player")
        {
            agent.destination = player.position;
            if (PlayerMovement.isHiding)
            {
                resetLocations = true;
            }
        }
        
        if (HP <= 0)
        {
            UI2.dSlimes += 1;
            Destroy(slime);
        }
       
        if (Animationswing.animIsPlaying == false && sHasHit == true)
        {
            sHasHit = false;
        }

        if (Slimeanimations.anim.isPlaying == false && slHasHit == true)
        {
            slHasHit = false;
        }


    }

    void InitializePatrolRoute()
    {
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }

    void MoveToNextPatrolLocation()
    {
        if (locations.Count == 0)
            return;
        sDestination = "Flower";
        agent.destination = locations[locationIndex].position;
        locationIndex = 0;
        
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Stick (1)")
        {
            if (Animationswing.animIsPlaying == true && sHasHit == false)
            {
                sHasHit = true;


                //if slime is eating stop the eating
                if (locations[locationIndex].GetComponent<Flowerscript>().isBeingEaten == true)
                {
                    locations[locationIndex].GetComponent<Flowerscript>().isBeingEaten = false;
                }
                HP -= PlayerMovement.attackDMG;
                //  agent.destination = player.position;
                sDestination = "Player";
            }


        }
        if (other.name == "Trigger")
        {
            if (Slimeanimations.anim.isPlaying == true && slHasHit == false)
            {
                slHasHit = true;



                PlayerMovement.HP -= attackDMG;
                Debug.Log(PlayerMovement.HP);


            }


        }
    }


    //void OnTriggerExit(Collider other) // if player isn't visible
    //{

    //    if (other.name == "Player")
    //    {
    //        Debug.Log("Player out of range, resume patrol");
    //      //  MoveToNextPatrolLocation();
    //    }
    //}


    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.name == "Stick (1)")
    //    {
    //        Debug.Log("hit by stick");
    //        //if slime is eating stop the eating
    //        if (Flowerscript.isBeingEaten == true)
    //        {
    //            Flowerscript.isBeingEaten = false;
    //        }

    //        agent.destination = player.position;
    //        sDestination = "Player";
    //    }
    //}
}