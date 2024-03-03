using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BasicsMovment : MonoBehaviour
{
    [SerializeField] float movmentSpeed= 4.5f;
    [SerializeField] float shiftspeedMultiplier= 1.3f;
    [SerializeField] float rotationSpeed=5;
    [SerializeField] bool isUsePhysics = true;
    [SerializeField] GameObject bullet;
    [SerializeField]Animator animator;
    PlayerActions playeraction;
    Rigidbody rb;
    void Awake()
    {
        //GameObject g = ;
        //animator =  GetComponent<Animator>();
        playeraction = new PlayerActions();
        playeraction.Enable();
        rb =GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // MOVEMENT

        Vector3 v;
        //float vir = Convert.ToInt32(Input.GetKey(KeyCode.W)) - Convert.ToInt32(Input.GetKey(KeyCode.S));
        //float her = Convert.ToInt32(Input.GetKey(KeyCode.D)) - Convert.ToInt32(Input.GetKey(KeyCode.A));
        Vector2 movement = playeraction.Movement.Move.ReadValue<Vector2>();
        v = ((movement.y * transform.forward) + (movement.x * transform.right)).normalized * movmentSpeed;
        if (movement.y >= 1 && playeraction.Movement.Sprint.IsPressed()) 
        {
            v *= shiftspeedMultiplier;
        }
        rb.velocity = new Vector3(v.x,rb.velocity.y,v.z);


        // ANIMATION
        animator.SetFloat("forward", movement.y);
        animator.SetFloat("right", movement.x);


        //ROTATION
        transform.Rotate(Vector3.up * rotationSpeed * Input.mousePositionDelta.x);
    }
    void Update() 
    {
        if (playeraction.Fight.Fire.IsPressed())
            StartCoroutine(IShoot());
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




    public void Shoot(Vector3 pos) 
    {
        
        
        GameObject g= Instantiate(bullet,pos,transform.rotation);
        
        g.GetComponent<Bullet>().Direction = transform.forward;
        //StartCoroutine(IShoot());
    }

    IEnumerator IShoot() 
    {
        animator.SetBool("isShooting", true);
        yield return null;
        animator.SetBool("isShooting", false);
    }
}
