using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Transform farBlackground, middleBlackground;

    //private float lastXPos;
    private Vector2 lastPos;

    public float minHeight, maxHeight;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        //make the camera move in Y line and in the range of min and max
        //float clampedY = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
        //transform.position = new Vector3(transform.position.x, clampedY,transform.position.z);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minHeight, maxHeight), transform.position.z);

        //float amountToMoveX = transform.position.x - lastXPos ;
        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

        farBlackground.position = farBlackground.position + new Vector3(amountToMove.x, amountToMove.y, 0f);
        //important need to update the lastXpos  

        middleBlackground.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * .5f;

        //lastXPos = transform.position.x ;
        lastPos = transform.position;
    }
}
