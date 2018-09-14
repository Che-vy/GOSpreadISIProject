using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class TerritoryGridManager
{
    private static TerritoryGridManager instance = null;

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












}

