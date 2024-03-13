using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SDA/BulletData")]
public class BulletData : ScriptableObject
{
    [SerializeField] public float speed;
    [SerializeField] public float duration;
}
