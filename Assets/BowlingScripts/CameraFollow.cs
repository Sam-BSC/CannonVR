using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //offsets
    public float xOffset;
    public float yOffset = 2;
    public float zOffset = 2;
    //objects
    public Camera followCamera;
    public GameObject bowlingBall;
    // Update is called once per frame
    void Update()
    {
        Vector3 cameraOffset = new Vector3 (xOffset, yOffset, zOffset);
        //sets pos 
        followCamera.transform.position = bowlingBall.transform.position + cameraOffset;
        followCamera.transform.LookAt(bowlingBall.transform);
    }
}
