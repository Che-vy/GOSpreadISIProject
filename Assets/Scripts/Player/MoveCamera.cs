using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {


    public float speed = 0.05f;

    public void UpdateCamera(InputManager.InputPkg pkg)
    {
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
