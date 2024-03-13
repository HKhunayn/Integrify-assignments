using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 m_direction;
    Rigidbody2D m_Rigidbody;
    [SerializeField]BulletData m_bulletdata;
    float m_initTime;
    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_initTime = Time.time;
    }


    public void Init(Vector3 direction)
    {
        m_direction = direction;
    }

    // Update is called once per frame
    void Update()
    {
        m_Rigidbody.velocity = m_direction * m_bulletdata.speed;
        if (m_bulletdata.duration + m_initTime < Time.time)
            Destroy(gameObject);
    }
}
