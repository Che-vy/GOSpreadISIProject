using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager
{

    Grid grid_master;
    GameObject[,] grid_objects = null;

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


    public void Initialize()
    {
        grid_master = new Grid();
        grid_master.Initialize(4);
    }

    public void InstantiateGridObjects()
    {
        GridFactory.Instance.Initialize();
        grid_objects = GridFactory.Instance.CreatedGrid(grid_master.gridLayout);
        InitializeGridObjectsPositions(grid_objects);
    }

    public void InitializeGridObjectsPositions(GameObject[,] _grid_objects)
    {
        Vector3 testVict = new Vector3();

        for (int i = 0; i <= _grid_objects.GetUpperBound(0); i++)
        {
            float xDistTraveled = 0;
            float zDistTraveled = 0;
            for (int j = 0; j <= _grid_objects.GetUpperBound(0); j++)
            {
                //_grid_objects[i, j].transform.position = testVict;
                //testVict += new Vector3(0, 0, GridFactory.Instance.zoneS.z);


                if (i % 2 == 0) //if its column index is even, it's either an intersection or a segment
                {
                    if (j % 2 == 0) //if its row index is even, it's an intersection
                    {
                        _grid_objects[i, j].transform.position = new Vector3((GridFactory.Instance.intersectionWidth / 2) + i * (GridFactory.Instance.intersectionWidth + GridFactory.Instance.segmentWidth), 0, ((j * GridFactory.Instance.intersectionWidth) + (j / 2 * GridFactory.Instance.segmentWidth)));

                    }
                    else
                    {
                        _grid_objects[i, j].transform.position = new Vector3(i * ((GridFactory.Instance.intersectionWidth) + (GridFactory.Instance.segmentHeight)), 0, ((j * GridFactory.Instance.intersectionWidth) + (j / 2 * GridFactory.Instance.segmentWidth)));
                    }

                }
                else
                { //else it's either a segment or a zone
                    if (j % 2 == 0) //if its row index is even, it's a segment
                    {
                        _grid_objects[i, j].transform.position = new Vector3(i * ((GridFactory.Instance.intersectionWidth) + (GridFactory.Instance.segmentHeight)), 0, j * ((GridFactory.Instance.segmentWidth) + (GridFactory.Instance.zoneWidth)));
                        _grid_objects[i, j].transform.rotation = new Quaternion();
                    }
                    else //else it is a zone
                    {
                        _grid_objects[i, j].transform.position = new Vector3(i * ((GridFactory.Instance.intersectionWidth) + (GridFactory.Instance.segmentHeight)), 0, j * ((GridFactory.Instance.intersectionWidth) + (GridFactory.Instance.segmentWidth)));

                    }
                }


            }
        }


    }
}
