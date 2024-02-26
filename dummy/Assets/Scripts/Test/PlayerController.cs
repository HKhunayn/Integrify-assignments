using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed=5;
    [SerializeField] Transform cam;
    [SerializeField] Transform body;
    [SerializeField] float camSpeed= 1;
    [SerializeField] Vector3 camOffset = new Vector3(0,5f,0);
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 v;
        float vir = Convert.ToInt32(Input.GetKey(KeyCode.W)) - Convert.ToInt32(Input.GetKey(KeyCode.S));
        float her = Convert.ToInt32(Input.GetKey(KeyCode.D)) - Convert.ToInt32(Input.GetKey(KeyCode.A));
        v = ((vir*transform.forward) + (her* transform.right)) * speed;
        rb.velocity = v;
        //Debug.Log(transform.forward);
        cam.position = Vector3.Lerp(cam.position, body.position + camOffset, camSpeed);
        Vector3 rotation = Vector3.up* (Input.mousePositionDelta.x);
        transform.Rotate(rotation);

        Vector3 playerDic = transform.position - cam.position;
        playerDic = playerDic.normalized;
        cam.rotation = Quaternion.EulerAngles(playerDic);
    }


    private void LateUpdate()
    {
        
    }
}
