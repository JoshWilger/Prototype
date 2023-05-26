using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float playerToCeilGap = 0.3f;

    [SerializeField] private LayerMask ground;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private MeshCollider coll;
    [SerializeField] private Transform cam;

    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;

    private void Update()
    {
        if (!enabled) return;

        float dirX = Input.GetAxisRaw("Horizontal");
        float dirZ = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(dirX, 0f, dirZ).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.AddForce(moveDir * moveSpeed);
        }
    }

    private bool IsACeiling()
    {
        return Physics.BoxCast(coll.bounds.center, coll.bounds.size, Vector3.up, transform.rotation, playerToCeilGap, ground);
    }

    private bool IsGrounded()
    {
        return Physics.BoxCast(coll.bounds.center, coll.bounds.size, Vector3.down, transform.rotation, 0.1f, ground);
    }

    private bool IsAWall(Vector3 direction)
    {
        return Physics.BoxCast(coll.bounds.center, coll.bounds.size, direction, transform.rotation, 0.1f, ground);
    }
}
