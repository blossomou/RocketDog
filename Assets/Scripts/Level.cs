using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Level : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform prefabPipe;
    private float boundaryMaxY = 8f;

    float minPipeHeight = 0.5f;
    float maxPipeHeight =  4f;
    void Start()
    {
        
        for(int i = 0; i < 5; i++){
            var randomPipeHeight = getRandomPipeHeight();
         
            var pipeTop = Instantiate(prefabPipe, new Vector3(5f * i, 0, 0), Quaternion.identity);
            var pipeBottom = Instantiate(prefabPipe, new Vector3(5f * i, 1f, 0), Quaternion.identity);

            Debug.Log(randomPipeHeight/2);
        
            pipeTop.localRotation *= Quaternion.Euler(180, 0, 0);
            var pipeBody = pipeTop.Find("PipeBody");
            pipeBody.transform.localScale = new Vector3(pipeBody.transform.localScale.x,  
                                                            randomPipeHeight, 
                                                            pipeBody.transform.localScale.z);
          var meshFilter = pipeBody.GetComponent<MeshFilter>();
          Debug.Log("MeshFilter.max.y " +  meshFilter.mesh.bounds.max.y );
          Debug.Log("MeshFilter.min.y " +  meshFilter.mesh.bounds.min.y );

          var pipeHeight = meshFilter.mesh.bounds.max.y -  meshFilter.mesh.bounds.min.y;
          pipeTop.position = new Vector3(pipeTop.position.x, boundaryMaxY - pipeHeight/2, pipeTop.position.z);
 
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
