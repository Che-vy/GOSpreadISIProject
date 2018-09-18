using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    readonly int KERNELPHASE = 1;
    readonly int MOVEPHASE = 2;
    readonly int TERRITORYPHASE = 3;

    public int id;
    ConnectionManager co;
    InputManager inputMan;

       public string name;
    public int phase = 1;

    public void initialization()
    {
        if (!isLocalPlayer)
        {
            return;
        }
      


        co = GetComponent<ConnectionManager>();
        name = Prototype.NetworkLobby.LobbyPlayerList._instance._players[id - 1].playerName;
        co.CmdDebug(id, name);
        co.CmdChangeNom(id,name);
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
            co.CmdDebug(id,name);
        }

        if(phase == KERNELPHASE)
        {

        }

    }


    public void UpdatePhase1()
    {

    }
    public void UpdatePhase2()
    {

    }
    public void UpdatePhase3()
    {

    }

    public void changeName(string name_)
    {
        name = name_;
        gameObject.name = name;
    }


}
