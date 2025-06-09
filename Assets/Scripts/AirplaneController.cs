using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirplaneController : MonoBehaviour
{
    public bool Controller = false;
    public bool Keyboard = true;


    [SerializeField]
    List<AeroSurface> controlSurfaces = null;
    [SerializeField]
    List<WheelCollider> wheels = null;
    [SerializeField]
    float rollControlSensitivity = 0.2f;
    [SerializeField]
    float pitchControlSensitivity = 0.2f;
    [SerializeField]
    float yawControlSensitivity = 0.2f;

    [Range(0, 1)]
    public float Throttle;
    [Range(-1, 1)]
    public float Pitch;
    [Range(-1, 1)]
    public float Yaw;
    [Range(-1, 1)]
    public float Roll;
    [Range(0, 1)]
    public float Flap;
    [Range(-1, 1)]
    public float GearsAxis;
    [SerializeField]
    Text displayText = null;
    [SerializeField]
    Text VRText = null;

    [SerializeField]
    Canvas MainCanvas = null;
    [SerializeField]
    Canvas VRCanvas = null;

    //Variables to control thrust, throttle and engine
    public float thrustPercent = 0f;
    float thrustControlSpeed = 60F;
    public float brakesTorque = 100f;
    public float engineState = 0f;

    AircraftPhysics aircraftPhysics;
    Rigidbody rb;

    //Reference to afterburner
    public GameObject[] AfterBurner;

    //Variables and references to Landing Gears
    public GameObject[] Gears;
    public float gearsState = 1f;

    //Variables for the airbrake
    public float airbrakeState = 0f;
    public float airbrakeForce = 0f;

    //Variables for landing flaps settings
    public float isLanding = 0f;

    //Gun Settings







    private void Start()
    {
        aircraftPhysics = GetComponent<AircraftPhysics>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Pitch = Input.GetAxis("Vertical");
        Roll = Input.GetAxis("Horizontal");
        Yaw = Input.GetAxis("Yaw");
        Throttle = Input.GetAxis("Throttle");
        GearsAxis = Input.GetAxis("Gears");

        if (Keyboard == true)
        {
            Controller = false;
            //Control Thrust for Keyboard
            if (Input.GetKey(KeyCode.LeftShift))
            {
                thrustPercent = (thrustPercent + 0.01f * Time.deltaTime * thrustControlSpeed) * engineState;
                thrustPercent = Mathf.Clamp(thrustPercent, 0f, 1f);
            }


            if (Input.GetKey(KeyCode.LeftControl))
            {
                thrustPercent = (thrustPercent - 0.01f * Time.deltaTime * thrustControlSpeed) * engineState;
                thrustPercent = Mathf.Clamp(thrustPercent, 0f, 1f);
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                if (gearsState == 0)
                {
                    gearsState = 1;
                }
                else if (gearsState == 1)
                {
                    gearsState = 0;
                }
            }

        }

        if (Controller == true)
        {
            Keyboard = false;
            //Control Thrust for Controller
            thrustPercent = ((Throttle + 1) / 2) * engineState; // map the values of (-1, 1) to (0, 1)
            //thrustPercent = Throttle * engineState;

            if(GearsAxis == 1f)
            {
                gearsState = 0f;
            }
            else if (GearsAxis == -1f)
            {
                gearsState = 1f;
            }
        }

        //Engage Afterburner
        if (thrustPercent >= 1f)
        {
            for(int i = 0; i < AfterBurner.Length; i++)
            {
                AfterBurner[i].SetActive(true);
            }
            

        }
        else
        {
            for (int i = 0; i < AfterBurner.Length; i++)
            {
                AfterBurner[i].SetActive(false);
            }
        }

        //Control Flaps
        if (Input.GetButtonDown("Flaps"))
        {
            if(Flap == 0f && transform.position.y < 5f)
            { 
                Flap = 1f;
                isLanding = 0f;
            }
            else if (Flap == 1) 
            { 
                Flap = 0f;
                isLanding = 0f;
            }
            else
            {
                if (isLanding == 0f)
                {
                    isLanding = 1f;
                }
                else if (isLanding == 1f)
                {
                    isLanding = 0f;
                }
            }
        }
        if (rb.velocity.magnitude > 140)
        {
            Flap = 0f;
            isLanding = 0f;
        }
        

        //Toggle Brakes
        if (Input.GetButtonDown("Brakes"))
        {
            if (brakesTorque > 0)
            {
                brakesTorque = 0;
            }
            else
            {
                brakesTorque = 100f;
            }
        }

        //Toggle Engine
        if (Input.GetButtonDown("Engine"))
        {
            if (engineState == 0f)
            {
                engineState = 1f;
            }
            else if (engineState == 1f) 
            {
                engineState = 0f;
                thrustPercent = 0f;
            }
        }
        
        //Toggle Gears
        if(gearsState == 1f)
        {
            //Gears[0].SetActive(true);
            //Gears[1].SetActive(true);
            //Gears[2].SetActive(true);
        }
        else if (gearsState == 0f)
        {
            //Gears[0].SetActive(false);
            //Gears[1].SetActive(false);
            //Gears[2].SetActive(false);
        }


        //Toggle airbrake
        if(Input.GetButtonDown("Airbrake"))
        {
            if(airbrakeState == 1)
            {
                airbrakeState = 0;
            }
            else if (airbrakeState == 0)
            {
                airbrakeState = 1;
            }
        }

        if (MainCanvas.isActiveAndEnabled)
        {
            //Display statistics and states
            displayText.text = "SPD: " + ((int)(rb.velocity.magnitude * 3.6)).ToString("D3") + " km/h\n";
            if (rb.velocity.magnitude * 3.6 > 1000)
            {

                displayText.text += "MACH: " + System.Math.Round(((rb.velocity.magnitude * 3.6) / 1235), 2) + "\n";
            }

            displayText.text += "ALT: " + ((int)transform.position.y).ToString("D4") + " m\n";
            if (engineState == 0f)
            {
                displayText.text += "ENGN: KILLED\n";
            }
            else
            {
                displayText.text += "ENGN: ON\n";
            }

            if (thrustPercent >= 1f && engineState == 1f)
            {
                displayText.text += "THRTL: " + (int)(thrustPercent * 100) + "%" + " + AFT\n";
            }
            else if (thrustPercent == 0f && engineState == 1f)
            {
                displayText.text += "THRTL: IDLE\n";
            }
            else if ((thrustPercent <= 1f && engineState == 1f))
            {
                displayText.text += "THRTL: " + (int)(thrustPercent * 100) + "%\n";
            }
            else if (engineState == 0f)
            {
                displayText.text += "THRTL: OFF (E)\n";
            }
            if (isLanding == 0f)
            {
                displayText.text += Flap > 0f ? "FLPS: TKFF" + "\n" : "FLPS: OFF" + "\n";
            }
            else
            {
                displayText.text += "FLPS: LNDNG" + "\n";
            }

            if (airbrakeState == 1)
            {
                displayText.text += "AIRBRK: DEPLOYED" + "\n";
            }
            else
            {
                displayText.text += "AIRBRK: OFF" + "\n";
            }
            displayText.text += brakesTorque > 0f ? "BRK: ENGAGED\n" : "BRK: OFF\n";
            displayText.text += gearsState > 0f ? "GEAR: DOWN\n" : "GEAR: UP\n";
        }

        if (VRCanvas.isActiveAndEnabled)
        {
            //Display statistics and states
            VRText.text = "SPD: " + ((int)(rb.velocity.magnitude * 3.6)).ToString("D3") + " km/h\n";
            if (rb.velocity.magnitude * 3.6 > 1000)
            {

                VRText.text += "MACH: " + System.Math.Round(((rb.velocity.magnitude * 3.6) / 1235), 2) + "\n";
            }

            VRText.text += "ALT: " + ((int)transform.position.y).ToString("D4") + " m\n";
            if (engineState == 0f)
            {
                VRText.text += "ENGN: KILLED\n";
            }
            else
            {
                VRText.text += "ENGN: ON\n";
            }

            if (thrustPercent >= 1f && engineState == 1f)
            {
                VRText.text += "THRTL: " + (int)(thrustPercent * 100) + "%" + " + AFT\n";
            }
            else if (thrustPercent == 0f && engineState == 1f)
            {
                VRText.text += "THRTL: IDLE\n";
            }
            else if ((thrustPercent <= 1f && engineState == 1f))
            {
                VRText.text += "THRTL: " + (int)(thrustPercent * 100) + "%\n";
            }
            else if (engineState == 0f)
            {
                VRText.text += "THRTL: OFF (E)\n";
            }
            if (isLanding == 0f)
            {
                VRText.text += Flap > 0f ? "FLPS: TKFF" + "\n" : "FLPS: OFF" + "\n";
            }
            else
            {
                VRText.text += "FLPS: LNDNG" + "\n";
            }

            if (airbrakeState == 1)
            {
                VRText.text += "AIRBRK: DEPLOYED" + "\n";
            }
            else
            {
                VRText.text += "AIRBRK: OFF" + "\n";
            }
            VRText.text += brakesTorque > 0f ? "BRK: ENGAGED\n" : "BRK: OFF\n";
            VRText.text += gearsState > 0f ? "GEAR: DOWN\n" : "GEAR: UP\n";
        }


    }

    private void FixedUpdate()
    {
        SetControlSurfecesAngles(Pitch, Roll, Yaw, Flap);
        aircraftPhysics.SetThrustPercent(thrustPercent);
        foreach (var wheel in wheels)
        {
            wheel.brakeTorque = brakesTorque;
            // small torque to wake up wheel collider
            wheel.motorTorque = 0.01f;    
        }
        ApplyAirBrakes();
    }

    public void SetControlSurfecesAngles(float pitch, float roll, float yaw, float flap)
    {
        foreach (var surface in controlSurfaces)
        {
            if (surface == null || !surface.IsControlSurface) continue;
            switch (surface.InputType)
            {
                case ControlInputType.Pitch:
                    surface.SetFlapAngle(pitch * pitchControlSensitivity * surface.InputMultiplyer);
                    break;
                case ControlInputType.Roll:
                    surface.SetFlapAngle(roll * rollControlSensitivity * surface.InputMultiplyer);
                    break;
                case ControlInputType.Yaw:
                    surface.SetFlapAngle(yaw * yawControlSensitivity * surface.InputMultiplyer);
                    break;
                case ControlInputType.Flap:
                    surface.SetFlapAngle(Flap * surface.InputMultiplyer);
                    break;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
            SetControlSurfecesAngles(Pitch, Roll, Yaw, Flap);
    }

    private void ApplyAirBrakes()
    {
        Vector3 airBrakeForce = -rb.velocity.normalized * airbrakeForce * airbrakeState;
        rb.AddForce(airBrakeForce);
    }

}
