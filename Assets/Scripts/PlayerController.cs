using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public float horizontalInput;
   public float speed = 10.0f;
   public float verticalInput;
    private Rigidbody playerRb;
    public float jumpforce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim;

  
   // Start is called before the first frame update
   void Start()
   {
      playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
   }


   // Update is called once per frame
   void Update()
   { 
         if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
              isOnGround = false;
              playerAnim.SetTrigger("Jump_trig");
        }
       
       horizontalInput = Input.GetAxis("Horizontal");
       verticalInput = Input.GetAxis("Vertical");

       if(verticalInput > 0)
       {
          playerAnim.SetBool("Static_b", true);
          playerAnim.SetFloat("Speed_f", 1);
        
       }
        else
        {
          playerAnim.SetFloat("Speed_f", 0.23f);
        
        }
         Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
          movement = transform.TransformDirection(movement);
          transform.Translate(movement * speed * Time.deltaTime, Space.World);

        
   }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;

        } 
    }
}



