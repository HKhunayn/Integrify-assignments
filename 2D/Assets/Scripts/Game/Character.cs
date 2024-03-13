using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Rigidbody2D m_rigidbody;
    private bool m_isMoving;
    private Vector2 m_direction;

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
        return false;
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
}
