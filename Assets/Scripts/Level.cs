using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Level : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform prefabPipeBottom;
    [SerializeField] private Transform prefabPipeTop;

    float minPipeHeight = 0.5f;
    float maxPipeHeight =  1f;
    void Start()
    {
        prefabPipeTop.localRotation *= Quaternion.Euler(180, 0, 0);

        // prefabPipeTop.transform.localScale = new Vector3( prefabPipeTop.transform.localScale.x,  
        //                                                     getRandomPipeHeight(), 
        //                                                     prefabPipeTop.transform.localScale.z);
            // prefabPipeBottom.transform.localScale = new Vector3( prefabPipeTop.transform.localScale.x,  
            //                                                 getRandomPipeHeight(), 
            //                                                 prefabPipeTop.transform.localScale.z);
        
        for(int i = 0; i < 5; i++){
         
            Instantiate(prefabPipeTop, new Vector3(5f * i, 5f, 0), prefabPipeTop.localRotation);
            Instantiate(prefabPipeBottom, new Vector3(5f * i, 2.6f, 0), Quaternion.identity);

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
