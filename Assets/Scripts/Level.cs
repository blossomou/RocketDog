using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Level : MonoBehaviour
{
  // Start is called before the first frame update
  [SerializeField] private Transform prefabPipe;
  private float boundaryMaxY = 7f;

  float minPipeScale = 0.5f;
  float maxPipeScale = 4f;
  void Start()
  {

    for (int i = 0; i < 5; i++)
    {

      var pipeTop = Instantiate(prefabPipe, new Vector3(5f * i, boundaryMaxY, 0), Quaternion.identity);
      var pipeBottom = Instantiate(prefabPipe, new Vector3(5f * i, 0, 0), Quaternion.identity);

      // rotate top pipe instance 180 degrees
      pipeTop.localRotation *= Quaternion.Euler(180, 0, 0);

      // Make pipe a random size
      var pipeBody = pipeTop.Find("PipeBody");
      scaleObject(pipeBody, getRandomPipeSize());
      var pipeHeight = pipeBody.GetComponent<Renderer>().bounds.size.y;

      // Move to align top of the pipe with our y boundary
      Vector3 verticalOffset = new Vector3(0, boundaryMaxY - pipeHeight / 2, 0);
      pipeTop.position += verticalOffset;

    }

  }

  public void scaleObject(Transform tf, float newSize)
  {
    Vector3 size = tf.lossyScale;
    size.y = (newSize * tf.localScale.y) / tf.lossyScale.y;
    size.x = tf.localScale.x;
    size.z = tf.localScale.z;
    tf.localScale = size;
  }

  float getRandomPipeSize()
  {
    return UnityEngine.Random.Range(minPipeScale, maxPipeScale);

  }
  // Update is called once per frame
  void Update()
  {

  }
}
