using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCamMovement : MonoBehaviour
{
    public float speed;
    public float runSpeed;

    public Transform cameraForward;
    public GameObject CMCam;
    public CharacterController charController;

    Vector3 moveInput;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector3(Input.GetAxis("CharMoveHorizontal"), Input.GetAxis("CharMoveVertical"), Input.GetAxis("CharFlightVertical")).normalized;

        float moveSpeed = (Input.GetButton("CharSprint") ? runSpeed : speed) * Time.deltaTime;

        charController.Move(cameraForward.forward * moveInput.y * moveSpeed);
        charController.Move(cameraForward.right * moveInput.x * moveSpeed);
        charController.Move(transform.up * moveInput.z * moveSpeed);
    }

    public void ResetFreeCamMovPos()
    {
        transform.position = startPos;
    }

    public void SetFreeCamMovPos(Vector3 pos)
    {
        transform.position = pos;
    }
}
