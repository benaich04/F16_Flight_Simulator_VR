using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    Text TutorialText = null;
    [SerializeField]
    Text VRTutorialText = null;

    public string MasterObjectName = "F16";

    public bool Takeoff = true;
    public bool Landing = false;
    public bool Maneuvers = false;

    public bool EngineState = false;
    public bool isMaxThrottle = false;
    public bool isMinThrottle = false;
    public bool FlapState = false;
    public bool BrakeState = true;
    public bool GearsState = false;
    public float speed;
    public float altitude;


    AirplaneController airplaneController;
    GameObject aircraft;


    private void Start()
    {
        aircraft = GameObject.Find(MasterObjectName);
        airplaneController = aircraft.GetComponent<AirplaneController>();
        rb = aircraft.GetComponent<Rigidbody>();

        if (Landing == true)
        {
            rb.velocity = transform.forward * 165; //Initial velocity 150 m/s
            airplaneController.engineState = 1f;
            airplaneController.thrustPercent = 0.7f;
            airplaneController.gearsState = 0f;
            airplaneController.brakesTorque = 0f;

        }


    }

    // Update is called once per frame
    void Update()
    {

        EngineState = (airplaneController.engineState == 1f);
        BrakeState = (airplaneController.brakesTorque == 100f);
        FlapState = (airplaneController.Flap == 1f);
        isMaxThrottle = (airplaneController.thrustPercent >= 1f);
        GearsState = (airplaneController.gearsState == 1f);
        speed = rb.velocity.magnitude * 3.6f;
        altitude = transform.position.y;

        if (Takeoff == true)
        {
            runTakeoffTutorial();
        }
        else if (Landing == true)
        {
            runLandingTutorial();
            
        }

    }

    void runTakeoffTutorial()
    {

        if (EngineState == false)
        {
            TutorialText.text = "Toggle the Engine\n";
        }
        else
        {
            if (BrakeState == true)
            {
                TutorialText.text = "Disengage the Brakes\n";
            }
            else
            {
                if (FlapState == false && speed < 300)
                {
                    TutorialText.text = "Lower the Flaps\n";
                }
                else
                {
                    if (isMaxThrottle == false)
                    {
                        TutorialText.text = "Move Throttle to 100%\n" + "Engage the Afterburner\n";
                    }
                    else
                    {
                        if (altitude < 10f)
                        {
                            TutorialText.text = "Increase Pitch\n";
                        }
                        else
                        {
                            if (FlapState == true && speed > 250)
                            {
                                TutorialText.text = "Raise the Flaps\n";
                            }
                            else
                            {
                                if (GearsState == true)
                                {
                                    TutorialText.text = "Raise the Gears\n";
                                }
                                else
                                {
                                    TutorialText.text = "Takeoff Successful!\n";
                               
                                }
                            }
                        }
                    }
                }
            }
        }

        if (EngineState == false)
        {
            VRTutorialText.text = "Toggle the Engine\n";
        }
        else
        {
            if (BrakeState == true)
            {
                VRTutorialText.text = "Disengage the Brakes\n";
            }
            else
            {
                if (FlapState == false && speed < 300)
                {
                    VRTutorialText.text = "Lower the Flaps\n";
                }
                else
                {
                    if (isMaxThrottle == false)
                    {
                        VRTutorialText.text = "Move Throttle to 100%\n" + "Engage the Afterburner\n";
                    }
                    else
                    {
                        if (altitude < 10f)
                        {
                            VRTutorialText.text = "Increase Pitch\n";
                        }
                        else
                        {
                            if (FlapState == true && speed > 250)
                            {
                                VRTutorialText.text = "Raise the Flaps\n";
                            }
                            else
                            {
                                if (GearsState == true)
                                {
                                    VRTutorialText.text = "Raise the Gears\n";
                                }
                                else
                                {
                                    VRTutorialText.text = "Takeoff Successful!\n";
                                    
                                }
                            }
                        }
                    }
                }
            }
        }

        
    }


    void runLandingTutorial()
    {
        if (airplaneController.thrustPercent > 0.4f)
        {
            TutorialText.text = "Decrease Throttle to 40%\n";
        }
        else
        {
            if (speed > 500f)
            {
                TutorialText.text = "Deploy Airbrakes\n";
            }
            else
            {
                if(speed < 350f)
                {
                    if(airplaneController.isLanding == 0f || GearsState == false)
                    {
                        TutorialText.text = "Deploy Ladning Flaps\n" + "Deploy Landing Gears\n";
                    }
                    else
                    {
                        TutorialText.text = "Approach the Landing Strip\n";
                    }
                    
                    if(altitude < 5f)
                    {
                        TutorialText.text = "Engage Brakes\n";
                        if(speed < 3f)
                        {
                            TutorialText.text = "Stall the Engine\n";
                            if(EngineState == false)
                            {
                                TutorialText.text = "Landing Succesful\n";
                            }
                        }
                    }
                }
            }
        }

        if (airplaneController.thrustPercent > 0.4f)
        {
            VRTutorialText.text = "Decrease Throttle to 40%\n";
        }
        else
        {
            if (speed > 500f)
            {
                VRTutorialText.text = "Deploy Airbrakes\n";
            }
            else
            {
                if (speed < 350f)
                {
                    if (airplaneController.isLanding == 0f || GearsState == false)
                    {
                        VRTutorialText.text = "Deploy Ladning Flaps\n" + "Deploy Landing Gears\n";
                    }
                    else
                    {
                        VRTutorialText.text = "Approach the Landing Strip\n";
                    }

                    if (altitude < 5f)
                    {
                        VRTutorialText.text = "Engage Brakes\n";
                        if (speed < 3f)
                        {
                            VRTutorialText.text = "Stall the Engine\n";
                            if (EngineState == false)
                            {
                                VRTutorialText.text = "Landing Succesful\n";
                            }
                        }
                    }
                }
            }
        }

    }

}
