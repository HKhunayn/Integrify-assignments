using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public float speed= 500;
    public Vector3 Direction = Vector3.forward;
    private Transform target;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,5f);
        //GetComponent<Rigidbody>().AddForce(Vector3.forward * speed,ForceMode.Acceleration);
        rb = GetComponent<Rigidbody>(); 
        //rb.velocity = (target.position - Direction).normalized * speed;

    }
    public void SetDirection(Vector3 target,float speed) 
    { 
        this.speed = speed;
        Direction = target;
        transform.LookAt(transform.position+ Direction);
        StartCoroutine(IShoot());
    }
    public void SetTarget(Transform target,float speed) 
    { 
        this.target = target;
        SetDirection(target.position,speed);
    }
    void OnCollisionEnter(Collision C)
    {
        if (C.gameObject.tag == "Destroyable")
        {
            // death
            GUIManger.Instance.AddScore(1);
            Destroy(C.gameObject);
            Destroy(gameObject);
        }
        else if (C.gameObject.CompareTag("Player")) 
        {
            SceneLoader.Instance.LoadScene(SceneManager.GetSceneByBuildIndex(0).name);
            Debug.Log("You dead");
            Destroy(gameObject);
        }
            
    }

    IEnumerator IShoot() 
    {
        while (true) 
        {
            yield return new WaitForFixedUpdate();
            if (target != null) 
            {
                transform.LookAt(target);
                rb.velocity = (target.position - transform.position).normalized * speed;
            }
            else
                rb.velocity = Direction.normalized * speed;
        }
    }
}
