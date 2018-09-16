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
