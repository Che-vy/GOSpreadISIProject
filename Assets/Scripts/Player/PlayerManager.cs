using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerManager
{

    private static PlayerManager instance = null;
    public Movements move;

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
    public Vector3 p1Cam = new Vector3(5, 1.6f, -2.5f);
    public Vector3 p2Cam = new Vector3(5, 1.6f, 12);
   public MoveCamera moveCam;

    InputManager inputMan;

    //Initialize the List of player
    public void initialization()
    {
        players = new List<Player>();
        playerTurn = 1;
        Camera camera = Camera.main;
        moveCam = camera.GetComponent<MoveCamera>();


        move = new Movements();
        inputMan = new InputManager();

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

        playerTurn = 1;
        UIManager.Instance.Initialization();


        
    }

    //Update the right player
    public void Update()
    {

        if (players != null && players.Count > 0)
        {
            InputManager.InputPkg pkg = inputMan.GetInputs();
            players[playerTurn - 1].UpdatePlayer(pkg);
            UIManager.Instance.Update();
            moveCam.UpdateCamera(pkg);
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
        players[playerTurn - 1].initializeTurn();
    }

    //Get one player
    public Player getPlayer(int id)
    {
        return players[id - 1];
    }


}
