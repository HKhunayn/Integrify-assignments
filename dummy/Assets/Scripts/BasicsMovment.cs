using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BasicsMovment : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool isUsePhysics = true;
    void Start()
    {
        //GameObject g = ;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isUsePhysics)
            UsePosition();
        else
            UsePhy();
        if (Input.GetKey(KeyCode.Space))
            Camera.main.transform.position = transform.position + new Vector3(0,10f,-5f);
        Camera.main.transform.LookAt(transform.position);
    }


    void UsePosition() 
    {
        Vector3 v = Vector3.zero;
        if (Input.GetKey(KeyCode.S))
            transform.position += new Vector3(0, 0, speed);
        if (Input.GetKey(KeyCode.S))
            transform.position += new Vector3(0, 0, -speed);
        if (Input.GetKey(KeyCode.A))
            transform.position += new Vector3(-speed, 0, 0);
        if (Input.GetKey(KeyCode.D))
            transform.position += new Vector3(speed, 0, 0);
        transform.position += v;
        
    }
    void UsePhy() 
    {
        Vector3 v = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            transform.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, speed*100));
        if (Input.GetKey(KeyCode.S))
            transform.GetComponent<Rigidbody>().AddForce(0, 0, -speed*100);
        if (Input.GetKey(KeyCode.A))
            transform.GetComponent<Rigidbody>().AddForce(-speed * 100, 0, 0);
        if (Input.GetKey(KeyCode.D))
            transform.GetComponent<Rigidbody>().AddForce(speed * 100, 0, 0);
    }
}
