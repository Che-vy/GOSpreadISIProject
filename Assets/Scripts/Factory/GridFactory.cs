using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridFactory {
    readonly float GAME_TILE_HEIGHT = 0;
    readonly float GAME_SEGMENT_HEIGHT = -0.25f;
    private GameObject zone;
    private GameObject segment;
    private GameObject intersection;

    public float zoneWidth;
    public float segmentWidth, segmentHeight;
    public float intersectionWidth;

    #region Singleton
    private static GridFactory instance = null;

    private GridFactory()
    {
    }

    public static GridFactory Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GridFactory();
            }
            return instance;
        }
    }
    #endregion


    public void Initialize() {
        zone = Resources.Load<GameObject>("Prefabs/Grid/Zone");
        segment = Resources.Load<GameObject>("Prefabs/Grid/Segment");
        intersection = Resources.Load<GameObject>("Prefabs/Grid/Intersection");

        zoneWidth = zone.transform.localScale.x;
        segmentWidth = segment.transform.localScale.x;
        segmentHeight = segment.transform.localScale.z;
        intersectionWidth = intersection.transform.localScale.x;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="masterGrid"></param>
    /// <param name="parentName">The name given to the full grid parent game object</param>
    /// <returns></returns>
    public GameObject[,] CreatedGrid(GridComponentType[,] masterGrid, string parentName)
    {
        int width = masterGrid.GetUpperBound(0) + 1;
        GameObject[,] result = new GameObject[width, width];
        GameObject parent = new GameObject();
        parent.name = parentName;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < width; j++)
            {
                switch (masterGrid[i, j]) {
                    case GridComponentType.Zone:
                        result[i, j] = GameObject.Instantiate<GameObject>(zone);                     
                        break;
                    case GridComponentType.Segment:
                        result[i, j] = GameObject.Instantiate<GameObject>(segment);
                        break;
                    case GridComponentType.Intersection:
                        result[i, j] = GameObject.Instantiate<GameObject>(intersection);
                        break;
                    default:
                        break;
                        }
                result[i, j].transform.parent = parent.transform;

            }
        }
        return result;
    }
}
