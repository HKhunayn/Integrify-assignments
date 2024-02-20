using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CorotineTesting : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TMP_Text time;
    void Start()
    {
        StartCoroutine(IScoreAdding());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator IScoreAdding()
    {
        while (true) 
         {
            yield return new WaitUntil(()=>  (Mathf.Abs(Time.time-Mathf.Round(Time.time)) < 0.01f) );
            time.text = Time.time.ToString("F0");
         }
    }
}
