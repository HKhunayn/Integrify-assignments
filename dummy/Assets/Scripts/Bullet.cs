using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed= 500;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,5f);
        //GetComponent<Rigidbody>().AddForce(Vector3.forward * speed,ForceMode.Acceleration);
        GetComponent<Rigidbody>().velocity= Vector3.forward*speed;
    }

    void OnCollisionEnter(Collision C)
    {
        if (C.gameObject.tag == "Destroyable")
        {
            Destroy(C.gameObject);
            Destroy(gameObject);
        }
        else if (C.gameObject.CompareTag("Player")) 
        {
            Debug.Log("You dead");
            Destroy(gameObject);
        }
            
    }


}
