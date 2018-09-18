using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ConnectionManager : NetworkBehaviour {


    [Command]
    public void CmdDebug(int pId)
    {
        RpcDebug(pId);


    }

    [ClientRpc]
    void RpcDebug( int pid)
    {

        Debug.Log("Player " + pid);
    }

}
