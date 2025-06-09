using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;


public class VoiceWarningSystem : MonoBehaviour
{
    bool hasPassedFloorLevel = false;
    public float FloorLevel = 1000f;
    public float playbackDelay = 3f;

    AudioSource Source;
    public AudioClip AltitudeWarningClip;

    public string MasterObjectName = "F16";
    AirplaneController airplaneController;
    GameObject aircraft;
    float GearState;


    void Start()
    {
        Source = GetComponent<AudioSource>();
        aircraft = GameObject.Find(MasterObjectName);
        airplaneController = aircraft.GetComponent<AirplaneController>();

    }

    void Update()
    {
        GearState = airplaneController.gearsState;
        if (transform.position.y > FloorLevel)
        {
            hasPassedFloorLevel = true;
        }

        if (hasPassedFloorLevel == true && transform.position.y < FloorLevel && GearState == 0f)
        {
            PlayAltitudeWarning();


        }

    }

    public void PlayAltitudeWarning()
    {
        if(AltitudeWarningClip != null && Source != null)
        {
            Source.clip = AltitudeWarningClip;
            if (!Source.isPlaying)
            {
                Source.PlayDelayed(playbackDelay);
            }
            
        }
    }
}
