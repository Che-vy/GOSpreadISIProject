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
        playersObject = pO;
        players = ps;

        foreach (Player p in players)
        {
            p.initialization();
        }

    }


    public void Update()
    {
        foreach (Player player in players)
        {
            player.UpdatePlayer();
        }
    }



    public static void ClosePlayerManager()
    {
        instance = null;
    }
}
