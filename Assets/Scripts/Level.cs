using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Level : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform prefabPipeBottom;
    [SerializeField] private Transform prefabPipeTop;
    private float boundaryMaxY = 8f;

    float minPipeHeight = 0.5f;
    float maxPipeHeight =  1.5f;
    void Start()
    {
        
        for(int i = 0; i < 5; i++){
         
            var pipeTop = Instantiate(prefabPipeTop, new Vector3(5f * i, 5f, 0), Quaternion.identity);
            var pipeBottom = Instantiate(prefabPipeBottom, new Vector3(5f * i, 2.6f, 0), Quaternion.identity);

            pipeTop.localRotation *= Quaternion.Euler(180, 0, 0);
            pipeTop.transform.localScale = new Vector3( pipeTop.transform.localScale.x,  
                                                            getRandomPipeHeight(), 
                                                            pipeTop.transform.localScale.z);
            var pipeTopOffset = new Vector3(0, boundaryMaxY - pipeTop.transform.lossyScale.y/2, 0);
            pipeTop.transform.position += pipeTopOffset;
        }
        
    }

    float getRandomPipeHeight(){
        return UnityEngine.Random.Range(minPipeHeight,maxPipeHeight);
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
