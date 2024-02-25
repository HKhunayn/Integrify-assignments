using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathTesting : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float multiplier;
    [SerializeField] Vector3 initPos;
    [SerializeField] Vector3 direction;
    [SerializeField] float length;
    void Start()
    {
        initPos = transform.position;
        Debug.Log(initPos.magnitude);
        StartCoroutine(IDrawLine());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = initPos + new Vector3(multiplier * Mathf.Sin(Time.time), 0, multiplier * Mathf.Sin(Time.time - 90));
    }



    IEnumerator IDrawLine() 
    { 
        while (true) 
        {
            Vector3 endPoint = initPos + (direction.normalized * length);
            Vector3 arrowpoint1 = endPoint + new Vector3(-direction.normalized.y, direction.normalized.x,0)*0.2f* length;
            Vector3 arrowpoint2 = endPoint + new Vector3(direction.normalized.y, -direction.normalized.x,0)*0.2f* length;
            Vector3 pointy = endPoint + (direction.normalized * length * 0.3f);
            Debug.DrawLine(initPos, endPoint, Color.red);
            Debug.DrawLine(arrowpoint1, endPoint, Color.red);
            Debug.DrawLine(arrowpoint2, endPoint, Color.red);

            Debug.DrawLine(pointy, endPoint, Color.red);
            Debug.DrawLine(arrowpoint1, pointy, Color.red);
            Debug.DrawLine(arrowpoint2, pointy, Color.red);

            yield return new WaitForFixedUpdate();
        }


    }

}
