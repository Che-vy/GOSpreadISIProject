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


                if (currentMode == CurrentMode.STANDBY && Movements.CanSelectUnit(pkg.objectSelected, phase))
                {

                }
                else if (currentMode == CurrentMode.CREATE)
                {
                    if (pkg.objectSelected.tag == "IntersectionCollider")
                    {
                        co.CmdspawnUnit(pkg.objectSelected.GetComponentInParent<Intersection>().arrayPos, id, UnitType.Bit);
                        GridManager.Instance.DeactivateLight(Movements.posActiver);
                        currentMode = CurrentMode.STANDBY;
                        NextPhase();
                    }

                }

                else if (currentMode == CurrentMode.MOVE)
                {
                    if (pkg.objectSelected.tag == "IntersectionCollider")
                    {

                        Vector2 pos = Movements.LastObjetSelectionne.GetComponent<BasePawnsClass>().positionInGridArray;
                        Vector2 des = pkg.objectSelected.transform.parent.gameObject.GetComponent<Intersection>().arrayPos;

                        co.CmdMoveUnit(id, pos, des);
                        GridManager.Instance.DeactivateLight(Movements.posActiver);
                        currentMode = CurrentMode.STANDBY;
                        NextPhase();
                    }
                }


            }



            //Update each phase
            if (phase == KERNELPHASE)
            {

            }
            else if (phase == MOVEPHASE)
            {

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

        foreach (Player p in PlayerManager.Instance.players)
        {
            p.zone = (int)TerritoryGridManager.Instance.CalculateZoneControl()[p.id];
        }

    }

    void UpdatePhase3(InputManager.InputPkg pkg)
    {


        co.CmdCheckTerritory(id);
        NextPhase();
    }

    public void changeName(string name_)
    {
        name = name_;
        gameObject.name = name;
    }

    public void NextPhase()
    {
        if (Movements.LastObjetSelectionne != null)
            ParticleManager.StopParticleSystem(Movements.LastObjetSelectionne.transform.GetChild(0).gameObject);
        phase++;

        UIManager.Instance.SetPhaseInfo(phase > 3 ? 1 : phase);
        if (phase > 3 && PlayerManager.Instance.playerTurn == id)
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
