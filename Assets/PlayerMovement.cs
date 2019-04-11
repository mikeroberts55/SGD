using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    GameObject Player, Player2,Cam1,Cam2;
//<<<<<<< mikeroberts55-patch-1
    int count = 2;
//=======
    int characterselect;
//>>>>>>> devBranch

    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;

    private void Start()
    {
        Player = GameObject.Find("Player");
        Player2 = GameObject.Find("Player2");
        Cam1 = GameObject.Find("CM vcam1");
        Cam2 = GameObject.Find("CM vcam1 (1)");
//<<<<<<< mikeroberts55-patch-1
        Invoke("changeCharacter", 0.2f);
//=======

        characterselect = 1;
//>>>>>>> devBranch
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }
//<<<<<<< mikeroberts55-patch-1

    public void changeCharacter()
    {
        if (count == 1)
        {
            // Player.transform.Find("Player").gameObject.SetActive(false);
            //Player2.transform.Find("Player2").gameObject.SetActive(true);
            //  Cam1.transform.Find("CM vcam1").gameObject.SetActive(false);
            // Cam2.transform.Find("CM vcam1 (1)").gameObject.SetActive(true);
           // Player.SetActive(false);
            Player2.SetActive(true);
            Player2.GetComponent<PlayerMovement>().enabled = true;
            Player2.GetComponent<BoxCollider2D>().enabled = true;
            Player2.GetComponent<CircleCollider2D>().enabled = true;
            Player2.GetComponent<Rigidbody2D>().isKinematic = false;
            Player.GetComponent<PlayerMovement>().enabled = false;
            Player.GetComponent<BoxCollider2D>().enabled = false;
            Player.GetComponent<CircleCollider2D>().enabled = false;
            Player.GetComponent<Rigidbody2D>().isKinematic = true;
            Cam1.SetActive(false);
            Cam2.SetActive(true);
            count = 2;
        }
        else if (count ==2)
        {
           // Player.transform.Find("Player").gameObject.SetActive(true);
           // Player2.transform.Find("Player2").gameObject.SetActive(false);
            //Cam1.transform.Find("CM vcam1").gameObject.SetActive(true);
           // Cam2.transform.Find("CM vcam1 (1)").gameObject.SetActive(false);
             Player.SetActive(true);
            // Player2.SetActive(false);
            Player.GetComponent<PlayerMovement>().enabled = true;
            Player.GetComponent<BoxCollider2D>().enabled = true;
            Player.GetComponent<CircleCollider2D>().enabled = true;
            Player.GetComponent<Rigidbody2D>().isKinematic = false;
            Player2.GetComponent<PlayerMovement>().enabled = false;
            Player2.GetComponent<BoxCollider2D>().enabled = false;
            Player2.GetComponent<CircleCollider2D>().enabled = false;
            Player2.GetComponent<Rigidbody2D>().isKinematic = true;
            Cam1.SetActive(true);
             Cam2.SetActive(false);
            count = 1;
        }
    }
//=======
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
//>>>>>>> devBranch

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            changeCharacter();
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
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            changeCharacter();
        }
        
    }
}
