using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int x = 5;
        calculate(out x);
        Debug.Log($"Out side the fun x={x}");
    }

    // Update is called once per frame
    void Update()
    {

    }



    void calculate(out int x) 
    { 
        //Debug.Log($"{x}");
        x = 3;
        Debug.Log($"After={x}");


    }
}
