using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*****************************************************
 *  Component of the Vehicle, takes in user input to
 *  move and turn the vehicle
 *  
 *  Logan Rudsenske
 *  September 11, 2023 Version 1
 ****************************************************/

public class PlayerController : MonoBehaviour
{
    private float speed;            // holds the forward movement of the vehicle
    private float turnspeed;        // holds the turn speed of the vehicle
    private float verticalInput;    // gets a value [-1, 1] from user key press up/down or W/S
    private float horizontalInput;  // gets a value [-1, 1] from user key press left/right or A/D

    private Rigidbody rb;           // points to vehicle rigidbody component

    // Initializes speed and turn speed before the first frame update
    void Start()
    {
        speed = 30.0f;
        turnspeed = 30.0f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }




}
