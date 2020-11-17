using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

// Group:
// Immatriculation Number 1
// Immatriculation Number 2

public class MonkeyExerciseScript : MonoBehaviour
{

    GameObject monkey0;
    GameObject monkey1;
    GameObject monkey2;
    GameObject monkey3;
    GameObject monkey4;
    GameObject monkey5;
    GameObject exerciseText;

    readonly List<GameObject> monkeyHeads = new List<GameObject>();

    // Initial position, rotation and scale values
    readonly List<Vector3> initialPositions = new List<Vector3>();
    readonly List<Quaternion> initialRotations = new List<Quaternion>();
    readonly List<Vector3> initialScales= new List<Vector3>();

    int currentMonkey = 0;
    int currentTask = 1;

    // Start is called before the first frame update
    void Start()
    {
        // Finding and assigning the monkey objects of the scene to variables.
        monkey0 = GameObject.Find("Monkey0");
        monkeyHeads.Add(monkey0);
        monkey1 = GameObject.Find("Monkey1");
        monkeyHeads.Add(monkey1);
        monkey2 = GameObject.Find("Monkey2");
        monkeyHeads.Add(monkey2);
        monkey3 = GameObject.Find("Monkey3");
        monkeyHeads.Add(monkey3);
        monkey4 = GameObject.Find("Monkey4");
        monkeyHeads.Add(monkey4);
        monkey5 = GameObject.Find("Monkey5");
        monkeyHeads.Add(monkey5);

        exerciseText = GameObject.Find("ExerciseText");

        foreach (GameObject monkey in monkeyHeads)
        {
            initialPositions.Add(monkey.transform.position);
            initialRotations.Add(monkey.transform.rotation);
            initialScales.Add(monkey.transform.localScale);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Move monkeys with RightArrow key to test different exercises
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentTask == 1)
            {
                PositionMonkey(currentMonkey);
            }
            else if (currentTask == 2)
            {
                MoveMonkey(currentMonkey);
            }
            else if (currentTask == 3)
            {
                MoveMonkeyWithMatrix(currentMonkey);
            }
            else if (currentTask == 4)
            {
                MoveMonkeyCustom(currentMonkey);
            }
            currentMonkey++; // increase monkey index to next monkey
        }

