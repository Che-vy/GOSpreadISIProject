using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ConnectionManager : NetworkBehaviour
{

    //Test command

    [Command]
    public void CmdDebug(int pId, string name)
    {
        RpcDebug(pId, name);

    }

    [ClientRpc]
    void RpcDebug(int pid, string name)
    {


    }


    //Set name of player
    [Command]
    public void CmdChangeNom(int id, string name)
    {
        RpcChangeName(id, name);
    }

    [ClientRpc]
    void RpcChangeName(int id, string name)
    {

        PlayerManager.Instance.getPlayer(id).changeName(name);
        UIManager.Instance.Initialization();
    }

    //Change turn
    [Command]
    public void CmdNextTurn()
    {
        RpcNextTurn();
    }
    [ClientRpc]
    void RpcNextTurn()
    {

        PlayerManager.Instance.changeTurn();
    }



    //Spawn a unit
    [Command]
    public void CmdspawnUnit(Vector2 unitIndex, int player, UnitType unitType)
    {
        RpcspawnUnit(unitIndex, player, unitType);
    }
    [ClientRpc]
    void RpcspawnUnit(Vector2 unitIndex, int player, UnitType unitType)
    {
        Vector2Int v = new Vector2Int((int)unitIndex.x, (int)unitIndex.y);

        UnitGrid.Instance.AddUnit(v, player, unitType);

    }


    //Check Territory
    [Command]
    public void CmdCheckTerritory(int id)
    {
        RpcCheckTerritory(id);
    }
    [ClientRpc]
    void RpcCheckTerritory(int id)
    {

        Rule3A.Instance.RunTerritoryCheck(2, id);

    }


    //MoveUnit
    [Command]
    public void CmdMoveUnit(int id, Vector2 toMove, Vector2 destination)
    {
        RpcMoveUnit(id, toMove, destination);
    }
    [ClientRpc]
    void RpcMoveUnit(int id, Vector2 toMove, Vector2 destination)
    {
        Vector2Int pos = new Vector2Int((int)toMove.x, (int)toMove.y);
        Vector2Int des = new Vector2Int((int)destination.x, (int)destination.y);

        StartCoroutine(Rule3A.Instance.LerpMovementTool(false, UnitGrid.Instance.unitGridGO[pos.x, pos.y], GridManager.Instance.grid_objects[des.x, des.y], 1.5f));

        Rule3A.Instance.MovePiece(pos, des);
    }


}
