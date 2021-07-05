using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private const float moveBy = 7f;
    [SerializeField] float switchLaneSpeed = 7f;
    [SerializeField] float moveSpeed = 5f;
    int currentLane = 1; // 0 left 1 mid 2 right
    private CharacterController playerController;


    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    void Update() // receives inputs from the user and moves player between our 3 lanes
    {
        ReceiveInputs();
        MoveBetweenLanes();
    }

    
    void ReceiveInputs() // part where we receive the input
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("moving left");
            MoveRight(false);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("moving right");
            MoveRight(true);
        }
    }

    private void MoveRight(bool goingRight) // blocking player from getting out of the lanes
    {
        currentLane += (goingRight) ? 1 : -1;
        currentLane = Mathf.Clamp(currentLane, 0, 2);
    }

    private void MoveBetweenLanes() // part where we move our player, between the lanes
    {
        Vector3 targetPos = transform.position.z * Vector3.forward;

        if (currentLane == 0)
        {
            targetPos += Vector3.left * moveBy;
        }
        else if (currentLane == 2)
        {
            targetPos += Vector3.right * moveBy;
        }

        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPos - transform.position).normalized.x * switchLaneSpeed;
        moveVector.z = moveSpeed;

        playerController.Move(moveVector * Time.deltaTime);
    }
}
