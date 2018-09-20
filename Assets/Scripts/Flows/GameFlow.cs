using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameFlow : Flow
{
    Movements move;
    readonly int mapSize = 10;
    public static UILinks uiLinks;

    GameObject gO;

    override
    public void InitializeFlow()
    {
        GameObject network = GameObject.Instantiate(Resources.Load("Prefabs/Network/GetNbConnection") as GameObject);
        GetNbPlayer networkGetPlayer = network.GetComponent<GetNbPlayer>();
        networkGetPlayer.Initialize();

        GetNbPlayer nbPlayer = GameObject.FindGameObjectWithTag("SetPlayers").GetComponent<GetNbPlayer>();
        uiLinks = GameObject.FindObjectOfType<UILinks>();
        nbPlayer.Initialize();

        move = new Movements();

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
      //
      //  UnitGrid.Instance.unitGrid[0, 0] = gO.GetComponent<BasePawnsClass>();
      //  Debug.Log("call3");
      //  UnitGrid.Instance.unitGrid[0, 0].positionInGridArray = new Vector2Int(0, 0);
      //  Debug.Log("call4");
      //
      //  move.CanItMove(gO.GetComponent<BasePawnsClass>());
      //  Debug.Log("call5");
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
