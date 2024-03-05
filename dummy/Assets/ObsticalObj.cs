using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObsticalObj : MonoBehaviour
{
    [SerializeField] Vector3 addPos;
    [SerializeField] float animationTime = 0.5f;
    [SerializeField] float animationDelay = 2.0f;
    Vector3 originalPos;

    private void Start()
    {
        originalPos = transform.position;
        StartCoroutine(IObsticalObjCoroutine());
    }
    IEnumerator IObsticalObjCoroutine() 
    { 
    
        while (true) 
        { 
            yield return new WaitForSeconds(animationDelay);
            var tween =transform.DOMove(originalPos + addPos,animationTime);
            yield return tween.IsComplete();

            yield return new WaitForSeconds(animationDelay);
            tween = transform.DOMove(originalPos, animationTime);
            yield return tween.IsComplete();

        }
    }
}
