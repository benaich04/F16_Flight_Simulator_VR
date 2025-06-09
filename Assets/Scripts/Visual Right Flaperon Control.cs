using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualRightFlaperonControl : MonoBehaviour
{
    public string MasterObjectName = "F16";
    public float maxFlapDeflectionAngle = 25f; // Maximum deflection angle in degrees.
    public float LandingFlapAngle = 10f;
    public float extraDeflectionAngle = 10f; // Extra deflection angle in degrees.
    public float flapSpeed = 50f; // Speed at which the flaps move.

    private bool isFlapOpen = false; // Indicates whether the flap is currently open.
    private bool isLanding = false;

    private Quaternion initialRotation; // Stores the initial rotation of the flaps.
    private Quaternion targetRotation; // The rotation the flaps are currently transitioning towards.

    AirplaneController airplaneController;
    GameObject aircraft;

    private void Start()
    {
        aircraft = GameObject.Find(MasterObjectName);
        airplaneController = aircraft.GetComponent<AirplaneController>();

        // Store the initial rotation of the flaps when the script starts.
        initialRotation = transform.localRotation;
        // Set the target rotation to the initial rotation as a starting point.
        targetRotation = initialRotation;
    }

    private void Update()
    {

        isFlapOpen = (airplaneController.Flap == 1f);
        isLanding = (airplaneController.isLanding == 1f);

        if (isFlapOpen == true)
        {
            // If the flaps are open, set the target rotation to a rotated position with extra deflection.
            targetRotation = initialRotation * Quaternion.Euler(Vector3.back * (maxFlapDeflectionAngle + (airplaneController.Roll * -extraDeflectionAngle)));
        }
        else if (isFlapOpen == false)
        {
            if(isLanding == false)
            {
                // If the flaps are closed, set the target rotation back to the initial rotation.
                targetRotation = initialRotation * Quaternion.Euler(Vector3.back * (airplaneController.Roll * -extraDeflectionAngle));
            }
            else if (isLanding == true)
            {
                targetRotation = initialRotation * Quaternion.Euler(Vector3.back * (airplaneController.Roll * -extraDeflectionAngle + LandingFlapAngle));
            }
            
        }

        // Rotate the flaps smoothly towards the target rotation.
        // This helps in achieving a gradual movement instead of an instant change.
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, flapSpeed * Time.deltaTime);
    }
}
