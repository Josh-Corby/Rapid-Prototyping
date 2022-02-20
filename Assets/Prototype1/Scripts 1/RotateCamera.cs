using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;
    public PlayerController thePlayer;
    private Vector3 pos;
    //offset for how high the camera is to the player
    public int cameraYOffset;
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
        pos = new Vector3(thePlayer.transform.position.x, cameraYOffset, thePlayer.transform.position.z);
        transform.position = pos;
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
