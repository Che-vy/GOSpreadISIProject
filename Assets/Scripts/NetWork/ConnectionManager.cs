using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ConnectionManager : NetworkBehaviour {


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
    }

    //Change turn
    [Command]
    public void CmdNextTurn()
    {

    }
    [ClientRpc]
    void RpcNextTurn()
    {

        PlayerManager.Instance.changeTurn();
    }

}
