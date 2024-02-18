using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PeformenceMesure : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int FreezeFPSAt = 0;
    [SerializeField] TMP_Text fpsText;
    int frameCounter = 0;
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = FreezeFPSAt;
        StartCoroutine(Counting());
    }

    // Update is called once per frame
    void Update()
    {
        frameCounter++;
    }


    IEnumerator Counting() 
    {
        while (true) 
        { 
            yield return new WaitForSecondsRealtime(1);
            fpsText.text = "FPS:"+ frameCounter.ToString();
            frameCounter = 0;

        }  
    }
}
