using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTesting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FireRay();
    }



    void FireRay() 
    { 
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        Debug.DrawRay(ray.origin, ray.direction * 20,Color.red);
        Debug.Log($"Hit={hit.collider}");
    }
}
