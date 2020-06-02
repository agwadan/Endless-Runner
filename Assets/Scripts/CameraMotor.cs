using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour{

    private Transform lookAt;
    private Vector3 startOffSet;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float animationDuration = 2.0f; //---------------------------- Limits how long the animation happens as the run begins.
    private Vector3 animationOffset = new Vector3 (0, 5, 5);
    void Start(){
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffSet = transform.position - lookAt.position;
    }
    void Update(){
        moveVector = lookAt.position + startOffSet; //-------------------- Of the camera.
        
        //X
        moveVector.x = 0;

        //Y
        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);//---------------- The vertical displacement is restricted to stay between 3 and 5.
        
        if(transition  > 1.0f){
            transform.position = moveVector;
        } else {
            /* Animation at the start of the game. */
            transform.position = Vector3.Lerp(moveVector + animationOffset , moveVector, transition);
            transition += Time.deltaTime * (1 / animationDuration);
            transform.LookAt (lookAt.position + Vector3.up);
        }

        
    }
}
