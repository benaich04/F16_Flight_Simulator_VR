using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualControlStickControl : MonoBehaviour
{
    public string MasterObjectName = "F16";
    public float AllDirectionDeflectionAngle = 10f; // Maximum deflection angle in degrees.
    public float deflectionSpeed = 100f;

    AirplaneController airplaneController;
    GameObject aircraft;

    private Quaternion initialRotation; // Stores the initial rotation of the flaps.
    private Quaternion targetRotation; // 
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
        targetRotation = initialRotation * Quaternion.Euler(Vector3.forward * (airplaneController.Pitch * AllDirectionDeflectionAngle) + Vector3.right * (airplaneController.Roll * AllDirectionDeflectionAngle));
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, deflectionSpeed * Time.deltaTime);
    }
}
