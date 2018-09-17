using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager
{
    Grid grid_blueprint;
    GameObject[,] grid_objects = null;
    float hOffset;
    float vOffset;

    #region Singleton
    private static GridManager instance = null;

    private GridManager()
    {
    }

    public static GridManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GridManager();
            }
            return instance;
        }
    }
    #endregion

    /// <summary>
    /// Given the number of intersections wanted for a map, initializes a full grid of 2*number - 1 gameObjects
    /// </summary>
    /// <param name="size">The number of intersections on a side</param>
    public void Initialize(int size)
    {
        grid_blueprint = new Grid();     
        grid_blueprint.Initialize(size);
        InstantiateGridObjects();
    }

    public void InstantiateGridObjects()
    {
        GridFactory.Instance.Initialize();
        grid_objects = GridFactory.Instance.CreatedGrid(grid_blueprint.gridLayout, "Grid Parent");
        InitializeGridObjectsPositions(grid_objects);
    }

    public void InitializeGridObjectsPositions(GameObject[,] _grid_objects)
    {
        int arraySize = _grid_objects.GetUpperBound(0);

        for (int i = 0; i <= arraySize; i++)
        {
            for (int j = 0; j <= arraySize; j++)
            {
                if (i % 2 == 0) //if its column index is even, it's either an intersection or a segment
                {
                    hOffset = ((((i / 2) + 0.5f) * GridFactory.Instance.intersectionWidth) + ((i / 2) * GridFactory.Instance.segmentWidth));

                    if (j % 2 == 0) //if its row index is even, it's an intersection
                    {
                        vOffset = ((((j / 2) + 0.5f) * GridFactory.Instance.intersectionWidth) + (Mathf.Round(j / 2) * GridFactory.Instance.segmentWidth)) - (GridFactory.Instance.intersectionWidth / 2);
                    }
                    else
                    {
                        vOffset = ((((j / 2) + 0.5f) * GridFactory.Instance.intersectionWidth) + (Mathf.Round(j / 2)) * GridFactory.Instance.segmentWidth) + (GridFactory.Instance.segmentWidth / 2);
                    }
                }
                else
                { //else it's either a segment or a zone
                    hOffset = ((((i / 2) + 0.5f) * GridFactory.Instance.intersectionWidth) + (((i / 2) + 0.5f) * GridFactory.Instance.segmentWidth)) + (GridFactory.Instance.intersectionWidth / 2);

                    if (j % 2 == 0) //if its row index is even, it's a segment
                    {
                        vOffset = ((((j / 2) + 0.5f) * GridFactory.Instance.intersectionWidth) + (Mathf.Round(j / 2)) * GridFactory.Instance.segmentWidth) - (GridFactory.Instance.intersectionWidth / 2);
                        _grid_objects[i, j].transform.rotation = new Quaternion();

                    }
                    else //else it is a zone
                    {
                        vOffset = ((((j / 2) + 0.5f) * GridFactory.Instance.intersectionWidth) + (Mathf.Round(j / 2)) * GridFactory.Instance.segmentWidth) + (GridFactory.Instance.zoneWidth / 2);
                    }
                }
                _grid_objects[i, j].transform.position = new Vector3(hOffset, 0, vOffset); //set GameObject position
            }
        }
    }

    public Transform GetGridComponentPosition(int indexA, int indexB) {
        return grid_objects[indexA, indexB].transform;
    }

    public int GetGridSize() {
        return grid_blueprint.GetGridSize();
    }
}
