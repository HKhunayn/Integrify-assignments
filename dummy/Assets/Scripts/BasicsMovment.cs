using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BasicsMovment : MonoBehaviour
{
    [SerializeField] float speed= 5;
    [SerializeField] float rotationSpeed=5;
    [SerializeField] bool isUsePhysics = true;
    [SerializeField] GameObject bullet;
    void Start()
    {
        //GameObject g = ;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 v;
        float vir = Convert.ToInt32(Input.GetKey(KeyCode.W)) - Convert.ToInt32(Input.GetKey(KeyCode.S));
        float her = Convert.ToInt32(Input.GetKey(KeyCode.D)) - Convert.ToInt32(Input.GetKey(KeyCode.A));
        v = ((vir * transform.forward) + (her * transform.right)) * speed;
        if (!isUsePhysics)
            transform.position += v;
        else
            transform.GetComponent<Rigidbody>().velocity = v;
        /*        if (Input.GetKey(KeyCode.Space))
                    Camera.main.transform.position = transform.position + new Vector3(0,10f,-5f);
                Camera.main.transform.LookAt(transform.position);*/
        transform.Rotate(Vector3.up * rotationSpeed * Input.mousePositionDelta.x);
    }
    void Update() 
    {
        if (Input.GetMouseButtonDown(0))
            shoot();
    }

/*    void UsePosition() 
    {
        Vector3 v = Vector3.zero;
        if (Input.GetKey(KeyCode.S))
            transform.position += new Vector3(0, 0, speed)*speed;
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
    }*/




    void shoot() 
    { 
        GameObject g= Instantiate(bullet,transform.position+ transform.forward,transform.rotation);
        
        g.GetComponent<Bullet>().Direction = transform.forward;
    }
}
