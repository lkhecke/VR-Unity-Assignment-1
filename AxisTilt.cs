using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisTilt : MonoBehaviour
{    
    void Start() {}

    void Update() {
        // transform.Rotate(new Vector3(0,23.5,0));
        // transform.RotateAround(transform.position, transform.up, 23.5);
        transform.Rotate(0.0f, 23.5f, 0.0f, Space.Self);
    }
}