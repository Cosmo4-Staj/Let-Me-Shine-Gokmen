using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{
    public float speed = 5f;
    public float currentLane = 0f; // -1 left 0 mid 1 right
    public float totalLanes = 3f;
    public float distanceBetweenLanes = 2f;
    public float startingLane = 0f;
    public float switchLanesSpeed = 5f;
    float clamp = 0.1f;
    bool alreadyChangingLanes = false;

void Update()
    {
        float userInput = Input.GetAxis("Horizontal"); // getting left and right inputs.

        MoveForward();
        MoveBetweenLanes(userInput);
    }

    // Method to move between set lanes and prevent user to get out of the lanes.
    private void MoveBetweenLanes(float userInput)
    {
        if (Mathf.Abs(userInput) > clamp)
        {
            if (!alreadyChangingLanes) // preventing user from spamming.
            {
                alreadyChangingLanes = true;
                currentLane += Mathf.RoundToInt(Mathf.Sign(userInput));

                if (currentLane < -1) currentLane = -1;
                else if (currentLane > 1) currentLane = 1;
                else if (currentLane >= totalLanes) currentLane = totalLanes - 1;
            }
        }
        else
        {
            alreadyChangingLanes = false;
        }

        Vector3 pos = transform.position;
        pos.x = Mathf.Lerp(pos.x, startingLane + distanceBetweenLanes * currentLane, Time.deltaTime * switchLanesSpeed);
        transform.position = pos;
    }

    // move forward constantly.
    private void MoveForward()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
