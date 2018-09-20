using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {


    InputManager inputMan;
    public float speed = 0.1f;

    public void initialize()
    {
        inputMan = new InputManager();
    }

    public void UpdateCamera()
    {
        InputManager.InputPkg pkg = inputMan.GetInputs();
        if(transform.rotation.eulerAngles.y == 180)
        {
            transform.position -= pkg.cameraDirectionPressed * speed;
        }
        else
        {
            transform.position += pkg.cameraDirectionPressed * speed;
        }
        
    }
}
