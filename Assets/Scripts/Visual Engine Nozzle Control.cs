using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualEngineNozzleControl : MonoBehaviour
{
    public float NozzleDeflectionAngle = 20f;
    public float defaultY;
    public bool InvertDirection = false;

    public float deflectionSpeed = 100f;

    void Start()
    {
        //currentDeflection = defaultY;
        //transform.localRotation = Quaternion.Euler(defaultX, defaultY, defaultZ);


    }

    // Update is called once per frame
    void Update()
    {
        float Throttle = (Input.GetAxis("Throttle") + 1) / 2;
        float targetAngle = 0f;

        if (InvertDirection == false )
        {
            targetAngle = defaultY + Throttle * NozzleDeflectionAngle;
        }
        else if (InvertDirection == true )
        {
            targetAngle = defaultY - Throttle * NozzleDeflectionAngle;
        }


        //transform.RotateAround(transform.position, -transform.right, Time.deltaTime * (150f - deflectionSpeed));





    }
}
