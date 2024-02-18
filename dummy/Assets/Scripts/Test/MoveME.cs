using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveME : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] int numberOfObjects = 20;
    [SerializeField] float timeBetweenObjects;
    [SerializeField]List<Vector3> pos;
    [SerializeField] float speed= 0.1f;
    [SerializeField] float delay=0.05f;
    [SerializeField] MotionMethod motion;
    [SerializeField] string parentName;
    GameObject parent;
    List<GameObject> objects;
    enum MotionMethod { Slerp, Lerp }
    void Start()
    {
        parent = Instantiate(new GameObject());
        parent.transform.name = parentName;
        objects = new List<GameObject>();

        SpawnAllObjs();
        StartCoroutine(IMotion());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator IMotion() 
    {
        yield return new WaitForSeconds(delay);

                foreach (var obj in objects) 
                {
                    StartCoroutine(IMotion(obj));
                    yield return new WaitForSeconds (delay);
                }
                //yield return new WaitUntil(()=> IEnumsCounters == objects.Count);
                //IEnumsCounters = 0;


    }

    IEnumerator IMotion(GameObject g) 
    {
        int index = 0;
        while (true) 
        {
            while (Vector3.Distance(g.transform.position, pos[index]) > 0.5f)
            {
                if (motion == MotionMethod.Slerp)
                    g.transform.position = Vector3.Slerp(g.transform.position, pos[index], speed);
                else
                    g.transform.position = Vector3.Lerp(g.transform.position, pos[index], speed);

                yield return new WaitForSeconds(delay);

            }
            index++;
            if (index >= pos.Count)
                index= 0;
        }

        //IEnumsCounters++;
    }

    void SpawnAllObjs() 
    {
        for (int i = 0; i < numberOfObjects; i++) 
        { 
            spawnObj();
        }
    }

    void spawnObj() 
    { 
        GameObject g = Instantiate(prefab);
        g.transform.parent = parent.transform;
        g.transform.name = "C:"+objects.Count;
        objects.Add(g);

    }
}
