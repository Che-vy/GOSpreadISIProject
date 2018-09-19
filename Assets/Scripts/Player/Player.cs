﻿using System.Collections;
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

    public bool isConnected = false;

    [SyncVar]
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
        isConnected = true;
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
                co.CmdspawnUnit(UnitType.Bit);
                co.CmdDebug(id, name);
                co.CmdNextTurn();
                UIManager.Instance.ShowUnitsUI(pkg.objectSelected);
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
