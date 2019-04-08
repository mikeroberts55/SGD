using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    GameObject Player, Player2,Cam1,Cam2;
    int characterselect;

    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;

    private void Start()
    {
        Player = GameObject.Find("Player");
        Player2 = GameObject.Find("Player2");
        Cam1 = GameObject.Find("CM vcam1");
        Cam2 = GameObject.Find("CM vcam1 (1)");

        characterselect = 1;
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (characterselect == 1)
            {
                characterselect = 2;
            }
            else if (characterselect == 2)
            {
                characterselect = 1;
            }
        }
        if (characterselect == 1)
        {
            Player.SetActive(true);
            Player2.SetActive(false);
            Cam1.SetActive(true);
            Cam2.SetActive(false);
        }
        else if (characterselect == 2)
        {
            Player.SetActive(false);
            Player2.SetActive(true);
            Cam1.SetActive(false);
            Cam2.SetActive(true);
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
