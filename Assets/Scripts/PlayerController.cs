using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput; // Assets -> Import Package -> CrossPlatformInput


public class PlayerController : MonoBehaviour {

    [Header("General")]
    [Tooltip("In ms^-1")] [SerializeField] float speed = 40f;
    [Tooltip("In m")] [SerializeField] float xRange = 13f;
    [Tooltip("In m")] [SerializeField] float yRange = 9f;
    [SerializeField] GameObject[] guns;

    [Header("Screen-position")]
    [SerializeField] float positionPitchFactor = -1.5f;
    [SerializeField] float controlPitchFactor = -20f;

    [Header("Control-throw")]
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor =-15f;

    float xThrow, yThrow;
    bool isControlsEnabled = true;

    // Update is called once per frame
    void Update ()
    {
        if(isControlsEnabled)
        { 
            MovingShip();
            RotateShip();
            Firing();
        }

    }

    void OnPlayerDeath() //called by string reference (calls message from other script on the same object)
    {
        isControlsEnabled = false;
    }

    private void MovingShip()
    {
        //moving ship horizontal and vertical
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal"); // for keyboard and gamepad
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffset = xThrow * speed * Time.deltaTime;
        float yOffset = yThrow * speed * Time.deltaTime;

        float rawNewXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawNewXPos, -xRange, +xRange);

        float rawNewYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawNewYPos, -yRange, +yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void RotateShip()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yawDueToPosition = transform.localPosition.x * positionYawFactor;
        float yaw = yawDueToPosition;

        float rollDueToControlThrow = xThrow * controlRollFactor;
        float roll = rollDueToControlThrow;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void Firing()
    {
        if(CrossPlatformInputManager.GetButton("Fire"))
        {
            SetGunsActive(true);
        }
        else
        {
            SetGunsActive(false);
        }
    }

    private void SetGunsActive(bool isActive)
    {
        foreach( GameObject gun in guns)
        {
            //gun.SetActive(isActive);

            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        
        }
    }



}
