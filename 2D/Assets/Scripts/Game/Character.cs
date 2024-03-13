using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Character : MonoBehaviour
{

    private Rigidbody2D m_rigidbody;
    private bool m_isMoving;
    private bool m_isShooting;
    private Vector2 m_direction;
    public GameObject m_bullet;
    public CharacterVisual m_characterVisual;
    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    protected void Move(Vector2 direction, float speed)
    {
        direction = direction.normalized;
        m_rigidbody.velocity = direction * speed;

        m_isMoving = direction.magnitude > 0.1f;
        if (m_isMoving)
            m_direction = direction;
    }

    public bool IsShooting()
    {
        return m_isShooting;
    }
    public void SetIsShooting(bool state) 
    {
        m_isShooting = state;
        if (state)
            Shoot();
    }
    public CharacterWeapon GetWeapon()
    {
        return CharacterWeapon.Rifle;
    }

    public bool IsMoving()
    {
        return m_isMoving;
    }

    public Vector2 GetMovementDirection()
    {
        return m_direction;
    }

    public void Shoot() 
    { 
        Bullet b = Instantiate(m_bullet,transform.position,Quaternion.EulerAngles(m_direction)).GetComponent<Bullet>();
        b.Init(m_direction);
    }
}
