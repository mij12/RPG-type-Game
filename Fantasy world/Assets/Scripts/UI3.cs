using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PlayerMovement.isHiding = false;
        PlayerMovement.attackDMG = 1;
        PlayerMovement.HP = 10;
        PlayerMovement.XP = 0f;
        patrolling.resetLocations = true;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToFirstScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ToCutscene1()
    {
        SceneManager.LoadScene("Cutscene1");
    }
    
    public void ToControls()
    {
        SceneManager.LoadScene("Controls");
    }
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ToInputName()
    {
        SceneManager.LoadScene("InputUsername");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
