using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidBody;  //get reference to rigid body
    private Animator playerAnimation;  //get reference to animator, add animator variable which is playerAnimation
    private AudioSource playerAudio;   //audiosource variable called playerAudio to emit sound 
    public ParticleSystem explosionParticle;  //explosion effect
    public ParticleSystem dirtParticle;  //running effect
    public AudioClip jumpSound;     //sound effect for jumping
    public AudioClip crashSound;    //sound effect for crashing
    public float jumpForce = 100.0f;
    public float gravityModifier; //gravityModifier variable is to set the value of gravity
    public bool playerIsOnGround = true;  //boolean is to hold true or false
    public bool gameOver;

    //a complete method to set the playerIsOnGround back to True by using collision between player and ground
    //to test if player collides with Obstacle or Ground
    //OnCollisionEnter is a collider method
    //avoid player double jump 
    private void OnCollisionEnter (Collision collision){ //collision is the object that we colliding with

    if (collision.gameObject.CompareTag("Ground")){

        playerIsOnGround = true; //when the player on the ground (collides with ground)
        dirtParticle.Play();  //play the dirt particle effect when player is on ground

    }else if (collision.gameObject.CompareTag("Obstacle")){

        Debug.Log ("Game Over !");
        gameOver=true;

        //Dying animation for collision with obstacle
        //Conditions for Death_01 in Death layers
        playerAnimation.SetBool("Death_b", true); //Death_b is a boolean type
        playerAnimation.SetInteger("DeathType_int", 1); //DeathType_1 is a integer variable
        explosionParticle.Play();  //play the explosion effect once the player hit the obstacle
        dirtParticle.Stop();  //stop dirt particle effect when the player died
        playerAudio.PlayOneShot(crashSound, 0.5f);
    }
        
    }
    
    // Start method is called before the first frame update
    void Start()
    {
        // inside <> can be Rigidbody/Collider/Box Collider/etc
        playerRigidBody = GetComponent <Rigidbody> (); //get the component of the Rigidbody for the Player
        playerAnimation = GetComponent <Animator>();   //assign the animator variable which is playerAnimation to the animator component
        playerAudio = GetComponent <AudioSource>();    //get the component of AudioSource for the player

        //player will start to jump once play the game
      //playerRigidBody.AddForce(Vector3.up * 1000 ); 

        //call gravity from Physics component
        //same as Physics.gravity = Physics.gravity * gravityModifier;
        Physics.gravity *= gravityModifier;
    }

    // Update method is called once per frame
    void Update()
    {
        //some ways to write (gameOver == false) to avoid player from jumping after game is over
        //(gameOver != true) means if gameOver is not equal to true
        //(!gameOver)
        if(Input.GetKeyDown(KeyCode.Space) && playerIsOnGround && gameOver != true){  //Input.GetKeyDown(WHAT KEY YOU WANT?)

        //using RigidBody component, it ady has a method called AddForce()
        //player only will jump when space key is pressed
        playerRigidBody.AddForce(Vector3.up * jumpForce , ForceMode.Impulse); //ForceMode.Impulse give impulsive force to object to move
        playerIsOnGround = false; //when player jumps, it is not on ground so is False

        //Jumping animation
        //to activate the jumping action, set the trigger for jump animation
        playerAnimation.SetTrigger("Jump_trig");  //Jump_trig is a parameter from the jumping layer 

        //stop the dirt particle effect while jumping
        dirtParticle.Stop();  

        //play the sound effect when the player jumps
        playerAudio.PlayOneShot(jumpSound, 1.5f);  //play one shot 

        }
    }


}
