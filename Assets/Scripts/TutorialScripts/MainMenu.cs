using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{
    public bool takeoff = false;
    public bool landing = false;
    public void StartGame()
    {
        if (takeoff)
        {
            SceneManager.LoadScene("F16_Takeoff"); // Replace "GameScene" with the name of your game scene
        }
        if (landing)
        {
            SceneManager.LoadScene("F16_Landing");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