        // Reset last monkey
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentMonkey > 0) currentMonkey--;
            ResetMonkey(currentMonkey);
        }

        // Go to next task
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentTask < 4) currentTask++;
            exerciseText.GetComponent<Text>().text = "Exercise 1." + currentTask;
            ResetAllMonkeys();
            currentMonkey = 0;
        }

        // Go back to previous task
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentTask > 1) currentTask--;
            exerciseText.GetComponent<Text>().text = "Exercise 1." + currentTask;
            ResetAllMonkeys();
            currentMonkey = 0;
        }
    }

    // Exercise 1.1 
    // transform monkeys to final pose by directly setting their local position, local rotation and local scale.
    void PositionMonkey(int monkeyIndex)
    {
        Debug.Log("Moving monkey " + monkeyIndex);
        switch (monkeyIndex)
        {
            case 0: // transform monkey 0
                monkey0.transform.localPosition = new Vector3(0, 5, -8);
                break;
            // YOUR CODE - BEGIN
            case 1: // transform monkey 1
                monkey1.transform.localPosition = new Vector3(5, 5, -8);
                monkey1.transform.localRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                break;
            case 2: // transform monkey 2
                monkey2.transform.localPosition = new Vector3(10, 5, -8);
                monkey2.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
                break;
            case 3: // transform monkey 3
                monkey3.transform.localPosition = new Vector3(15, 8, -8);
                monkey3.transform.localRotation = Quaternion.Euler(0.0f, -45.0f, -45.0f);
                monkey3.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
                break;
            case 4: // transform monkey 4
                monkey4.transform.localPosition = new Vector3(20, 10, 5);
                monkey4.transform.localRotation = Quaternion.Euler(45.0f, 0.0f, 0.0f);
                monkey4.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
                break;
            case 5: // transform monkey 5
                monkey5.transform.localPosition = new Vector3(25, 10, 0);
                monkey5.transform.localRotation = Quaternion.Euler(0.0f, 180.0f, 180.0f);
                break;
            // YOUR CODE - END
            default:
                currentMonkey = -1;
                ResetAllMonkeys();
                break;
        }
    }

    // Exercise 1.2 
    // transform monkeys to final pose by accumulating translation-, rotation-, scale-input to their actual local transformation, e.g. by monkey0.transform.Translate(...)
    // Hint: Multiple operations of each kind can be executed.
    // Hint: Consider the order of the operations.
    // Hint: Relative scale input might not be supported by Unity itself. In such a case, come up with any solution to set the necessary scale level of the object.
    void MoveMonkey(int monkeyIndex)
    {
        Debug.Log("Moving monkey " + monkeyIndex);
        switch (monkeyIndex)
        {
            // YOUR CODE - BEGIN
            case 0: // transform monkey 0
            monkey0.transform.Translate(Vector3.back * 8.0f);
            break;
            case 1: // transform monkey 1
            monkey1.transform.Rotate(0.0f, 135.0f, 0.0f);
            monkey1.transform.Translate(Vector3.forward * 8.0f);
            break;
            case 2: // transform monkey 2
            monkey2.transform.Rotate(0.0f, -90.0f, 90.0f);
            monkey2.transform.Translate(Vector3.back * 8.0f);
            break;
            case 3: // transform monkey 3
            monkey3.transform.Rotate(0.0f, 180.0f, -45.0f);
            monkey3.transform.Translate(new Vector3(0, 3, -8), Space.World);
            monkey3.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
            break;
            case 4: // transform monkey 4
            monkey4.transform.Rotate(45.0f, 180.0f, 0.0f);
            monkey4.transform.Translate(new Vector3(0, 5, 5), Space.World);
            monkey4.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
            break;
            case 5: // transform monkey 5
            monkey5.transform.Rotate(0.0f, -45.0f, -180.0f);
            monkey5.transform.Translate(new Vector3(0, 5, 0), Space.World);
            break;
            // YOUR CODE - END
            default:
                currentMonkey = -1;
                ResetAllMonkeys();
                break;
        }
    }

    // Exercise 1.3
    // transform monkeys to final pose by accumulating translation-/rotation-/scaling- matrices relative to their local transformation matrix
    // the scheme for the required operations is given in case 0
    void MoveMonkeyWithMatrix(int monkeyIndex)
    {
        switch (monkeyIndex)
        {
            // YOUR CODE - BEGIN
            case 0: // transform monkey 0
                // get the local transformation of this Game Object by creating a TRS matrix
                Matrix4x4 localMat = Matrix4x4.TRS(monkey0.transform.localPosition, monkey0.transform.localRotation, monkey0.transform.localScale);

                // define input matrices for input accumulation (there can be multiple input matrices of each kind - translation, rotatation, and scale)
                Matrix4x4 transInputMat = Matrix4x4.Translate(Vector3.back * 8.0f);

                // accumulate inputs through multiplication of your input matrices to the local transformation matrix of this Game Object 
                // be careful with the order of operations; matrix multiplication is not commutative
                Matrix4x4 newMat = localMat * transInputMat;
                
                // the final computed matrix is applied to transform of the given game object
                SetTransformByMatrix(monkey0, newMat);
                break;
            case 1: // transform monkey 1
                localMat = Matrix4x4.TRS(monkey1.transform.localPosition, monkey1.transform.localRotation, monkey1.transform.localScale);
                Matrix4x4 rotateInputMat = Matrix4x4.Rotate(Quaternion.Euler(0.0f, 135.0f, 0.0f));
                transInputMat = Matrix4x4.Translate(Vector3.forward * 8.0f);
                newMat = localMat * rotateInputMat * transInputMat;
                SetTransformByMatrix(monkey1, newMat);
                break;
            case 2: // transform monkey 2
                localMat = Matrix4x4.TRS(monkey2.transform.localPosition, monkey2.transform.localRotation, monkey2.transform.localScale);
                rotateInputMat = Matrix4x4.Rotate(Quaternion.Euler(0.0f, -90.0f, 90.0f));
                transInputMat = Matrix4x4.Translate(Vector3.back * 8.0f);
                newMat = localMat * rotateInputMat * transInputMat;
                SetTransformByMatrix(monkey2, newMat);
                break;
            case 3: // transform monkey 3
                // Matrix4x4 matrix = transform.localToWorldMatrix;
                localMat = Matrix4x4.TRS(monkey3.transform.localPosition, monkey3.transform.localRotation, monkey3.transform.localScale);
                // transInputMat = Matrix4x4.Translate(new Vector3(6, 3, 6));
                // rotateInputMat = Matrix4x4.Rotate(Quaternion.Euler(0.0f, 180.0f, -45.0f));
                // Matrix4x4 scaleInputMat = Matrix4x4.Scale(new Vector3(3, 3, 3));
                rotateInputMat = Matrix4x4.Rotate(Quaternion.Euler(0.0f, -90.0f, 0.0f));
                transInputMat = Matrix4x4.Translate(new Vector3(15, 8, -8));
                Matrix4x4 scaleInputMat = Matrix4x4.Scale(new Vector3(3, 3, 3));
                newMat = localMat * rotateInputMat * scaleInputMat;
                
                SetTransformByMatrix(monkey3, newMat);
                break;
            case 4: // transform monkey 4
                localMat = Matrix4x4.TRS(monkey4.transform.localPosition, monkey4.transform.localRotation, monkey4.transform.localScale);
                rotateInputMat = Matrix4x4.Rotate(Quaternion.Euler(45.0f, 180.0f, 0.0f));
                transInputMat = Matrix4x4.Translate(new Vector3(5, 8, 5));
                scaleInputMat = Matrix4x4.Scale(new Vector3(2, 2, 2));
                newMat = localMat * scaleInputMat * rotateInputMat * transInputMat;
                SetTransformByMatrix(monkey4, newMat);
                break;
            case 5: // transform monkey 5
                localMat = Matrix4x4.TRS(monkey5.transform.localPosition, monkey5.transform.localRotation, monkey5.transform.localScale);
                rotateInputMat = Matrix4x4.Rotate(Quaternion.Euler(0.0f, -45.0f, -180.0f));
                transInputMat = Matrix4x4.Translate(new Vector3(0, 5, 0));
                newMat = localMat * rotateInputMat * transInputMat;
                SetTransformByMatrix(monkey5, newMat);
                break;
            // YOUR CODE - END
            default:
                currentMonkey = -1;
                ResetAllMonkeys();
                break;
        }
    }

    // Exercise 1.4 transform monkeys to final pose by accumulating matrices with your own matrix multiplication function.
    void MoveMonkeyCustom(int monkeyIndex)
    {
        Debug.Log("Moving monkey " + monkeyIndex);
        switch (monkeyIndex)
        {
            // YOUR CODE - BEGIN
            case 0: // transform monkey 0
                // get the local transformation of this Game Object by creating a TRS matrix
                Matrix4x4 localMat = Matrix4x4.TRS(monkey0.transform.localPosition, monkey0.transform.localRotation, monkey0.transform.localScale);

                // define input matrices for input accumulation (there can be multiple input matrices of each kind - translation, rotatation, and scale)              
                Matrix4x4 transInputMat = MakeTranslationMatrix(0.0f, 8.0f, 0.0f);

                // accumulate inputs through (your implementation of) multiplication of your input matrices to the local transformation matrix of this Game Object 
                // be careful with the order of operations; matrix multiplication is not commutative
                Matrix4x4 newMat = MultiplyMatrix(localMat, transInputMat);

                // the final computed matrix is applied to transform of the given game object
                SetTransformByMatrix(monkey0, newMat);
                break;
            case 1: // transform monkey 1
                localMat = Matrix4x4.TRS(monkey1.transform.localPosition, monkey1.transform.localRotation, monkey1.transform.localScale);
                // Matrix4x4 rotateInputMat = MakeRotationMatrix((Quaternion.Euler(0.0f, 135.0f, 0.0f)));
                transInputMat = MakeTranslationMatrix(0.0f, -8.0f, 0.0f);
                newMat = MultiplyMatrix(localMat, transInputMat);
                SetTransformByMatrix(monkey1, newMat);
                break;
            case 2: // transform monkey 2

                break;
            case 3: // transform monkey 3

                break;
            case 4: // transform monkey 4

                break;
            case 5: // transform monkey 5

                break;
            // YOUR CODE - END
            default:
                currentMonkey = -1;
                ResetAllMonkeys();
                break;
        }
    }

    void SetTransformByMatrix(GameObject go, Matrix4x4 mat)
    {
        go.transform.localPosition = mat.GetColumn(3);
        go.transform.localRotation = mat.rotation;
        go.transform.localScale = mat.lossyScale;
    }

    Matrix4x4 MakeTranslationMatrix(float x, float y, float z)
    {
        Matrix4x4 mat = Matrix4x4.identity;
        // YOUR CODE - BEGIN

        // YOUR CODE - END
        return mat;
    }

    Matrix4x4 MakeRotationMatrix(float degrees, int ax_x, int ax_y, int ax_z)
    {
        Matrix4x4 mat = Matrix4x4.identity;
        // YOUR CODE - BEGIN

        // YOUR CODE - END
        return mat;
    }

    Matrix4x4 MakeScaleMatrix(float sx, float sy, float sz)
    {
        Matrix4x4 mat = Matrix4x4.identity;
        // YOUR CODE - BEGIN

        // YOUR CODE - END
        return mat;
    }

    Matrix4x4 MultiplyMatrix(Matrix4x4 lhs, Matrix4x4 rhs)
    {
        Matrix4x4 mat = new Matrix4x4();
        // YOUR CODE - BEGIN

        // YOUR CODE - END
        return mat;
    }


    // Reset monkey head with index 
    void ResetMonkey(int monkeyIndex)
    {
        Debug.Log("Reset monkey " + monkeyIndex);
        monkeyHeads[monkeyIndex].transform.position = initialPositions[monkeyIndex];
        monkeyHeads[monkeyIndex].transform.rotation = initialRotations[monkeyIndex];
        monkeyHeads[monkeyIndex].transform.localScale = initialScales[monkeyIndex];
    }

    // Reset all monkey heads to their initial position
    void ResetAllMonkeys()
    {
        for (int i = 0; i < 6; ++i)
        {
            monkeyHeads[i].transform.position = initialPositions[i];
            monkeyHeads[i].transform.rotation = initialRotations[i];
            monkeyHeads[i].transform.localScale = initialScales[i];
        }
    }
}
