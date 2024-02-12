using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolOfObjects : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] float timeToReCall = 4f;
    [SerializeField] float numberOfObjects = 50f;
    [SerializeField] Vector3 force;
    [SerializeField] int M_speed;
    [SerializeField] float m_blabla;
    List<GameObject> objs = new List<GameObject>();
    void Start()
    {
        StartCoroutine(ThePool());
        //Camera.main.transform.LookAt(transform.position);
    }

    IEnumerator ThePool()
    {
        while (true) 
        {
            for (int i = 0; i < numberOfObjects; i++)
            {
                if (objs.Count - 1 < i)
                    objs.Add( Instantiate(obj,transform.position,obj.transform.rotation));
                else
                {
                    objs[i].transform.position = transform.position;
                }
                objs[i].GetComponent<Rigidbody>().AddForce(force);
                yield return new WaitForSeconds(timeToReCall / numberOfObjects);
            }
        }

    }
}
