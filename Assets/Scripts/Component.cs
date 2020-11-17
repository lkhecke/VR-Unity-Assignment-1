using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Component : MonoBehaviour
{
    public float rotationSpeed;

    void Start() {
        rotationSpeed = 5;
    }

    void Update() {
        // earthAxis.transform.localRotation = Quaternion.Euler(0.0f, 23.5f, 0.0f);
        // earth.transform.RotateAround(sun.transform.position, sun.transform.up, 50*Time.deltaTime);
        // moon.transform.RotateAround(earth.transform.position, earth.transform.up, 100*Time.deltaTime);

		// go.transform.Rotate(new Vector3 (0, 45, 0) * Time.deltaTime);
        transform.Rotate(new Vector3 (0, rotationSpeed, 0) * Time.deltaTime, Space.Self);

    }
}