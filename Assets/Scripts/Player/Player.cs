using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public enum CurrentMode { STANDBY, MOVE, CREATE };

public class Player : NetworkBehaviour
{
    //All the different phases
    readonly int KERNELPHASE = 1;
    readonly int MOVEPHASE = 2;
    readonly int TERRITORYPHASE = 3;

    public int id;
    ConnectionManager co;
    
    public int zone = 0;

    public bool isConnected = false;
    public bool haha = true;
    public CurrentMode currentMode = CurrentMode.STANDBY;

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
        PlayerManager.Instance.playerTurn = 1;
        //Get the connectionManager
        co = GetComponent<ConnectionManager>();
        GameLinks.Instance.co = co;

        //Get the player name from the lobby
        name = Prototype.NetworkLobby.LobbyPlayerList._instance._players[id - 1].playerName;

        //Create and InputManager
        
        isConnected = true;

        //Change the name in the UI on all the clients
        co.CmdChangeNom(id, name);
        initialize = true;

        if (PlayerManager.Instance.playerTurn == id)
        {
            initializeTurn();
            PlayerManager.Instance.moveCam.gameObject.transform.position = PlayerManager.Instance.p1Cam;
        }
        else
        {
            Vector3 rotation = PlayerManager.Instance.moveCam.gameObject.transform.rotation.eulerAngles;
            rotation.y = 180;
            PlayerManager.Instance.moveCam.gameObject.transform.rotation = Quaternion.Euler(rotation);
            PlayerManager.Instance.moveCam.gameObject.transform.position = PlayerManager.Instance.p2Cam;
            
            UIManager.Instance.DesactivateTurn();
        }
    }

    public void UpdatePlayer(InputManager.InputPkg pkg)
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
            


            if (pkg.objectSelected != null)
            {
                co.CmdDebug(id, name);


                if (currentMode == CurrentMode.STANDBY)
                {
                    UIManager.Instance.ShowUnitsUI(pkg.objectSelected, phase);
                }
                else if (currentMode == CurrentMode.CREATE)
                {
                    if (pkg.objectSelected.tag == "IntersectionCollider")
                        co.CmdspawnUnit(pkg.objectSelected.GetComponentInParent<Intersection>().arrayPos, id, UnitType.Bit);
                }

                else if (currentMode == CurrentMode.MOVE)
                {
                    if (pkg.objectSelected.tag == "IntersectionCollider") ;                      ;
                }

               //  UIManager.Instance.ShowUnitsUI(pkg.objectSelected,phase);
                PlayerManager.Instance.move.CanSelectUnit(pkg.objectSelected, phase);


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
        UIManager.Instance.SetPhaseInfo(phase);
        if (isLocalPlayer)
            UIManager.Instance.ActivateTurn();

    }

    void UpdatePhase1(InputManager.InputPkg pkg)
    {

        // if (pkg.objectSelected != null)
        // {
        //     phase++;
        // }

       // switch (id) {
       //     case 1:
       //     Rule3A.Instance.RunTerritoryCheck(2, id+1);
       //         break;
       //     case 2:
       //         Rule3A.Instance.RunTerritoryCheck(2, id - 1);
       //         break;
       // }
        Debug.Log("In Phase 1");
    }

    void UpdatePhase2(InputManager.InputPkg pkg)
    {
        Movements.CanItMove(UnitGrid.Instance.GetUnitGO(new Vector2Int(8, 4)).GetComponent<BasePawnsClass>());
        //Rule3A.Instance.RunMovementCheck(new Vector2Int(2, 2), 2);
        if (!haha)
        {
            StartCoroutine(Rule3A.Instance.LerpMovementTool(false, UnitGrid.Instance.unitGridGO[2, 2], GridManager.Instance.grid_objects[2, 4], 1.0f));
            haha = false;
        }
        //Rule3A.Instance.RunMovementCheck(new Vector2Int(4, 2), 2);
        // if (pkg.objectSelected != null)
        // {
        //     phase++;
        // }
        Debug.Log("In Phase 2");
    }

    void UpdatePhase3(InputManager.InputPkg pkg)
    {
        // if (pkg.objectSelected != null)
        // {
        //     phase++;
        //     
        // }
        // Rule3A.Instance.RunTerritoryCheck(2, id);

        co.CmdCheckTerritory(id);
        Debug.Log("In Phase 3");
    }

    public void changeName(string name_)
    {
        name = name_;
        gameObject.name = name;
    }

    public void NextPhase()
    {
        phase++;

        UIManager.Instance.SetPhaseInfo(phase > 3 ? 1 : phase);
        if (phase > 3 && PlayerManager.Instance.playerTurn == id )
        {
            if (isLocalPlayer)
                UIManager.Instance.DesactivateTurn();

            co.CmdNextTurn();
        }
    }

    public void StandBy()
    {
        phase = 3;
        UIManager.Instance.SetPhaseInfo(phase);
    }
}
