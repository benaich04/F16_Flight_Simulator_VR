using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualLeadingEdgeFlapControl : MonoBehaviour
{
    public string MasterObjectName = "F16";
    public float LeadingEdgeDeflectionAngle = 10f; // Maximum deflection angle in degrees.
    public float deflectionSpeed = 50f; // Speed of deflection.

    AirplaneController airplaneController;
    GameObject aircraft;

    private Quaternion initialRotation; // Stores the initial rotation of the flaps.
    private Quaternion targetRotation; // The rotation the flaps are currently transitioning towards.
    

    void Start()
    {
        aircraft = GameObject.Find(MasterObjectName);
        airplaneController = aircraft.GetComponent<AirplaneController>();

        // Store the initial rotation of the flaps when the script starts.
        initialRotation = transform.localRotation;
        // Set the target rotation to the initial rotation as a starting point.
        targetRotation = initialRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (airplaneController.Pitch < 0)
        {
            targetRotation = initialRotation * Quaternion.Euler(Vector3.forward * (airplaneController.Pitch * -LeadingEdgeDeflectionAngle));
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, deflectionSpeed * Time.deltaTime);
        }
    }
}
