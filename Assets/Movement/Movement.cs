using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Example : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    private float gravityValue = -14f;
    public float SkillJump = 10.0f;
    float normalJump = 1.0f;
    public int yildiz = 20;
    public float time = 5;
    bool timeraktif = false;


    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.C)) 
        {
            timeraktif = true;
        }
        if (timeraktif)
        {
            time -= Time.deltaTime;
            if(time<=0)
            {
                timeraktif=false;
                jumpHeight = normalJump;
                time = 5.0f;
            }

        }

        CharacaterMovement();
        JumpSkill();
    }

    public void JumpSkill()
    {
        if (Input.GetKey(KeyCode.C) && timeraktif )
        {
            if (yildiz > 4)
            {
                yildiz -= 5;
                jumpHeight = SkillJump;
            }

        }


    }

    public void CharacaterMovement()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetButton("Jump") && groundedPlayer)
        {

            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            

        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
