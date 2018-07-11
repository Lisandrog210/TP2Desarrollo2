using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMoveJump : MonoBehaviour
{
    float verticalSpeed;
    CharacterController cc;
    Animator playeranim;

    [SerializeField] float speed;
    [SerializeField] float gravity;
    [SerializeField] float jumpForce; 

    void Awake()
    {
        playeranim = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Aplico la gravedad a la fuerza vertical
        playeranim.SetFloat("VerticalSpeed", verticalSpeed);
        verticalSpeed -= gravity * Time.deltaTime;

        //Calculo y aplico la fuerza de movimiento en base al input y la fuerza vertical
        Vector3 mov = new Vector3(0, 0, 0);
        mov += transform.forward * Input.GetAxis("Vertical") * speed;
        mov += transform.right * Input.GetAxis("Horizontal") * speed;
        mov += Vector3.up * verticalSpeed;
        cc.Move(mov * Time.deltaTime);

        //caminar de costado
        if (mov.x < 0)
            playeranim.SetInteger("Strafe", 1);
        if (mov.x > 0)
            playeranim.SetInteger("Strafe", 2);
        if (mov.x == 0)
            playeranim.SetInteger("Strafe", 0);
        //

        if (cc.velocity.z!=0)
        {
            playeranim.SetBool("Running", true);
        }
        else
            playeranim.SetBool("Running", false);      

        //Si luego de moverme toque el suelo reseteo la fuerza vertical a 0.
        if (cc.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                verticalSpeed = jumpForce;               
            }
            else
                verticalSpeed = 0;             

        }
        
          

        /*if ((cc.collisionFlags & CollisionFlags.Above) != 0) 
		{
			print ("above");
		}

		if ((cc.collisionFlags & CollisionFlags.Below) != 0) 
		{
			print ("below");
		}

		if ((cc.collisionFlags & CollisionFlags.Sides) != 0) 
		{
			print ("sides");
		}*/
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Instantiate (particlePrefab, hit.point, Quaternion.identity);
    }
}