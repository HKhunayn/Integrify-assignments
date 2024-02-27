using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovmentController : MonoBehaviour
{
    [SerializeField] bool isFirstPersionShooter = true;
    [SerializeField] float speed=5f;
    [SerializeField] float jumpPower = 100;
    [SerializeField] float mouseSensitivity = 0.1f;
    [SerializeField] Camera firstPersionShooter;
    [SerializeField] Camera thirdPersionShooter;
    [SerializeField] float maxPitch = 90;
    float x, y;
    Vector3[]initRotation;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initRotation = new Vector3[] {firstPersionShooter.transform.eulerAngles, thirdPersionShooter.transform.eulerAngles };
        if (isFirstPersionShooter)
            firstPersionShooter.gameObject.SetActive(true);
        else
            thirdPersionShooter.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        // movement
        Vector3 v;
        float vir = Convert.ToInt32(Input.GetKey(KeyCode.W)) - Convert.ToInt32(Input.GetKey(KeyCode.S));
        float her = Convert.ToInt32(Input.GetKey(KeyCode.D)) - Convert.ToInt32(Input.GetKey(KeyCode.A));
        v = ((vir * transform.forward) + (her * transform.right)).normalized * speed * Time.deltaTime;
        rb.velocity += v;

        // jump 
        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(Vector3.up*jumpPower,ForceMode.Impulse);

        // rotation
        x-= Input.GetAxis("Mouse Y") * mouseSensitivity;
        y+= Input.GetAxis("Mouse X") * mouseSensitivity;
        x = Mathf.Clamp(x, -maxPitch, maxPitch);

        transform.rotation = Quaternion.Euler(0,y,0);

        GetCurrentCamera().transform.rotation = Quaternion.Euler(x,y,0);


        //transform.rotation = ClampRotation(GetCurrentCamera().transform.rotation,new Vector3(transform.));

        // apply the maxPitch
        //GetCurrentCamera().transform.rotation = ClampRotation(transform.rotation, new Vector3(maxPitch, 180, 2f));
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


    Camera GetCurrentCamera() 
    {
        return isFirstPersionShooter ? firstPersionShooter : thirdPersionShooter;
    }
}
