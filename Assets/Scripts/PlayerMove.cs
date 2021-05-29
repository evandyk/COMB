using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed = 15f;
    public float momentum = 5f;

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

        camAnim.SetBool("IsWalking", isWalking);
    }

    void GetInput()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            isWalking = true;
            inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            inputVector.Normalize();
            inputVector = transform.TransformDirection(inputVector);
        }
        else
        {
            isWalking = false;
            inputVector = Vector3.Lerp(inputVector, Vector3.zero, momentum * Time.deltaTime);
        }

        movementVector = (inputVector * playerSpeed) + (Vector3.up * graviBee);
    }

    void MovePlayer()
    {
        beeCC.Move(movementVector * Time.deltaTime);
    }
}
