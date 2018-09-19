using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameFlow : Flow
{

    readonly int mapSize = 10;
    public static UILinks uiLinks;
    Movements move;
    GameObject gO;

    override
    public void InitializeFlow()
    {
        move = new Movements();
        GameObject network = GameObject.Instantiate(Resources.Load("Prefabs/Network/GetNbConnection") as GameObject);
        GetNbPlayer networkGetPlayer = network.GetComponent<GetNbPlayer>();
        networkGetPlayer.Initialize();

        GetNbPlayer nbPlayer = GameObject.FindGameObjectWithTag("SetPlayers").GetComponent<GetNbPlayer>();
        uiLinks = GameObject.FindObjectOfType<UILinks>();
        nbPlayer.Initialize();



        GridManager.Instance.Initialize(mapSize);
        PlayerManager.Instance.initialization();
        //UIManager.Instance.initialization();
        //TerritoryGridManager.Instance.initialization();
        UnitFactory.Instance.Initialize();
        //UnitGridManager.Instance.initialization();
        UnitGrid.Instance.Initialize();
        Demo.Instance.StartDemo(); //FOR DEMONSTRATION PURPOSES ONLY


        // test for unit movement pos
       // gO = UnitFactory.Instance.SpawnUnit(UnitType.Bit);
       // gO.transform.position = new Vector3(4, 1, 4);
       // UnitGrid.Instance.unitGrid[4, 4] = gO.GetComponent<BasePawnsClass>();
       // UnitGrid.Instance.unitGrid[4, 4].positionInGridArray = new Vector2Int(4, 4);
       //
       // move.CanItMove(gO.GetComponent<BasePawnsClass>());

    }

    override
    public void UpdateFlow(float dt)
    {
        PlayerManager.Instance.Update();
      
    }

    override
    public void FixedUpdateFlow(float dt)
    {

    }

    override
    public void CloseFlow()
    {
        PlayerManager.ClosePlayerManager();
    }
}
