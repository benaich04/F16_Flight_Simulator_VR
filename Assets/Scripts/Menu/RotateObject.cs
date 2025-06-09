using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 30f;

    // Update is called once per frame
    void Update()
    {
        // Rotate the object constantly around its up axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
