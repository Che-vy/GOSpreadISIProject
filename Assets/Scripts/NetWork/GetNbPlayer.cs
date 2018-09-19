using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetNbPlayer : MonoBehaviour {

    GameObject[] playersObject;
    List<Player> players;

    public void Initialize()
    {
        //Start a Coroutine to get the number of player
        StartCoroutine(getPlayers());
    }

    IEnumerator getPlayers()
    {
        //Continue to search for the players until the list has the right number
        while (players == null || players.Count < NetworkLobbyManager.singleton.numPlayers)
        {
            //Wait for 0.25 secondes to let the client connect
            yield return new WaitForSeconds(0.25f);
            
            //Find the gameObject with the tag Players
            playersObject = GameObject.FindGameObjectsWithTag("Player");
            players = new List<Player>();

            //Get the Script Player on the player Object
            foreach (GameObject p in playersObject)
            {
                Player po = p.GetComponent<Player>();
                players.Add(po);
                po.id = players.Count;
            }
        }
       

        //Set the players in playerManager
        PlayerManager.Instance.setPlayer(playersObject, players);

        yield return new WaitForSeconds(0.5f);
        //Initialize players
        PlayerManager.Instance.initializePlayers();
        //Destroy Itself
        Destroy(gameObject);
    }
}
