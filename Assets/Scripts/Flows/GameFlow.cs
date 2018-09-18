using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameFlow : Flow {

    readonly int mapSize = 10;

    override
    public void InitializeFlow()
    {
        GridManager.Instance.Initialize(mapSize);
        PlayerManager.Instance.initialization();
        //UIManager.Instance.initialization();
        //TerritoryGridManager.Instance.initialization();
        UnitFactory.Instance.Initialize();
        //UnitGridManager.Instance.initialization();
<<<<<<< HEAD
        //UnitGridManager.Instance.Initialize();
        //UnitGridManager.Instance.AddUnit(10,10,1, UnitType.Bit);
=======
        UnitGrid.Instance.Initialize();
        Demo.Instance.StartDemo(); //FOR DEMONSTRATION PURPOSES ONLY
>>>>>>> 4f540c99bf8d87fd42f4a96f782f4c00a370d67f
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
