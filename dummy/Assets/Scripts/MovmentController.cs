using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentController : MonoBehaviour
{
    [SerializeField] bool isFirstPersionShooter = true;
    [SerializeField] float speed=5f;
    [SerializeField] float camSpeed = 0.1f;
    [SerializeField] Camera thirdPersionShooter;
    [SerializeField] float maxPitch = 90;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // movement
        Vector3 v;
        float vir = Convert.ToInt32(Input.GetKey(KeyCode.W)) - Convert.ToInt32(Input.GetKey(KeyCode.S));
        float her = Convert.ToInt32(Input.GetKey(KeyCode.D)) - Convert.ToInt32(Input.GetKey(KeyCode.A));
        v = ((vir * transform.forward) + (her * transform.right)) * speed;
        rb.velocity += v;

        // rotation
        Vector3 rotationDirection = new Vector3(Input.mousePositionDelta.y, Input.mousePositionDelta.x,0);
        transform.rotation = Quaternion.EulerAngles(rotationDirection + transform.rotation.ToEulerAngles());
        transform.rotation.SetEulerAngles(transform.rotation.x, transform.rotation.y, 0);
        // apply the maxPitch
        transform.rotation = ClampRotation(transform.rotation, new Vector3(maxPitch, 180, 2f));
    }


    Quaternion ClampRotation(Quaternion q, Vector3 bounds)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
        angleX = Mathf.Clamp(angleX, -bounds.x, bounds.x);
        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        float angleY = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.y);
        angleY = Mathf.Clamp(angleY, -bounds.y, bounds.y);
        q.y = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleY);

        float angleZ = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.z);
        angleZ = Mathf.Clamp(angleZ, -bounds.z, bounds.z);
        q.z = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleZ);

        return q.normalized;
    }
}
