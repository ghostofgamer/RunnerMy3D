using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private PlayerInputs _playerInputs;
    public Vector2 MoveInput => _playerInputs.Player.Move.ReadValue<Vector2>();
    public event Action Jumped;
    public event Action<Vector2> MovePerformed;

    private void Awake()
    {
        _playerInputs = new PlayerInputs();
        //_playerInputs.Player.Jump.performed += ctx => Jumping();
        _playerInputs.Player.Jump.performed += _ => Jumped?.Invoke();
        _playerInputs.Player.Move.performed += _ => MovePerformed?.Invoke(_.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        _playerInputs.Enable();
    }

    private void OnDisable()
    {
        _playerInputs.Disable();
    }

    private void Jumping()
    {
        print("аахаххахаха");
    }
}
