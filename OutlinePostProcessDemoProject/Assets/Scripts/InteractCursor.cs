using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCursor : MonoBehaviour
{
    public bool inspectOptions;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("InteractOptions"))
        {
            inspectOptions = !inspectOptions;
        }

        if (Input.GetButtonDown("Cancel"))
        {
            inspectOptions = true;
        }

        SetCursorState(inspectOptions);
    }

    void SetCursorState(bool locked)
    {
        if (!locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }

        Cursor.visible = locked;
    }
}
