using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerManager
{

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
    public List<Player> players;
    public int playerTurn = 1;


    //Initialize the List of player
    public void initialization()
    {
        players = new List<Player>();
    }

    //Set the players in the list and Array
    public void setPlayer(GameObject[] pO, List<Player> ps)
    {
        players = ps;
        playersObject = pO;

    }

    //Initialize the players
    public void initializePlayers()
    {
        foreach (Player p in players)
        {
            p.initialization();


        }
        
       
        UIManager.Instance.Initialization();
    }

    //Update the right player
    public void Update()
    {

        if (players != null && players.Count > 0)
        {
            players[playerTurn - 1].UpdatePlayer();
            UIManager.Instance.Update();
        }
    }


    //Close the Player Manager
    public static void ClosePlayerManager()
    {
        instance = null;
    }

    //Change turn
    public void changeTurn()
    {
        playerTurn++;
        //If playerturn is bigger than the number of player playerTurn = 1
        if (playerTurn > players.Count)
        {
            playerTurn = 1;
        }
        UIManager.Instance.PlayersTurnChange(playerTurn);
        players[playerTurn-1].initializeTurn();
    }

    //Get one player
    public Player getPlayer(int id)
    {
        return players[id - 1];
    }

  
}
