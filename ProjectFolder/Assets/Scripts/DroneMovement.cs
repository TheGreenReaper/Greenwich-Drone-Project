﻿using UnityEngine;
using System.Collections;

public class DroneMovement : MonoBehaviour
{
    Rigidbody droneRB;
    public GameObject drone;
    private float upForce;
    private float movementSpeedForward = 500;
    private float tiltAmountForward = 0;
    private float tiltVelocity;
    private float wantedYRotation;
    private float currentYRotation;
    private float rotateAmountByKeys = 1.5f;
    private float rotationYVelocity;
    private Vector3 velocityToSmoothDampToZero;
    private float sideMovementAmount = 300;
    private float tiltAmountSideways;
    private float tiltAmountVelocity;
    GameObject speedCheck;

    void Start()
    {
        drone.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z));
        speedCheck = GameObject.Find("SpeedCheck");
        droneRB = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        print(Input.GetAxis("Horizontal").ToString("F2"));
        print(Input.GetAxis("Vertical").ToString("F2"));
        HorizontalMovement();
        Rotation();
        Swerve();
        VerticalMovement();
        //ClampingSpeedValues();
        droneRB.AddRelativeForce(Vector3.up * upForce);
        drone.transform.rotation = Quaternion.Euler(new Vector3(tiltAmountForward, currentYRotation, tiltAmountSideways));
        droneRB.rotation = Quaternion.Euler(new Vector3(0, currentYRotation, 0));
    }

    void VerticalMovement()
    {
        if(Input.GetAxis("LeftVertical") > 0)
        {
            upForce = 250;
        }
        else if (Input.GetAxis("LeftVertical") < 0)
        {
            upForce = -150;
        }
        else 
        {
            upForce = 98.1f;         
        }

    }
    void HorizontalMovement()
    {
         //save
        if (Input.GetAxis("RightVertical") > 0)
        {
            droneRB.AddRelativeForce(Vector3.forward * movementSpeedForward);

        }
        else if (Input.GetAxis("RightVertical") < 0)
        {
            droneRB.AddRelativeForce(-Vector3.forward * movementSpeedForward);

        }
        //tiltAmountForward = Mathf.SmoothDamp(tiltAmountForward, 20 * Input.GetAxis("RightStickVertical"), ref tiltVelocity, 0.01f);

    }
    void Rotation()
    {
        if (Input.GetAxis("LeftHorizontal") < 0)
        {
            wantedYRotation -= rotateAmountByKeys;
        }
        if (Input.GetAxis("LeftHorizontal") > 0)
        {
            wantedYRotation += rotateAmountByKeys;
        }
        currentYRotation = Mathf.SmoothDamp(currentYRotation, wantedYRotation, ref rotationYVelocity, 0.25f);
    }
    void ClampingSpeedValues()
    {
        if (Mathf.Abs(Input.GetAxis("RightStickVertical")) > 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            droneRB.velocity = Vector3.ClampMagnitude(droneRB.velocity, Mathf.Lerp(droneRB.velocity.magnitude, 10, Time.deltaTime * 5f));
        }
        if (Mathf.Abs(Input.GetAxis("RightStickVertical")) > 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f)
        {
            droneRB.velocity = Vector3.ClampMagnitude(droneRB.velocity, Mathf.Lerp(droneRB.velocity.magnitude, 10, Time.deltaTime * 5f));
        }
        if (Mathf.Abs(Input.GetAxis("RightStickVertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) > 0.2f)
        {
            droneRB.velocity = Vector3.ClampMagnitude(droneRB.velocity, Mathf.Lerp(droneRB.velocity.magnitude, 5, Time.deltaTime * 5f));
        }
        if (Mathf.Abs(Input.GetAxis("RightStickVertical")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal")) < 0.2f)
        {
            droneRB.velocity = Vector3.SmoothDamp(droneRB.velocity, Vector3.zero, ref velocityToSmoothDampToZero, 0.95f);
        }
    }
    void Swerve()
    {
        if (Mathf.Abs(Input.GetAxis("RightHorizontal")) > 0.2f)
        {
            droneRB.AddRelativeForce(Vector3.right * Input.GetAxis("RightHorizontal") * sideMovementAmount);
            tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, -20 * Input.GetAxis("RightHorizontal"), ref tiltAmountVelocity, 0.5f);
        }
        else
        {
            tiltAmountSideways = Mathf.SmoothDamp(tiltAmountSideways, 0, ref tiltAmountVelocity, 0.1f);
        }
    }
    void CheckKey()
    {
        if (Input.GetButtonDown("FireLeft"))
        {
            print("Fired left");
        }


    }
    void OnCollisionEnter(Collision other)
    {
        float x, y, z;
        x = speedCheck.GetComponent<SpeedCheck>().speed.x;
        y = speedCheck.GetComponent<SpeedCheck>().speed.y;
        z = speedCheck.GetComponent<SpeedCheck>().speed.z;
        if (x < 0)
            x *= -1;
        if (y < 0)
            y *= -1;
        if (z < 0)
            z *= -1;
        float combinedVelocity = x + y + z;
        if (combinedVelocity > 10)
        {
            
        }
        
    }
}
