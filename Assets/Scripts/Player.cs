using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null; 
    [SerializeField] private LayerMask playerMask; 

    bool isJumpPressed; 
    Rigidbody rigidBody;  
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            isJumpPressed = true; 
        }

        
    }
    private void FixedUpdate() {
         if(Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length > 0){
            Debug.Log("RocketDog, you are dead");
        }
        if(isJumpPressed){
           rigidBody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);

            isJumpPressed = false;
        }
    }

    
}
