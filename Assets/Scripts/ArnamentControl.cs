using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArnamentControl : MonoBehaviour
{

    public float RightTrigger = 0f;
    public float LeftTrigger = 0f;

    public Transform[] AirToAirMissiles;
    public Transform[] AirToGroundMissiles;
    public Transform[] AirToGroundGuidedBombs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RightTrigger = Input.GetAxis("RightTrigger");
        LeftTrigger = Input.GetAxis("LeftTrigger");
        
    }
}
