using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour{

    private CharacterController controller;
    private Vector3 moveVector;
    
    private float speed = 5.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    private float animationDuration = 2.0f; //--------------------------------- Limits how long the animation happens as the run begins.

    void Start(){
        controller = GetComponent <CharacterController>();
    }

 
    void Update(){

        if(Time.time < animationDuration){
            controller.Move (Vector3.forward * speed * Time.deltaTime);
            return; //--------------------------------------------------------- Return gets it out of the update function preventing the rest of the code from running as the animation is still running.
        }

        moveVector = Vector3.zero;

        if(controller.isGrounded){
            verticalVelocity = -0.5f;//---------------------------------------- If you're on the floor, then you'll be pushed to the floor even more.
        } else {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        //*****X********
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;//--------------- GetAxisRaw is sensitive to the gravity of the keys.

        //*****Y********
        moveVector.y = verticalVelocity;
        //*****Z********
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);//---------------- Moving the character forward only...... Time.deltaTime is the time between two frames.
    }
}
