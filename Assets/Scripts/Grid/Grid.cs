using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GridComponentType { Zone = 1, Segment, Intersection }
public class Grid
{
    public GridComponentType[,] gridLayout;

    public void Initialize(int width)
    {
        gridLayout = new GridComponentType[(width * 2) - 1, (width * 2) - 1];

        for (int i = 0; i < width * 2 - 1; i++)
        {
            for (int j = 0; j < width * 2 - 1; j++)
            {
                if (i % 2 == 0) //if its column index is even, it's either an intersection or a segment
                {
                    if (j % 2 == 0) //if its row index is even, it's an intersection
                    {
                        gridLayout[i, j] = GridComponentType.Intersection;
                    }
                    else
                    {
                        gridLayout[i, j] = GridComponentType.Segment;
                    }
                }
                else
                { //else it's either a segment or a zone
                    if (j % 2 == 0) //if its row index is even, it's a segment
                    {
                        gridLayout[i, j] = GridComponentType.Segment;
                    }
                    else //else it is a zone
                    {
                        gridLayout[i, j] = GridComponentType.Zone;
                    }
                }
            }
        }

    }

}
