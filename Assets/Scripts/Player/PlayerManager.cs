using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager  {

    private static PlayerManager instance = null;

    private PlayerManager()
    {
    }

    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerManager();
            }
            return instance;
        }
    }


    GameObject[] playersObject;
    List<Player> players;
    public int playerTurn = 1;

    public void initialization()
    {
        players = new List<Player>();
    }

    public void setPlayer(GameObject[] pO, List<Player> ps)
    {
        players = ps;
        playersObject = pO;
      
    }
    public void initializePlayers()
    {
        foreach (Player p in players)
        {
            p.initialization();
        }
    }


    public void Update()
    {
        Debug.Log("TOUR: "+playerTurn);
        if(players != null && players.Count > 0)
        players[playerTurn - 1].UpdatePlayer();
    }



    public static void ClosePlayerManager()
    {
        instance = null;
    }

    public void changeTurn()
    {
        playerTurn++;
        if(playerTurn >players.Count)
        {
            playerTurn = 1;
        }
    }
    public Player getPlayer(int id)
    {
        Debug.Log(players.Count);
        return players[id - 1];
    }
}
