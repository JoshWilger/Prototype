using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    // Update is called once per frame
    private void FixedUpdate()
    {
        // Adapted from https://www.youtube.com/watch?v=4HpC--2iowE
        float dirX = Input.GetAxis("Horizontal");
        float dirZ = Input.GetAxis("Vertical");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;

        transform.Translate(dirX * right.normalized + dirZ * forward.normalized, Space.World); 
    }
}
