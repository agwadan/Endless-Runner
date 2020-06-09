using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotorTest : MonoBehaviour{
    
    private CharacterController cc;
    private Vector3 rollVector;
    private float rollSpeed = 5.0f;
    private float gravity   = 12.0f;
    private float verticalVelocity = 0.0f;
    private int mouseSensitivity = 50;
    private float xRotation = 0f;
    [SerializeField] private new GameObject camera;
    void Start(){
        cc = gameObject.GetComponent<CharacterController>();
    }

void Update(){
        rollVector = Vector3.zero;
        if(cc.isGrounded){
            verticalVelocity = -0.5f;
        } else {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rollVector = transform.right * x + transform.forward * y;
        cc.Move((rollVector * Time.deltaTime * rollSpeed) );

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -20, 20f);

        camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate (Vector3.up * mouseX);
    }
}
