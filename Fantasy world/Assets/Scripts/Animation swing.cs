using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animationswing : MonoBehaviour
{
    public bool animIsPlaying = false;

    private Animation anim;
    public GameObject sword;
    // Start is called before the first frame update
    void Start()
    {
        anim = sword.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {

        if (anim.isPlaying)
        {
            animIsPlaying = true;
            return;
        }

        if (animIsPlaying)
        {
            animIsPlaying = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("Swing");

        }
    }
}
