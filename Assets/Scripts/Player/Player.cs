using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    //All the different phases
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

    //Initialize the player
    public void initialization()
    {
        //If this is the local Player
        if (!isLocalPlayer)
        {
            return;
        }

        //Get the connectionManager
        co = GetComponent<ConnectionManager>();
        GameLinks.Instance.co = co;

        //Get the player name from the lobby
        name = Prototype.NetworkLobby.LobbyPlayerList._instance._players[id - 1].playerName;

        //Create and InputManager
        inputMan = new InputManager();
        isConnected = true;

        //Change the name in the UI on all the clients
        co.CmdChangeNom(id, name);
        initialize = true;
    }

    public void UpdatePlayer()
    {
        //If the player is initialize
        if (initialize == true)
        {
            //If the player is local
            if (!isLocalPlayer)
            {
                return;
            }
            //get the package from the inputManager
            InputManager.InputPkg pkg = inputMan.GetInputs();


            if (pkg.objectSelected != null)
            {
                co.CmdDebug(id, name);

                string targetName = pkg.objectSelected.name;
                if (targetName.Contains("Kernel"))
                    UIManager.Instance.ShowUnitsUI(PawnTypes.Kernel);
                else
                    UIManager.Instance.HideUnitsUI(PawnTypes.Kernel);
            }



            //Update each phase
            if (phase == KERNELPHASE)
            {
                UpdatePhase1(pkg);
            }
            else if (phase == MOVEPHASE)
            {
                UpdatePhase2(pkg);
            }
            else if (phase == TERRITORYPHASE)
            {
                UpdatePhase3(pkg);
            }

        }

    }
    //initialize at the start of the turn
    public void initializeTurn()
    {
        phase = KERNELPHASE;
    }

    void UpdatePhase1(InputManager.InputPkg pkg)
    {
       
        if (pkg.objectSelected != null)
        {
            phase++;
        }

        Debug.Log("In Phase 1");

    }
    void UpdatePhase2(InputManager.InputPkg pkg)
    {
        if (pkg.objectSelected != null)
        {
            phase++;
        }
        Debug.Log("In Phase 2");
    }
    void UpdatePhase3(InputManager.InputPkg pkg)
    {
        if (pkg.objectSelected != null)
        {
            phase++;
            co.CmdNextTurn();
        }
        Debug.Log("In Phase 3");
    }



    public void changeName(string name_)
    {
        name = name_;
        gameObject.name = name;
    }


}
