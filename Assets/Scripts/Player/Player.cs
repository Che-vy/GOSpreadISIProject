using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{

    public int id;
    ConnectionManager co;
    InputManager inputMan;

    public void initialization()
    {
        if (!isLocalPlayer)
        {
            return;
        }
       
        co = GetComponent<ConnectionManager>();

        inputMan = new InputManager();
    }

    public void UpdatePlayer()
    {

        if (!isLocalPlayer)
        {
            return;
        }

        InputManager.InputPkg pkg = inputMan.GetInputs();

        if(pkg.objectSelected != null)
        {
            co.CmdDebug(id);
        }

    }



}
