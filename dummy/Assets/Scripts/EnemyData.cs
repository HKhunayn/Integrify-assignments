using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Data/EnemyData")]

public class EnemyData : ScriptableObject
{
    [SerializeField] private float m_delay;
    public float Delay => m_delay;

    [SerializeField] private float m_bulletSpeed;

    public float BulletSpeed => m_bulletSpeed;
}
