using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelection : MonoBehaviour
{
    public float DPadV = 0;
    public float DPadH = 0;

    public string FreeFlightSceneName = "F16_Freeflight";
    public string LandingSceneName = "F16_Takeoff";
    public string TakeoffSceneName = "F16_Landing";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         DPadV = Input.GetAxis("Gears");
         DPadH = Input.GetAxis("DPadHorizontal");

        if(DPadV == 1f)
        {
            SceneManager.LoadScene(FreeFlightSceneName);
        }
        else if (DPadV == -1f)
        {

        }
        else if (DPadH == 1f)
        {
            SceneManager.LoadScene(LandingSceneName);
        }
        else if (DPadH == -1f) 
        {
            SceneManager.LoadScene(TakeoffSceneName);
        }

    }
}
