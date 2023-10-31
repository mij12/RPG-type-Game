using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public bool pressedTab = false;
    public bool statsActive = false;
    public GameObject stats;
    public GameObject overlay;


    public static bool isHiding = false;
    public static float attackDMG = 1;
    public static float DMGOrigin = 1;
    public static float DMGSaved = 1;



    public static float HP = 10;
    public static float HPOrigin;
    public static float HPSaved;

    public static float XP = 0f;
    public Transform patrolRoute;
    public Vector3 respawnPoint;
  //  public List<Transform> locations;

    public CharacterController controller;
    public Transform cam;

    public float speed = 7f;
    public float speedOrigin;
    public float speedSaved;
   

    public float smoothTurnTime = 0.1f;
    float smoothTurnVelocity;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;
    bool isGrounded;

    //public Inventoryscript inventory;
    public bool sethp = false;
    public bool respawning = false;


    void Start()
    {

        overlay.SetActive(false);
        speedOrigin = speed;
        speedSaved = speed;

        HPOrigin = HP;
        HPSaved = HP;

        DMGOrigin = attackDMG;
        DMGSaved = attackDMG;

        respawnPoint = transform.position;
        //inventory = GameObject.Find("Inventory").GetComponent<Inventoryscript>();
    }

    // Update is called once per frame
    void Update()
    {
       


        if (speedSaved != speedOrigin + speedOrigin * 0.1f * int.Parse(stats.GetComponent<Stats>().speed.text))
        {
            speed = speedOrigin + speedOrigin * 0.1f * int.Parse(stats.GetComponent<Stats>().speed.text);
            speedSaved = speed;
            
        }
        if (HPSaved != HPOrigin + HPOrigin * 0.1f * int.Parse(stats.GetComponent<Stats>().hp.text))
        {
            HP = HPOrigin + HPOrigin * 0.1f * int.Parse(stats.GetComponent<Stats>().hp.text);
            HPSaved = HP;

        }
        if (DMGSaved != DMGOrigin + DMGOrigin * 0.1f * int.Parse(stats.GetComponent<Stats>().dmg.text))
        {
            attackDMG = DMGOrigin + DMGOrigin * 0.1f * int.Parse(stats.GetComponent<Stats>().dmg.text);
            DMGSaved = attackDMG;

        }

        if (Input.GetKeyDown(KeyCode.Tab) && pressedTab == false)
        {
            pressedTab = true;
            if (statsActive == false)
            {
                stats.SetActive(true);
                overlay.SetActive(false);
                statsActive = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else if (statsActive)
            {
                stats.SetActive(false);
                overlay.SetActive(true);
                statsActive = false;
                Cursor.lockState = CursorLockMode.Locked;
            }


        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            pressedTab = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

        if (HP > 0)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
            //locations.Clear();
            //foreach (Transform child in patrolRoute)
            //{
            //    locations.Add(child);
            //}
            //if (locations.Count == 0)
            //{
            //    if (XP >= 4)
            //    {


            //        SceneManager.LoadScene("WinScreen");
            //    }
            //    else
            //    {
            //        SceneManager.LoadScene("LoseScreen1");
            //    }
            //}

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothTurnVelocity, smoothTurnTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDirection.normalized * speed * Time.deltaTime);
            }
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        if (sethp)
        {
            HP = 0;
            sethp = false;
        }

        if (HP <= 0)
        {
            respawning = true;
            //transform.position = respawnPoint;
            //HP = HPOrigin + HPOrigin * 0.1f * int.Parse(stats.GetComponent<Stats>().hp.text);
            //SceneManager.LoadScene("LoseScreen");
            //Destroy(this.gameObject);
        }
        if (respawning)
        {
            if (transform.position != respawnPoint)
            {
                transform.position = respawnPoint;
                HP = HPOrigin + HPOrigin * 0.1f * int.Parse(stats.GetComponent<Stats>().hp.text);
            }
            else
            {
                respawning = false;
            }
        }

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bush")
        {
            isHiding = true;
        }
        if (other.tag == "Flower")
        {
            XP += 1;
            patrolling.resetLocations = true;
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bush")
        {
            isHiding = false;
        }
    }

 
        
    
}

