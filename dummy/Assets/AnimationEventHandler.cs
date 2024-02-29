using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    BasicsMovment bs;
    [SerializeField] Transform hand;
    void Start()
    {
        bs = GetComponentInParent<BasicsMovment>();
    }

    public void ShootBullet() 
    {
        bs.Shoot(hand.position);
    }
}
