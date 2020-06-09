using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour{

    private CharacterController controller;
    private Vector3 moveVector;
    private bool isDead = false;
    private float jumpForce = 5.0f;
    [SerializeField] private float speed = 5.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    private float animationDuration = 3.0f; //--------------------------------- Limits how long the animation happens as the run begins.
    private float startTime;
    private Animator anim;

    void Start(){
        anim        = GetComponent <Animator>();
        controller  = GetComponent <CharacterController>();
        startTime   = Time.time;
    }

 
    void Update(){

        if(isDead){
            anim.SetBool("run", false);
            return;
        }

        if(Time.time - startTime < animationDuration){
            controller.Move (Vector3.forward * speed * Time.deltaTime);
            return; //--------------------------------------------------------- Return gets it out of the update function preventing the rest of the code from running as the animation is still running.
        }

        moveVector = Vector3.zero;

        if(controller.isGrounded){//------------------------------------------- If you're on the floor, then you'll be pushed to the floor even more.
            verticalVelocity = (-gravity) * Time.deltaTime; //----------------- Negative gravity.
            if(Input.GetKeyDown(KeyCode.Space)){
                anim.SetBool("jump", true);
                verticalVelocity = jumpForce;
            }
                
        } else {
            anim.SetBool("jump", false);
            verticalVelocity -= gravity * Time.deltaTime;
        }

        //*****X********
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;//--------------- GetAxisRaw is sensitive to the gravity of the keys.
        
        if(Input.GetMouseButton(0)){
            if(Input.mousePosition.x > (Screen.width/2)){//-------------------- Checking if the right half of the screen is being touched.
                moveVector.x = speed;
            } else {
                moveVector.x = -speed;
            }
        }


        //*****Y********
        moveVector.y = verticalVelocity;
        //*****Z********
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);//--------------------- Moving the character forward only...... Time.deltaTime is the time between two frames.
    }

    public void SetSpeed(int modifier){
        speed = 5.0f + modifier;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit){//---------- OnControllerColliderHit is a method in the MonoBehavior class to detect collision.
        if(hit.gameObject.tag == "Enemy"){//------------------------------------ Checking if the object hit has the tag "Enemy".
            Death();
        }
    }

    private void Death(){
        isDead = true;
        GetComponent<Score>().OnDeath();
    }

}