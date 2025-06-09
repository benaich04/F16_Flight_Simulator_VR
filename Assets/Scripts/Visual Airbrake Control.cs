using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualAirbrakeControl : MonoBehaviour
{
    public string MasterObjectName = "F16";
    public float AirbrakeDeploymentAngle = 25f;   
    public float AibrakeDeploymentSpeed = 50f;   
    public bool invertDirection = false;

    private Quaternion initialRotation; 
    private Quaternion targetRotation;

    AirplaneController airplaneController;
    GameObject aircraft;

    void Start()
    {
        aircraft = GameObject.Find(MasterObjectName);
        airplaneController = aircraft.GetComponent<AirplaneController>();

        initialRotation = transform.localRotation;
        targetRotation = initialRotation;
    }

    // Update is called once per frame
    void Update()
    {
       if (invertDirection == false)
        {
            targetRotation = initialRotation * Quaternion.Euler(Vector3.forward * (AirbrakeDeploymentAngle * airplaneController.airbrakeState));
        }
       else if (invertDirection == true)
        {
            targetRotation = initialRotation * Quaternion.Euler(Vector3.forward * (-AirbrakeDeploymentAngle * airplaneController.airbrakeState));
        }
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, AibrakeDeploymentSpeed * Time.deltaTime);
    }
}
