using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetNbPlayer : MonoBehaviour {

    GameObject[] playersObject;
    List<Player> players;

    public void Initialize()
    {
        Debug.Log("Number of player");
        StartCoroutine(getPlayers());
    }

    IEnumerator getPlayers()
    {
        while (players == null || players.Count < NetworkLobbyManager.singleton.numPlayers)
        {
            yield return new WaitForSeconds(0.25f);

            playersObject = GameObject.FindGameObjectsWithTag("Player");
            players = new List<Player>();
            foreach (GameObject p in playersObject)
            {
                Player po = p.GetComponent<Player>();
                players.Add(po);
                po.id = players.Count;
            }
        }

        PlayerManager.Instance.setPlayer(playersObject, players);
        Destroy(gameObject);
    }
}
