using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarExerciseScript : MonoBehaviour
{
    GameObject sun;
    GameObject earth;
    GameObject moon;
    
    // Start is called before the first frame update
    void Start()
    {
        // YOUR CODE - BEGIN
        sun = GameObject.Find("Sun");
        earth = GameObject.Find("Earth");
        moon = GameObject.Find("Moon");
        // YOUR CODE - END
    }

    // Update is called once per frame
    void Update()
    {

        // componentScript = earth.GetComponent<ComponentScript>();
        // componentScript.RotatePlanet(moon);
        // componentScript.RotatePlanet(earth);

        // RotatePlanet(earth);

        // earthAxis.transform.localRotation = Quaternion.Euler(0.0f, 23.5f, 0.0f);
        // earth.transform.RotateAround(sun.transform.position, sun.transform.up, 50*Time.deltaTime);
        // moon.transform.RotateAround(earth.transform.position, earth.transform.up, 100*Time.deltaTime);

		// earth.transform.Rotate(new Vector3 (0, 45, 0) * Time.deltaTime);
        // moon.transform.Rotate(new Vector3 (0, 45, 0) * Time.deltaTime);

        // Exercise 1.9
        // Check if unity world matrix is the same as your own GetWorldTransform.
        if (!CompareMatrix(moon))
        {
           Debug.Log("not the same - solve exercise 1.9");
        }

        // Control Speed with Arrow Buttons 
        // Exercise 1.7
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // YOUR CODE - BEGIN
            Component earthComponent = earth.GetComponent<Component>();
            earthComponent.rotationSpeed += 1;
            Component moonComponent = moon.GetComponent<Component>();
            moonComponent.rotationSpeed += 1;
            // YOUR CODE - END
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // YOUR CODE - BEGIN
            Component earthComponent = earth.GetComponent<Component>();
            if (earthComponent.rotationSpeed >= 1) {
                earthComponent.rotationSpeed -= 1;
            }
            
            Component moonComponent = moon.GetComponent<Component>();
            if (moonComponent.rotationSpeed >= 1) {
                moonComponent.rotationSpeed -= 1;
            }   
            // YOUR CODE - END
        }

        // Comment in for exercise 1.8
        RotateAroundParent(earth, 20);
        RotateAroundParent(moon, 10);
    }

    // Exercise 1.8
    void RotateAroundParent(GameObject go, float rotationVelocity)
    {
        // YOUR CODE - BEGIN
        GameObject parentPlanet = go.transform.parent.gameObject;
        go.transform.RotateAround(parentPlanet.transform.position, parentPlanet.transform.up, rotationVelocity * Time.deltaTime);
        // YOUR CODE - END
    }

    // Exercise 1.9
    Matrix4x4 GetWorldTransform(GameObject go)
    {
        Matrix4x4 mat = new Matrix4x4();
        // YOUR CODE - BEGIN

        mat = Matrix4x4.TRS(go.transform.localPosition, go.transform.localRotation, go.transform.localScale) *
        Matrix4x4.TRS(go.transform.parent.parent.localPosition, go.transform.parent.parent.localRotation, go.transform.parent.parent.localScale) *
        Matrix4x4.TRS(go.transform.parent.localPosition, go.transform.parent.localRotation, go.transform.parent.localScale);

        // YOUR CODE - END
        return mat;
    }

    bool CompareMatrix(GameObject go)
    {
        Matrix4x4 unityWorldMat = Matrix4x4.TRS(go.transform.position, go.transform.rotation, go.transform.lossyScale);
        Matrix4x4 ownWorldMat = GetWorldTransform(go);
        if (unityWorldMat == ownWorldMat)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
