using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualThrottleStickController : MonoBehaviour
{
    public string MasterObjectName = "F16";
    public float ThrottleStickRotationAngle = 5f; // Maximum deflection angle in degrees.
    public float deflectionSpeed = 100f;

    AirplaneController airplaneController;
    GameObject aircraft;

    private Quaternion initialRotation; // Stores the initial rotation of the flaps.
    private Quaternion targetRotation; // 
    // Start is called before the first frame update
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
        targetRotation = initialRotation * Quaternion.Euler(Vector3.up * (airplaneController.thrustPercent * -ThrottleStickRotationAngle));
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, deflectionSpeed * Time.deltaTime);
    }
}
