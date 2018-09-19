using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ConnectionManager : NetworkBehaviour {

    Movements move = new Movements();

    [Command]
    public void CmdDebug(int pId,string name)
    {
        RpcDebug(pId, name);

    }

    [ClientRpc]
    void RpcDebug( int pid, string name)
    {

        Debug.Log("Player " + pid+ ": tour fini");
    }
    

    //Set name of player
    [Command]
    public void CmdChangeNom(int id,string name)
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

    [Command]
    public void CmdspawnUnit(UnitType unit)
    {
        RpcspawnUnit(unit);
    }
    [ClientRpc]
    void RpcspawnUnit(UnitType unit)
    {

        GameObject gO = UnitFactory.Instance.SpawnUnit(unit);
        gO.transform.position = new Vector3(1, 1, 1);

    }
}
