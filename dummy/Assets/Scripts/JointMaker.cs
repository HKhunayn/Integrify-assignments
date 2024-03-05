using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointMaker : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] int numberOfObjects;
    [SerializeField] Vector3 diffPos;
    List<GameObject> objs;
    void Start()
    {
        objs = new List<GameObject>();
        GenerateObjs();

        StartCoroutine(IMove());
    }
    void GenerateObjs()
    {
        for (int i = 0; i < numberOfObjects; i++) 
        {
            GameObject g;
            objs.Add(g=Instantiate(prefab, i* diffPos, Quaternion.identity));
            g.name = i.ToString();
            if (i > 0)
            {
                g.GetComponent<FixedJoint>().connectedBody = objs[i - 1].GetComponent<Rigidbody>();
            }
            if (i == 0) 
            {
                g.GetComponent<Rigidbody>().isKinematic = true;
            }
                
        }
    
    }

    IEnumerator IMove() 
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            objs[0].transform.DOMove(new Vector3(3, 0, 0), 5);
            yield return new WaitForSeconds(3f);
            objs[0].transform.DOMove(new Vector3(-3, 0, 0), 5);
        }
    }

    
}
