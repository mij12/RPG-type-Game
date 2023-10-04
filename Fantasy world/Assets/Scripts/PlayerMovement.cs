using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public bool pressedTab = false;
    public bool statsActive = false;
    public GameObject stats;


    public static bool isHiding = false;
    public static int attackDMG = 1;
    public static int HP = 10;
    public static float XP = 0f;
    public Transform patrolRoute;
  //  public List<Transform> locations;

    public CharacterController controller;
    public Transform cam;

    public float speed = 7f;

    public float smoothTurnTime = 0.1f;
    float smoothTurnVelocity;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab) && pressedTab == false)
        {
            pressedTab = true;
            if (statsActive == false)
            {
                stats.SetActive(true);
                statsActive = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else if (statsActive)
            {
                stats.SetActive(false);
                statsActive = false;
                Cursor.lockState = CursorLockMode.Locked;
            }


        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            pressedTab = false;
        }

    
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

        if (HP <= 0)
        {
            SceneManager.LoadScene("LoseScreen");
            Destroy(this.gameObject);
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

