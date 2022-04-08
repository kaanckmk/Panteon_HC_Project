using System;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    private float _lastFrameMousePositionX;
    private float _moveFactorX;
    public float MoveFactorX => _moveFactorX;

    private ScreenGuard _screenGuard;

    private void Awake()
    {
        _screenGuard = new ScreenGuard();
    }

    private void Update()
    {
        _screenGuard.Update();
        
        if (Input.GetMouseButtonDown(0))
        {
            _lastFrameMousePositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            _moveFactorX = Input.mousePosition.x - _lastFrameMousePositionX;
            _lastFrameMousePositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _moveFactorX = 0;
        }
    }
}