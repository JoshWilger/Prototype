using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float minZ;
    [SerializeField] private float maxZ;
    [SerializeField] private float shakeAmount;

    public bool shake = false;

    // Update is called once per frame
    private void FixedUpdate()
    {
        float dirX = Input.GetAxis("Horizontal");
        float dirZ = Input.GetAxis("Vertical");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;

        transform.Translate(dirX * right.normalized + dirZ * forward.normalized, Space.World); 
        //new Vector3(player.position.x - 8, player.position.y + (shake ? shakeAmount : 0), player.position.z - 8);
//        transform.LookAt(player);
//        player.transform.LookAt(transform);
        if (shake)
        {
            shakeAmount = -shakeAmount;
        }
    }
}
