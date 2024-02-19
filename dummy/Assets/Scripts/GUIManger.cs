using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GUIManger : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    private static GUIManger instance;
    public static GUIManger Instance 
    {
        get
        {
            if (instance == null)
                Instantiate(Resources.Load<GameObject>("GUIManger"));
            return instance;
        } 
        private set 
        {
            instance = value;
        } 
    }


    int score = 0;
    void Awake()
    {
        if (instance == null)
            instance = this;
        UpdateScore();
    }


    private void OnDestroy()
    {
        if (instance != null)
            instance = null;
    }

    public void AddScore(int score) 
    {
        score++;
        UpdateScore();
    }


    void UpdateScore() 
    {
        scoreText.text = "Score:"+score;
    }




    public void ChangeTimeScale(float scale) 
    {
        Time.timeScale = scale;
    }
}
