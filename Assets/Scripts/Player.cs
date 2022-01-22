using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   
    [SerializeField] private LayerMask playerMask; 
    [SerializeField] private GameState gameState;
    [SerializeField] private float jumpPower = 4f;
    
    bool isJumpPressed; 
    
    Rigidbody rigidBody;  

    // Start is called before the first frame update
    void Start()
    {
        gameState.isPlayerDead = false;

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

        if(isJumpPressed){
        //    rigidBody.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            var newVelocity = Vector3.up * jumpPower;
            rigidBody.velocity = newVelocity;

            isJumpPressed = false;
        }
    }

    private void OnCollisionEnter(Collision other) {
        gameState.isPlayerDead = true;
        //Debug.Log("Rocket dog you are dead");
    }

    
}
