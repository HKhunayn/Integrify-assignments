using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatAmClickingAt : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]LayerMask layerMask;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        { 
            Ray r =Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(r, out hit, layerMask))
                Debug.Log($"You just clicked at {hit.collider}");
        }
    }


}
