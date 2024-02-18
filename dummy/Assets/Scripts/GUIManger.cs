using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUIManger : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    private static GUIManger instance;
    int score = 0;
    void Start()
    {
        
        instance = this;
        updateScore();
    }

    public static void AddScore(int score) 
    {
        instance.score++;
        instance.updateScore();
    }


    void updateScore() 
    {
        instance.scoreText.text = "Score:"+score;
    }




    public void ChangeTimeScale(float scale) 
    {
        Time.timeScale = scale;
    }
}
