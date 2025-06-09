using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualRightElevatorsControl : MonoBehaviour
{
    public string MasterObjectName = "F16";
    public float PitchDeflectionAngle = 15f; // Maximum deflection angle in degrees.
    public float RollDeflectionAngle = 5f;
    public float deflectionSpeed = 50f; // Speed of deflection.

    AirplaneController airplaneController;
    GameObject aircraft;

    private Quaternion initialRotation; // Stores the initial rotation of the flaps.
    private Quaternion targetRotation; // The rotation the flaps are currently transitioning towards.

    void Start()
    {
        aircraft = GameObject.Find(MasterObjectName);
        airplaneController = aircraft.GetComponent<AirplaneController>();
        // Set the initial rotation of the elevator 
        //transform.localRotation = Quaternion.Euler(defaultX, defaultY, defaultZ);

        // Store the initial rotation of the flaps when the script starts.
        initialRotation = transform.localRotation;
        // Set the target rotation to the initial rotation as a starting point.
        targetRotation = initialRotation;
    }

    void Update()
    {
        targetRotation = initialRotation * Quaternion.Euler(Vector3.forward * (airplaneController.Pitch * PitchDeflectionAngle + airplaneController.Roll * RollDeflectionAngle));
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, deflectionSpeed * Time.deltaTime);
    }
}
