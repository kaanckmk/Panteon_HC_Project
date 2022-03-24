using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidewayMovement : Movement
{
    [SerializeField] private MouseInput _mouseInput;


    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, PlatformData.MINPLATFORMXBOUNDRY, PlatformData.MAXPLATFORMXBOUNDRY),
                                                    transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        Move(new Vector3(_mouseInput.MoveFactorX, 0f, 0f));
    }
}
