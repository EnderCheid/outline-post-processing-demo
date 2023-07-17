using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using static Cinemachine.AxisState;


public class CameraMouseInput : MonoBehaviour, IInputAxisProvider
{
    public InteractCursor hud;

    public float GetAxisValue(int axis)
    {
        float mouseSpeed = PlayerPrefs.GetFloat("MouseSpeed", 0.5f);
        Vector2 mouseInput = Vector2.zero;
        if (!hud.inspectOptions)
        {
            mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }

        switch (axis) {
            case 0:
                return mouseInput.x * mouseSpeed;
            case 1:
                return mouseInput.y * mouseSpeed;
            default:
                return 0;

        }
    }
}
