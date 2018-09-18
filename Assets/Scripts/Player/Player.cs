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
    public int zone = 0;

       public string name;
    public int phase = 1;
    bool initialize = false;

    public void initialization()
    {
        if (!isLocalPlayer)
        {
            return;
        }
      


        co = GetComponent<ConnectionManager>();
        name = Prototype.NetworkLobby.LobbyPlayerList._instance._players[id - 1].playerName;
        
        inputMan = new InputManager();

        co.CmdDebug(id, name);
        co.CmdChangeNom(id, name);
        initialize = true;
    }

    public void UpdatePlayer()
    {

        if (initialize == true)
        {
            if (!isLocalPlayer)
            {
                return;
            }

            InputManager.InputPkg pkg = inputMan.GetInputs();

            if (pkg.objectSelected != null)
            {
                co.CmdDebug(id, name);
                co.CmdNextTurn();
            }

            if (phase == KERNELPHASE)
            {

            }
        }

    }


    void UpdatePhase1()
    {

    }
    void UpdatePhase2()
    {

    }
    void UpdatePhase3()
    {

    }

    public void changeName(string name_)
    {
        name = name_;
        gameObject.name = name;
    }


}
