using System;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector3> OnMove = new UnityEvent<Vector3>();
    public UnityEvent OnSpacePressed = new UnityEvent();
    public UnityEvent OnResetPressed = new UnityEvent();
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpacePressed?.Invoke();
        }
        Vector3 input = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            input += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            input += Vector3.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            input += Vector3.forward; // Move forward
        }
        if (Input.GetKey(KeyCode.S))
        {
            input += Vector3.back; // Move backward
        }
        OnMove?.Invoke(input);
        if (Input.GetKeyDown(KeyCode.R)){
            OnResetPressed?.Invoke();
        }
    }
}