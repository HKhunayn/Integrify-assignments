using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

public class timeTesting : MonoBehaviour
{
    // Start is called before the first frame update

    string s = "";
    int counter = 0;
    int coroutineHappendFirst=0;
    int invokeHappendFirst = 0;
    [SerializeField] float timeBetweenTests=0.001f;
    [SerializeField] int numberOfTests = 100;
    void Start()
    {
        s = "";
        Coroutine c= StartCoroutine(IBenchmark());
    }

    IEnumerator IBenchmark() 
    {

        while (counter < numberOfTests) 
        {
            s = string.Empty;
            float coroutineTime = Time.time;
            StartCoroutine(UsingCorot(timeBetweenTests));
            yield return new WaitUntil(() => s.Length > 0);
            coroutineTime= Time.time - coroutineTime;

            float involkeTime = Time.time;
            Invoke("UsingInvoke", timeBetweenTests);
            yield return new WaitUntil(() => s.Length > 1);
            involkeTime = Time.time - involkeTime;
            if (coroutineTime > involkeTime)
                coroutineHappendFirst++;
            else if (involkeTime > coroutineTime) 
                invokeHappendFirst++;
            counter++;
        }

            Debug.Log($"The beanchmark finshed, \nCoroutine finshed first in {coroutineHappendFirst} from {counter}\nInvoke finshed first in {invokeHappendFirst} from {counter}");

    }

    void UsingInvoke() 
    {
        s += "I";
    }

    IEnumerator UsingCorot(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        s += "C";

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
            Debug.Log($"s={s}, and its length is {s.Length}");
    }

}
