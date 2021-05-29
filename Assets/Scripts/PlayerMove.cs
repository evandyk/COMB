using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed = 20f;
    private CharacterController beeCC;
    public Animator camAnim;
    private bool isWalking;

    private Vector3 inputVector;
    private Vector3 movementVector;
    private float graviBee = -10f;

    // Start is called before the first frame update
    void Start()
    {
        beeCC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MovePlayer();
        CheckForHeadbob();

        camAnim.SetBool("IsWalking", isWalking);
    }

    void GetInput()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        inputVector.Normalize();
        inputVector = transform.TransformDirection(inputVector);

        movementVector = (inputVector * playerSpeed) + (Vector3.up * graviBee);
    }

    void MovePlayer()
    {
        beeCC.Move(movementVector * Time.deltaTime);
    }

    private void CheckForHeadbob()
    {
        if (beeCC.velocity.magnitude > .1f)
            isWalking = true;
        else
            isWalking = false;
    }
}
