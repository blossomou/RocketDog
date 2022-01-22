using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;

    [SerializeField] private GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState.isPlayerDead){
            //Debug.Log("Pipe killed player");
            return;
        }

        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

}
