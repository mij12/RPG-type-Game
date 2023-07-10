using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public static bool isHiding = false;
    public static int attackDMG = 1;
    public static int HP = 10;
    public static float XP = 0f;
    public Transform patrolRoute;
    public List<Transform> locations;

    public CharacterController controller;
    public Transform cam;

    public float speed = 7f;

    public float smoothTurnTime = 0.1f;
    float smoothTurnVelocity;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        locations.Clear();
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
        }
        if (locations.Count == 0)
        {
            if (XP >= 4)
            {


                SceneManager.LoadScene("WinScreen");
            }
            else
            {
                SceneManager.LoadScene("LoseScreen1");
            }
        }
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

