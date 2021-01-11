﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolWanderingGoomba : MonoBehaviour
{// The movement speed of the object
    public float moveSpeed = 0.2f;
    bool overkill = false;
    bool movingDirection = false;
    // A minimum and maximum time delay for taking a decision, choosing a direction to move in
    public Vector2 decisionTime = new Vector2(1, 4);
    internal float decisionTimeCount = 0;

    // The possible directions that the object can move int, right, left, up, down, and zero for staying in place. I added zero twice to give a bigger chance if it happening than other directions
    internal Vector3[] moveDirections = new Vector3[] { Vector3.right, Vector3.zero, Vector3.left, Vector3.zero };
    internal int currentMoveDirection;
    // Start is called before the first frame update
    void ChooseMoveDirection()
    {
        currentMoveDirection++;
        currentMoveDirection = currentMoveDirection % moveDirections.Length;
    }
    void Start()
    {
        currentMoveDirection = Random.Range(0, moveDirections.Length);
        // Cache the transform for quicker access

        // Set a random time delay for taking a decision ( changing direction, or standing in place for a while )
        decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);

        // Choose a movement direction, or stay in place
        ChooseMoveDirection();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the object in the chosen direction at the set speed
       transform.position += moveDirections[currentMoveDirection] * Time.deltaTime * moveSpeed;

        if (decisionTimeCount > 0) decisionTimeCount -= Time.deltaTime;
        else
        {
            // Choose a random time delay for taking a decision ( changing direction, or standing in place for a while )
            decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);

            // Choose a movement direction, or stay in place
            ChooseMoveDirection();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
          if (collision.tag == "Edge" || collision.tag == "Enemy")
            {
                //Reverse Direction please
                movingDirection = !movingDirection;
                //i like bread
            }
    }
}