using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualRudderControl : MonoBehaviour
{
    public string MasterObjectName = "F16";
    // Public variables that can be adjusted in the Unity Inspector
    public float maxRudderAngle = 25f;   // Maximum rudder deflection angle in degrees
    public float rudderSpeed = 5f;       // Speed of rudder deflection

    private Quaternion initialRotation; // Stores the initial rotation of the flaps.
    private Quaternion targetRotation; // The rotation the flaps are currently transitioning towards.


    AirplaneController airplaneController;
    GameObject aircraft;

    void Start()
    {
        aircraft = GameObject.Find(MasterObjectName);
        airplaneController = aircraft.GetComponent<AirplaneController>();

        // Store the initial rotation of the flaps when the script starts.
        initialRotation = transform.localRotation;
        // Set the target rotation to the initial rotation as a starting point.
        targetRotation = initialRotation;
    }

    void Update()
    {

        targetRotation = initialRotation * Quaternion.Euler(Vector3.up * (maxRudderAngle * airplaneController.Yaw));
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, rudderSpeed * Time.deltaTime);
    }
}
