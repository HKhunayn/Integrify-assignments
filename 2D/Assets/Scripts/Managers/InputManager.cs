using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager m_instance;
    public static InputManager Instance { get { return m_instance; } }

    private InputController m_inputControls;

    private void Awake()
    {
        m_instance = this;
    }

    private void OnDestroy()
    {
        m_instance = null;
    }

    private void OnEnable()
    {
        m_inputControls = new InputController();
        m_inputControls.Enable();
    }

    private void OnDisable()
    {
        m_inputControls.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return m_inputControls.Movment.Direction.ReadValue<Vector2>();
    }
}
