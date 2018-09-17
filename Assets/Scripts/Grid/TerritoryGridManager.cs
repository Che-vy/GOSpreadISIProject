﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Zone { Neutral, Player1, Player2 } // neutral = no particule, player 1 = blue particule, player 2 = red particule
public sealed class TerritoryGridManager
{
    private static TerritoryGridManager instance = null;
    public int zoneGridSize;
    public Zone[,] zoneGrid; // exact same grid as the game grid but only takes account of the zone possessions
    public Vector2 playerPoints;


    #region Singleton
    private TerritoryGridManager()
    {
    }

    public static TerritoryGridManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new TerritoryGridManager();
            }
            return instance;
        }
    }
    #endregion

    public void Initialize() // set all the zones to neutral so player starts with 0 zones 
    {
        if (GridManager.Instance.grid_objects != null)
        {
            zoneGridSize = GridManager.Instance.grid_objects.Length;
        }
        zoneGrid = new Zone[zoneGridSize, zoneGridSize];
        for (int i = 0; i <= zoneGrid.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= zoneGrid.GetUpperBound(0); j++)
            {
                if (i % 2 != 0 && j % 2 != 0)
                {
                    zoneGrid[i, j] = Zone.Neutral;
                }

            }
        }
    }

    public Vector2 CalculateZoneControl() // call at each player turn. not each update

        // need to change switch case to array 
    {
        int p1Territory = 0;
        int p2Territory = 0;

        for (int i = 0; i < zoneGrid.GetUpperBound(0); i++)
        {
            for (int j = 0; j <= zoneGrid.GetUpperBound(0); j++)
            {
                if (i % 2 != 0 && j % 2 != 0)
                {
                    switch (zoneGrid[i, j])
                    {
                        case Zone.Neutral:
                            break;
                        case Zone.Player1:
                            p1Territory++;
                            break;
                        case Zone.Player2:
                            p2Territory++;
                            break;
                        default:
                            Debug.Log("Out of the enums. Some problem happened");
                            break;
                    }
                }

            }
        }
        playerPoints = new Vector2(p1Territory, p2Territory);

        return playerPoints;
    }

    public void ChangeZone(int i, int j, Zone newZoneType)
    {
        zoneGrid[i, j] = newZoneType;
    }
}

