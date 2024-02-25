using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    void Awake() 
    {
        Debug.Log("Awake");
        DontDestroyOnLoad(gameObject);
        
    }
    void Start()
    {
        Debug.Log("Start");
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
        var player =FindAnyObjectByType<BasicsMovment>();
        Debug.Log(player.transform);
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }
}
